using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancedBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose from the following options -");
            Console.WriteLine("1. Insert an integer");
            Console.WriteLine("2. Delete an integer");
            Console.WriteLine("3. Re Balance the tree");
            Console.WriteLine("4. Preorder Traversal");
            Console.WriteLine("5. Inorder Traversal");
            Console.WriteLine("6. Postorder Traversal");
            Console.WriteLine("7. Find Kth smallest element");
            Console.WriteLine("8. Exit");

            BinarySearchTree tree = new BinarySearchTree();
            string input = "";
            while ((input = Console.ReadLine()) != "8")
            {
                switch (input)
                {
                    case "1": Insert(tree);
                              break;

                    case "2": Delete(tree);
                              break;

                    case "3": Balance(tree);
                              break;

                    case "4": PreOrder(tree);
                              break;

                    case "5": InOrder(tree);
                              break;

                    case "6": PostOrder(tree);
                              break;

                    case "7": KthSmallest(tree);
                              break;
                }
            }
        }

        private static void Insert(BinarySearchTree tree)
        {
            try
            {
                Console.WriteLine("Enter the integer to be inserted");
                string integer = Console.ReadLine();
                tree.Insert(Convert.ToInt32(integer));
                Console.WriteLine("The integer {0} was inserted succesfully", integer);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input is not a valid integer");
                return;
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Input is too big for an integer");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private static void Delete(BinarySearchTree tree)
        {
            try
            {
                Console.WriteLine("Enter the integer to be deleted");
                string integer = Console.ReadLine();
                tree.Delete(Convert.ToInt32(integer));
                Console.WriteLine("The integer {0} was deleted succesfully", integer);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input is not a valid integer");
                return;
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Input is too big for an integer");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private static void Balance(BinarySearchTree tree)
        {
            try{
            tree.BalanceTree();
            Console.WriteLine("The tree has been balanced succesfully with new root as {0}", tree.Root);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private static void PreOrder(BinarySearchTree tree)
        {
            try
            {
                tree.Preorder();
                tree.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private static void InOrder(BinarySearchTree tree)
        {
            try
            {
                tree.Inorder();
                tree.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PostOrder(BinarySearchTree tree)
        {
            try
            {
                tree.Postorder();
                tree.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void KthSmallest(BinarySearchTree tree)
        {
            Console.WriteLine("Write the rank of the number you want to find");
            string input = Console.ReadLine();
            Node n = tree.KthSmallest(Convert.ToInt32(input));
            if (n != null)
            {
                Console.WriteLine("The element you were looking for is {0}", n.item);
            }
            else
            {
                Console.WriteLine("The element you were looking for could not be found");
            }
        }
    }
}
