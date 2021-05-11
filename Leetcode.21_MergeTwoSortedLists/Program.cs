using System;

namespace Leetcode._21_MergeTwoSortedLists
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
            var l1 = new ListNode(1, new ListNode(2, new ListNode(4, null)));
            var l2 = new ListNode(1, new ListNode(3, new ListNode(4, null)));

            MergeTwoLists_3(l1, l2);
        }

        public static ListNode MergeTwoLists_1(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            if (l1 == null && l2 != null)
            {
                return l2;
            }

            if (l1 != null && l2 == null)
            {
                return l1;
            }

            ListNode firstListPointer = l1;
            ListNode secondListPointer = l2;
            ListNode mergedListPointer = null;
            ListNode mergedListHeadPointer = null;

            while (firstListPointer != null || secondListPointer != null)
            {
                ListNode newNode = null;

                if (secondListPointer == null || (firstListPointer != null && firstListPointer.val <= secondListPointer.val))
                {
                    newNode = new ListNode(firstListPointer.val, null);
                    firstListPointer = firstListPointer.next;
                }
                else
                {
                    newNode = new ListNode(secondListPointer.val, null);
                    secondListPointer = secondListPointer.next;
                }

                if (mergedListHeadPointer == null)
                {
                    mergedListHeadPointer = newNode;
                    mergedListPointer = newNode;
                }
                else
                {
                    mergedListPointer.next = newNode;
                    mergedListPointer = mergedListPointer.next;
                }
            }

            return mergedListHeadPointer;
        }

        public static ListNode MergeTwoLists_2(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            if (l1 == null && l2 != null)
            {
                return l2;
            }

            if (l1 != null && l2 == null)
            {
                return l1;
            }

            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists_2(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists_2(l1, l2.next);
                return l2;
            }
        }

        public static ListNode MergeTwoLists_3(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            if (l1 == null && l2 != null)
            {
                return l2;
            }

            if (l1 != null && l2 == null)
            {
                return l1;
            }

            ListNode firstListPointer = l1;
            ListNode secondListPointer = l2;

            ListNode prehead = new ListNode(-1, null);
            ListNode mergedListPointer = prehead;

            while (firstListPointer != null || secondListPointer != null)
            {
                if (secondListPointer == null || firstListPointer != null && firstListPointer.val <= secondListPointer.val)
                {
                    mergedListPointer.next = firstListPointer;
                    firstListPointer = firstListPointer.next;
                }
                else
                {
                    mergedListPointer.next = secondListPointer;
                    secondListPointer = secondListPointer.next;
                }

                mergedListPointer = mergedListPointer.next;
            }

            return prehead.next;
        }

    }
}
