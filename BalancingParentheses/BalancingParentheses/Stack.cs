using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancingParentheses
{
    class Item {
            public int value;
            public Item previous;
        }
    class Stack
    {
        private Item top;

        public bool Empty
        {
            get
            {
                if (top == null) return true;
                else { return false; }
            }
        }

        public void Push(int n)
        {
            if (top == null)
            {
                top = new Item();
                top.value = n;
                top.previous = null;
                return;
            }
            Item i = new Item();
            i.value = n;
            i.previous = top;
            top = i;

            return;
        }

        public int Pop()
        {
            if (top == null)
            {
                throw new Exception("The stack is empty!");
            }

            int n = top.value;
            top = top.previous;
            return n;
        }
    }
}
