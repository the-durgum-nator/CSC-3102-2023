using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    internal class Program
    {

        //The Program file is the "test-bench" of what I do to test my code.
        //Feel free to paste anything in here.
        static void Main(string[] args)
        {
            AVL bst = new AVL(3);
            bst.Add(4);
            

            Console.WriteLine(bst.BTreeHeight(bst.root));

            //Console.WriteLine(bst.root.height);

            //Console.WriteLine(bst.root + "_" + bst.root.left + "_" + bst.root.right);

            //bst.updateHeight(bst.root.right);
           
        }
    }
}