using System.Reflection.Metadata.Ecma335;

public class RemoveNthFromEndTask
{

    private static RemoveNthFromEndTask removeNthFromEndTask = null;
    private RemoveNthFromEndTask()
    {

    }

    public static RemoveNthFromEndTask GetInstance()
    {
        if (removeNthFromEndTask == null)
        {
            return new RemoveNthFromEndTask();
        }
        return removeNthFromEndTask;
    }

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
    public LeetCode.ListNode RemoveNthFromEnd(LeetCode.ListNode head, int n) {
        LeetCode.ListNode endFinder = head;
        LeetCode.ListNode removableTarget = head;
        LeetCode.ListNode nodeBeforeRemoval = head;
        int length = 1, decrementor = n;
        if (n == 1 && head.next == null)
        {
            return null;
        }
        while (endFinder.next != null)
        {
            endFinder = endFinder.next;
            if (decrementor <= 1)
            {
                removableTarget = removableTarget.next;
                if (decrementor <= 0)
                {
                    nodeBeforeRemoval = nodeBeforeRemoval.next;
                }
            }
            decrementor--;
            length++;
        }
        if (length == n)
        {
            return head.next;
        }
        if (Object.ReferenceEquals(nodeBeforeRemoval.next, removableTarget.next))
        {
            nodeBeforeRemoval.next = null;
        }
        else
        {
            nodeBeforeRemoval.next = removableTarget.next;
        }
        return head;
    }



}