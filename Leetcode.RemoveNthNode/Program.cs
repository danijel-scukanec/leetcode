using System;
using System.Collections.Generic;

namespace Leetcode.RemoveNthNodeFromEnd
{
    class Program
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

        static void Main(string[] args)
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))));
            RemoveNthFromEnd(head, 2);
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null)
            {
                return null;
            }

            var dictionary = new Dictionary<int, ListNode>();

            var currentNodeIndex = 0;
            var currentNode = head;
            dictionary.Add(currentNodeIndex, currentNode);

            while (currentNode.next != null)
            {
                currentNodeIndex++;
                currentNode = currentNode.next;
                dictionary.Add(currentNodeIndex, currentNode);
            }

            var nodeToDeleteIndex = currentNodeIndex - n + 1;
            ListNode nodeToDelete = dictionary[nodeToDeleteIndex];

            if (nodeToDeleteIndex == 0)
            {
                nodeToDelete.next = null;
                return dictionary[nodeToDeleteIndex + 1];
            }
            else if (nodeToDeleteIndex == currentNodeIndex)
            {
                ListNode nodeBeforeDeleted = dictionary[nodeToDeleteIndex - 1];
                nodeBeforeDeleted.next = null;
                return dictionary[0];
            }
            else
            {
                ListNode nodeBeforeDeleted = dictionary[nodeToDeleteIndex - 1];
                nodeBeforeDeleted.next = nodeToDelete.next;
                nodeToDelete.next = null;
                return dictionary[0];
            }
        }
    }
}
