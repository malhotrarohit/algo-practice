using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose from the following options -");
            Console.WriteLine("1. Insert an integer");
            Console.WriteLine("2. Delete an integer");
            Console.WriteLine("3. Preorder Traversal");
            Console.WriteLine("4. Inorder Traversal");
            Console.WriteLine("5. Postorder Traversal");
            Console.WriteLine("6. Exit");

            AVL tree = new AVL();
            string input = "";
            while ((input = Console.ReadLine()) != "6")
            {
                switch (input)
                {
                    case "1": Insert(tree);
                        break;

                    case "2": Delete(tree);
                        break;

                    case "3": Preorder(tree);
                        break;

                    case "4": Inorder(tree);
                        break;

                    case "5": Postorder(tree);
                        break;
                }
            }
        }

        private static void Insert(AVL tree)
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

        private static void Delete(AVL tree)
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

        private static void Preorder(AVL tree)
        {
            try
            {
                tree.Preorder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private static void Inorder(AVL tree)
        {
            try
            {
                tree.Inorder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Postorder(AVL tree)
        {
            try
            {
                tree.Postorder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
