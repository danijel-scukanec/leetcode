using System;

namespace Leetcode._2_AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));
            var result = AddTwoNumbers(l1, l2);
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode currentNodeL1 = l1;
            ListNode currentNodeL2 = l2;

            ListNode resultNode = null;
            ListNode currentResultNode = null;

            int remainder = 0;

            while (currentNodeL1 != null || currentNodeL2 != null)
            {
                int number1 = 0;
                int number2 = 0;

                if (currentNodeL1 != null)
                {
                    number1 = currentNodeL1.val;
                    currentNodeL1 = currentNodeL1.next;
                }

                if (currentNodeL2 != null)
                {
                    number2 = currentNodeL2.val;
                    currentNodeL2 = currentNodeL2.next;
                }

                int sum = number1 + number2 + remainder;
                if (sum <= 9)
                {
                    remainder = 0;
                }
                else
                {
                    sum %= 10;
                    remainder = 1;
                }
                                
                if(resultNode == null)
                {
                    resultNode = new ListNode(sum, null);
                    currentResultNode = resultNode;
                }
                else
                {
                    currentResultNode.next = new ListNode(sum, null);
                    currentResultNode = currentResultNode.next;
                }
            }

            if(remainder == 1)
            {
                currentResultNode.next = new ListNode(remainder, null);
            }

            return resultNode;
        }
    }
}
