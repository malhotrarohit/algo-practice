using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedListSort
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList ll = new SinglyLinkedList();
            Console.WriteLine("Enter the elements to be inserted in the linked list");
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                ll.Add(Convert.ToInt32(input));
            }

            ll.Sort();
        }
    }

    class Item
    {
        public int value;
        public Item next;
    }

    class SinglyLinkedList
    {
        private Item first;
        private Item last;
        private int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Add(int value)
        {
            if (first == null)
            {
                first = new Item();
                first.value = value;
                first.next = null;
                last = first;
                count++;
                return;
            }

            Item n = new Item();
            n.value = value;
            n.next = null;
            last.next = n;
            last = n;
            count++;

            return;
        }

        public Item Delete(int value)
        {
            if (count == 0)
            {
                throw new Exception("The list is empty!");
            }
            if (first.value == value)
            {
                Item node = first;
                first = first.next;
                count--;
                return node;
            }

            Item n = first;
            Item prev = n;
            while (n != null && n.value != value)
            {
                prev = n;
                n = n.next;
            }

            prev.next = n.next;
            count--;
            return n;
        }

        public Item Reverse()
        {
            if (count == 0)
            {
                throw new Exception("The list is empty!");
            }
            if (count == 1)
            {
                return first;
            }

            Item previous = null, present = first, next = first.next;
            last = first;
            while (present != null)
            {
                present.next = previous;
                previous = present;
                present = next;
                if (next != null)
                {
                    next = next.next;
                }
            }

            first = previous;
            return first;
        }

        public void Sort()
        {
            SortInternal(null, first, last);
        }

        private void SortInternal(Item prevFirst, Item first, Item last)
        {
            Item slow = first, fast = first;
            if (first != last)
            {
                while (fast != null && fast.next != last && fast != last)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }

                SortInternal(prevFirst, first, slow);
                SortInternal(slow, slow.next, last);
            }

            Merge(prevFirst,first, slow, last);
        }

        private void Merge(Item prevFirst, Item first, Item mid, Item last)
        {
            Item i = first, j = mid.next;
            Item prevI = prevFirst, prevJ = mid;
            while (i != mid.next && j != last.next)
            {
                if (i.value <= j.value)
                {
                    Item temp = i;
                    i = i.next;
                    prevJ.next = temp;
                    prevI.next = temp.next;
                    temp.next = j;
                    prevJ = temp;
                }
                else
                {
                    Item temp = j;
                    j = j.next;
                    prevI.next = temp;
                    prevJ.next = temp.next;
                    temp.next = i;
                    prevI = temp;
                }
            }
        }
    }
}
