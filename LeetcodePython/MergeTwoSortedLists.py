# Definition for singly-linked list.
from typing import Optional


class ListNode:
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next
class Solution:
    def mergeTwoLists(list1: Optional[ListNode], list2: Optional[ListNode]) -> Optional[ListNode]:
        newHead = None
        iteratorHead = None
        while list1 != None or list2 != None:
            if list1 != None and list2 != None:
                if list1.val <= list2.val:
                    if newHead == None:
                        newHead = ListNode(list1.val, None)
                        iteratorHead = newHead
                    else:
                        iteratorHead.next = ListNode(list1.val, None)
                        iteratorHead = iteratorHead.next
                    list1 = list1.next
                else:
                    if newHead == None:
                        newHead = ListNode(list2.val, None)
                        iteratorHead = newHead
                    else:
                        iteratorHead.next = ListNode(list2.val, None)
                        iteratorHead = iteratorHead.next
                    list2 = list2.next

            elif list1 != None:
                if newHead == None:
                    newHead = ListNode(list1.val, None)
                    iteratorHead = newHead
                else:
                    iteratorHead.next = ListNode(list1.val, None)
                    iteratorHead = iteratorHead.next
                list1 = list1.next
            elif list2 != None:
                if newHead == None:
                    newHead = ListNode(list2.val, None)
                    iteratorHead = newHead
                else:
                    iteratorHead.next = ListNode(list2.val, None)
                    iteratorHead = iteratorHead.next
                list2 = list2.next
        return newHead

    def printList(list1: Optional[ListNode]):
        while list1 != None:
            print(list1.val)
            list1 = list1.next
        print("\n")

    if __name__ == "__main__":
        #newHead = mergeTwoLists(ListNode(1, ListNode(2, ListNode(4, None))), ListNode(1, ListNode(3, ListNode(4, None))))
        #printList(newHead)

        
        #newHead = mergeTwoLists(None, None)
        #printList(newHead)

        
        newHead = mergeTwoLists(None, ListNode(0, None))
        printList(newHead)