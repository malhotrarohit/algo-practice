using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseLinkedList
{
    class Item 
    {
       public object value;
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

        public void Add(object value)
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

        public Item Delete(object value)
        {
            if(count == 0)
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
    }
}
