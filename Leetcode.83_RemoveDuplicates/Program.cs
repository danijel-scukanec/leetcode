namespace Leetcode._83_RemoveDuplicates
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
            DeleteDuplicates(new ListNode(1, new ListNode(1, new ListNode(2, null))));
            DeleteDuplicates(new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3, null))))));
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var currentPointer = head;
            while (currentPointer != null)
            {
                var nextPointer = currentPointer.next;
                while(nextPointer != null && currentPointer.val == nextPointer.val)
                {
                    nextPointer = nextPointer.next;
                }

                currentPointer.next = nextPointer;
                currentPointer = nextPointer;
            }

            return head;
        }
    }
}
