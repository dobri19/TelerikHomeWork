using System;
using System.Collections.Generic;

namespace Task02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //LinkedList<int> linked = new LinkedList<int>();
            ListNode first = new ListNode(1);
            ListNode second = new ListNode(2);
            first.next = second;
            ListNode third = new ListNode(3);
            second.next = third;
            ListNode forth = new ListNode(4);
            third.next = forth;

            var node = first;
            RemoveNode(third);
            while (node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }
        }

        public static void RemoveNode(ListNode zzz)
        {
            //if (zzz.next == null)
            //{
            //    zzz.val = null;
            //}
            zzz.val = zzz.next.val;
            zzz.next = zzz.next.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
