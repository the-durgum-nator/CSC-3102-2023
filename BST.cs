using System;
using System.Xml.Linq;

namespace DataStructures
{

    public class BinarySearchTree
    {
        public class BTreeNode : GeneralNode<int>
        {
            public BTreeNode? left, right, parent;

            public BTreeNode(int val) : base(val)
            {
                left = null;
                right = null;
                parent = null;
            }

            public override string ToString()
            {
                return "" + Data;
            }


        }

        public BTreeNode? root = null;
        public BinarySearchTree(int val)
        {
            root = new BTreeNode(val);
        }

        //Has method, has method.
        //Calls a recursive function to check the node's validity.
        public bool Has(int val)
        {
            if (FindNode(root, val) != null)
            {
                return true;
            }
            return false;
        }

        //self explanatory recursive method.
        private BTreeNode? FindNode(BTreeNode? node, int val)
        {

            if (node.Data == val)
            {
                return node;
            }

            if (val > node.Data)
            {
                return FindNode(node.right, val);
            }

            if (val < node.Data)
            {
                return FindNode(node.left, val);
            }

            return null;
        }


        //Add method that calls a recursive method.
        public void Add(int val)
        {
            BTreeAdd(root, val);
        }

        //Similar to the FindNode-Has method relation, pretty simple.
        private BTreeNode BTreeAdd(BTreeNode? current, int val)
        {
            if (current == null)
            {
                return new BTreeNode(val);
            }

            if (val < current.Data)
            {
                current.left = BTreeAdd(current.left, val);
            }
            else
            {
                current.right = BTreeAdd(current.right, val);
            }
            return current;

            /*  if (val > current.Data)
              {
                  if (current.right == null)
                  {
                      var temp = new BTreeNode(val);
                      temp.parent = current;
                      current.right = temp;
                  }
                  else
                  {
                      BTreeAdd(current.right, val);
                  }
              }
              else if (val < current.Data)
              {
                  if (current.left == null)
                  {
                      var temp = new BTreeNode(val);
                      temp.parent = current;
                      current.left = temp;

                  }
                  else
                  {
                      BTreeAdd(current.left, val);
                  }
              }
              else
              {
                  Console.WriteLine("Duplicate value!");
              }*/
        }

        //I feel like I've done this before, like twice so far!
        //Remove method that calls a recursive method and returns the data from the returned node 
        public int? Remove(int val)
        {

            return BTreeRemove(root, val).Data;
        }

        public BTreeNode BTreeRemove(BTreeNode? current, int val)
        {
            //First, find the node in question.
            var nuke = FindNode(root, val);

            //No children nodes situation
            if (nuke.left == null && nuke.right == null)
            {
                if (nuke.parent == null)
                {
                    root = null;
                }
                else if (nuke.parent.left == nuke)
                {
                    nuke.parent.left = null;
                }
                else
                {
                    nuke.parent.right = null;
                }
                return nuke;
            }
            //One children node situation
            else if (nuke.left == null || nuke.right == null)
            {
                BTreeNode child;
                if (nuke.right != null)
                {
                    child = nuke.right;
                }
                else
                {
                    child = nuke.left;
                }

                if (child.parent == null)
                {
                    root = child;
                }

                child.parent = nuke.parent;
                return nuke;
            }
            //Two children node situation
            else
            {
                //find successor 
                BTreeNode succ = findSuccessor(nuke);

                //update the child's stuff using the remove mehtod.
                var temp = BTreeRemove(succ, succ.Data);

                if (nuke.parent == null)
                {
                    root = succ;
                }
                else if (nuke.parent.left == nuke)
                {
                    nuke.parent.left = succ;
                }
                else
                {
                    nuke.parent.right = succ;
                }

                //updating the successor's and nuked node's relations.
                succ.parent = nuke.parent;

                succ.left = nuke.left;
                nuke.left.parent = succ;

                succ.right = nuke.right;
                if (nuke.right != null)
                {
                    nuke.right.parent = succ;
                }

                return nuke;

            }
        }


        private BTreeNode findSuccessor(BTreeNode curr)
        {
            while (curr.left != null)
            {

                curr = curr.left;
            }
            return curr;

        }

        //height finder method.
        public int Height()
        {
            return BTreeHeight(root);

        }




        //method to find method, recursively calls itself to get height of previous nodes.
        public int BTreeHeight(BTreeNode? curr)
        {
            //Console.WriteLine(curr.ToString());
            if (curr == null) return 0;

            return 1 + Math.Max(BTreeHeight(curr.left), BTreeHeight(curr.right));
        }

        //ToString method prints out breadth-first wise; null is considered 0 here.
        public override String ToString()
        {
            Queue<BTreeNode> search = new Queue<BTreeNode>();

            String str = "BST:\n";


            search.Enqueue(root);

            int iter = 1;
            while (!search.isEmpty())
            {
                iter--;
                if (iter >= 0)
                {
                    str += "Root Value: ";
                }
                else
                {
                    str += "Parent Value: ";
                }

                var temp = search.Dequeue();


                if (temp.left != null)
                {
                    search.Enqueue(temp.left);

                }


                if (temp.right != null)
                {
                    search.Enqueue(temp.right);

                }

                int leftVal = temp.left != null ? temp.left.Data : 0;
                int rightVal = temp.right != null ? temp.right.Data : 0;


                str += temp.Data + ", Left Child Value: " + leftVal + ", Right Child Value: " + rightVal + "\n";
            }
            return str;

        }

    }

}