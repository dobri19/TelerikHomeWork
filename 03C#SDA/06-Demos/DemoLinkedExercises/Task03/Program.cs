using System;

namespace Task03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            ListNode second = new ListNode(2);
            ListNode third = new ListNode(3);
            ListNode fourth = new ListNode(4);

            Console.WriteLine(head.val);
            Console.WriteLine(second.val);
            Console.WriteLine(third.val);
            Console.WriteLine(fourth.val);

            head.next = second;
            second.next = third;
            third.next = fourth;

            ListNode prev = null;
            ListNode current = head;
            //ListNode next = current.next;
            ListNode pointer = current.next;

            while (pointer != null)
            {
                current.next = prev;
                prev = current;
                current = pointer;
                pointer = current.next;
            }
            current.next = prev;
            head = current;
            pointer = head;

            while (pointer != null)
            {
                Console.WriteLine(pointer.val);
                pointer = pointer.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
