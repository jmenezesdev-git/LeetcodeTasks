// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LeetCode{
    
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }

    class LeetCodeTasks
    {
        static int Main(string[] args)
        {

            //IsPalindrome Task
            //IsPalindromeTask();

            //Roman to Integer Task Block
            {
                // string romanToIntVal = "XVII";
                // Console.WriteLine(romanToIntVal + " is equal to the number " + RomanToInt(romanToIntVal));
                // romanToIntVal = "III";
                // Console.WriteLine(romanToIntVal + " is equal to the number " + RomanToInt(romanToIntVal));
                // romanToIntVal = "LVIII";
                // Console.WriteLine(romanToIntVal + " is equal to the number " + RomanToInt(romanToIntVal));
                // romanToIntVal = "MCMXCIV";
                // Console.WriteLine(romanToIntVal + " is equal to the number " + RomanToInt(romanToIntVal));
            }

            //Longest Common Prefix Task Block
            {
                // string[] strs = ["flower", "flow", "flight"];
                // Console.WriteLine("The longest common prefix of " + strs + " is \"" + LongestCommonPrefix(strs) + "\"");
                // strs = ["dog", "racecar", "car"];
                // Console.WriteLine("The longest common prefix of " + strs + " is \"" + LongestCommonPrefix(strs) + "\"");

            }

            //Add Two Numbers Task
            //AddTwoNumbersTask();



            //Alphabetic Order Task
            //IsAlphabeticTask(); 


            // Twins Task
            //TwinsTask();

            //Digits Sum Task
            //DigitsSumTask();

            //Remove Element Task
            //RemoveElementTask removeE = RemoveElementTask.GetInstance();
            //Console.WriteLine("After removing 3 from 3,2,2,3 the length of the remaining array is are " + removeE.RemoveElement([3,2,2,3], 3));

            //Reverse Integer Task
            ReverseIntegerTask reverseInt = ReverseIntegerTask.GetInstance();
            Console.WriteLine("The reversse of 1534236469 is " + reverseInt.Reverse(1534236469));
            return 0;
        }

        public static void IsPalindromeTask()
        {
            int firstVal = 10;
            Console.WriteLine("IsPalindrome " + firstVal + " returns " + IsPalindrome(firstVal));
            firstVal = 121;
            Console.WriteLine("IsPalindrome " + firstVal + " returns " + IsPalindrome(firstVal));
            firstVal = -121;
            Console.WriteLine("IsPalindrome " + firstVal + " returns " + IsPalindrome(firstVal));
         }

        public static void AddTwoNumbersTask()
        {
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));
            Console.Write("The sum of 243 and 564 is ");
            PrintChain(AddTwoNumbers(l1, l2));


            l1 = new ListNode(2, new ListNode(4, new ListNode(9, null)));
            l2 = new ListNode(5, new ListNode(6, new ListNode(4, new ListNode(9, null))));
            Console.WriteLine("The sum of 249 and 5649 is ");
            AddTwoNumbers(l1, l2);
            l1 = new ListNode(0, null);
            l2 = new ListNode(0, null);
            Console.WriteLine("The sum of 243 and 564 is " + AddTwoNumbers(l1, l2));
        }

        public static void IsAlphabeticTask()
        {
            string[] input;
            string inputSting = (Console.ReadLine());


            int result = funcAlphabeticOrder(inputSting);
            Console.Write(result);
        }
        public static void TwinsTask()
        {
            string[] input;
            //input for inputArr
            int inputArr_size = int.Parse(Console.ReadLine());
            int[] inputArr = new int[inputArr_size];
            input = Console.ReadLine().Split(' ');
            for (int idx = 0; idx < inputArr_size; idx++)
            {
                inputArr[idx] = int.Parse(input[idx]);
            }
            funcTwins(inputArr);

        }
        public static void DigitsSumTask()
        {
            string[] input;
            //input for inputNum1
            int inputNum1 = int.Parse(Console.ReadLine());

            //input for inputNum2
            int inputNum2 = int.Parse(Console.ReadLine());



            funcCount(inputNum1, inputNum2);

        }

        public static void funcCount(int inputNum1, int inputNum2)
        {
            // Write your code here
            int totalResults = 0;
            for (int i = 0; i <= inputNum1; i++)
            {
                int intermediaryNumber = i;
                int sotdInt = 0;
                while (intermediaryNumber > 0 && sotdInt < inputNum2)
                {
                    sotdInt += intermediaryNumber % 10;
                    intermediaryNumber = intermediaryNumber / 10;
                }
                if (intermediaryNumber == 0 && sotdInt == inputNum2)
                {
                    Console.WriteLine("tempNumber: " + i + " works.");
                    totalResults++;
                }
                if (sotdInt > inputNum2)
                {
                    if (i % 10 != 0)
                    {
                        i = Convert.ToInt32(Math.Round(Convert.ToDecimal(i) / Convert.ToDecimal(10), 0, MidpointRounding.ToPositiveInfinity) * 10) - 1;
                    }
                }
            }
            if (totalResults == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(totalResults);
            }
        }

        public static void funcTwins(int[] inputArr)
        {
            // Write your code here
            int lowestNonTwin = -1;

            for (int i = 0; i <= inputArr.Length - 1; i++)
            {
                bool isTwin = false;
                for (int j = 0; j <= inputArr.Length - 1; j++)
                {
                    if (i != j && inputArr[i] == inputArr[j])
                    {
                        isTwin = true;
                    }
                }
                if (isTwin == false)
                {
                    if (lowestNonTwin == -1 || lowestNonTwin > inputArr[i])
                    {
                        lowestNonTwin = inputArr[i];
                    }
                }

            }

            Console.WriteLine(lowestNonTwin);

        }

        public static int funcAlphabeticOrder(string inputSting)
        {
            int answer = 0;

            // Write your code here
            int maxVal = 0;
            for (int i = 0; i <= inputSting.Length - 1; i++)
            {
                char c = inputSting[i];
                int compareInt = c - 'a';
                if (maxVal == 0)
                {
                    maxVal = compareInt;
                }
                else if (maxVal > compareInt)
                {
                    return i;
                }
                else
                {
                    maxVal = compareInt;
                }
            }

            return answer;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Console.WriteLine("Default lists:");
            PrintChain(l1);
            PrintChain(l2);
            ListNode sumNode = AddChain(new List<ListNode> { l1, l2 });
            PrintChain(sumNode);
            return sumNode;
        }

        public static ListNode AddChain(List<ListNode> listNodes)
        {
            int sumVal = 0;
            int overflowVal = 0;
            List<ListNode> newListNode = new List<ListNode>();
            foreach (ListNode node in listNodes)
            {
                sumVal += node.val;
                if (node.next != null)
                {
                    newListNode.Add(node.next);    
                }
            }
            overflowVal = sumVal / 10;
            sumVal = sumVal % 10;
            if (overflowVal > 0)
            {
                newListNode.Add(new ListNode(overflowVal, null));
            }
            if (newListNode.Count > 0)
            {
                return new ListNode(sumVal, AddChain(newListNode));
            }
            else
            {
                return new ListNode(sumVal, null);
            }

        }

        public static void PrintChain(ListNode list)
        {
            Console.Write(list.val);
            if (list.next != null)
            {
                PrintChain(list.next);
                return;
            }
            Console.Write("\n");
        }



        public static ListNode ReverseList(ListNode list)
        {

            if (list.next == null)
            {
                //List<int> newList = ;
                return new ListNode(list.val, null);
            }
            else
            {
                ListNode l = ReverseList(list.next);
                if (l.next == null)
                {
                    l.next = new ListNode(list.val, null);
                }
                else
                {
                    ListNode tempL = l;
                    while (tempL.next != null)
                    {
                        tempL = tempL.next;
                    }
                    tempL.next = new ListNode(list.val, null);
                }
                return  l;
            }
        }


        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length < 1)
            {
                return "";
            }
            else if (strs.Length == 1)
            {
                return strs[0];
            }
            else
            {
                string commonPrefix = "";
                for (int i = 0; i <= strs[0].Length - 1; i++)
                {
                    Console.WriteLine(strs[0][i]);
                    for (int j = 1; j <= strs.Length - 1; j++)
                    {
                        string s = strs[j];
                        if (i == s.Length)
                        {
                            return commonPrefix;
                        }
                        else if (strs[0][i] != s[i])
                        {
                            return commonPrefix;
                        }
                    }
                    commonPrefix += strs[0][i];

                }
                return commonPrefix;
            }
        }

        public static int RomanToInt(string s)
        {
            int mainIterator = 0;
            int previousCharValue = 9999;
            int outputValue = 0;
            while (mainIterator <= s.Length - 1)
            {
                int currentCharVal = getCharValue(s[mainIterator]);
                if (currentCharVal > 0)
                {
                    if (currentCharVal <= previousCharValue)
                    {
                        outputValue += currentCharVal;
                    }
                    else
                    {
                        outputValue = outputValue + currentCharVal - (2 * previousCharValue);
                    }
                }

                previousCharValue = currentCharVal;
                mainIterator++;
            }
            return outputValue;
        }

        public static int getCharValue(char c)
        {
            switch (c)
            {
                case 'M':
                    return 1000;
                case 'D':
                    return 500;
                case 'C':
                    return 100;
                case 'L':
                    return 50;
                case 'X':
                    return 10;
                case 'V':
                    return 5;
                case 'I':
                    return 1;
                default:
                    return 0;
            }

        }

        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            { //Checking for negative numbers first to save time
                return false;
            }
            else
            {
                string inputString = x.ToString();
                int increasingIterator = 0;
                int decreasingIterator = inputString.Length - 1;
                while (decreasingIterator >= 0)
                {
                    if (inputString[increasingIterator] != inputString[decreasingIterator])
                    {
                        Console.WriteLine(inputString[increasingIterator] + " is not equal to " + inputString[decreasingIterator]);
                        return false;
                    }
                    decreasingIterator--;
                    increasingIterator++;
                }
                return true;
            }
        }


    }

}

