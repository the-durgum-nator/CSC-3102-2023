using System;
using System.Xml.Linq;

namespace DataStructures
{
    public class AVL : BinarySearchTree
    {
        public class TreeNode : BTreeNode
        {
            public new TreeNode? left, right, parent;
            public int height;

            public TreeNode(int val) : base(val)
            {
                left = right = parent = null;
               
            }


            public override string ToString()
            {
                return "" + Data;
            }

        }

        //redo everything from BST in terms of AVLs

        public new TreeNode? root;

        public AVL(int val) : base(val)
        {
            root = new TreeNode(val);
        }

      




    }




}
