using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace DataStructures
{

    //The data structure that makes my head hurt the most so far. (even without code implementation!)
    public class SinglyLinkedList<Ltype>
    {
        //Extension of the "GeneralNode" class for specific usage here, adding a pointer to the next node.
        internal class SLLNode<D> : GeneralNode<D>
        {
            public SLLNode<D>? next;

            public SLLNode(D val, SLLNode<D>? next = null) : base(val)
            {
                this.next = next;
            }

        }

        //Instance variables (would have added tail support, but didn't have time to focus on it)
        private SLLNode<Ltype>? head;///, tail;
        private int size;

        //Size getter...
        public int Size()
        {
            return size;
        }

        //Two constructors, handling null parameters + data for a head node.
        //Would have implemented the IEnumerable constructor like Donze did in his Doubly, but no time :(
        public SinglyLinkedList()
        {
            head = null;
            //tail = null;
            size = 0;
        }

        public SinglyLinkedList(Ltype data)
        {
            head = new SLLNode<Ltype>(data);
            //tail = head;
            size = 1;
        }

        /*
                public SinglyLinkedList(IEnumerable<Ltype> list)
                {
                    foreach (var item in list)
                    {
                        if (head == null)
                        {
                            head = new SLLNode<Ltype>(item);
                            break;
                        }

                       size++;
                    }
                }
        */


        //Add head method: make new node, make head pointer point to new node, and make new heads' next point to the old head's next. EASY.
        public void AddHead(Ltype item)
        {
            var temp = head;
            head = new SLLNode<Ltype>(item);
            head.next = temp;
            size++;
        }

        //Do the inverse of above; remove head method: remove pointer to old head + save data of old head, and promote head.next to our head.
        public Ltype RemoveHead()
        {
            var temp = head;
            head = head.next;
            size--;
            return temp.Data;
        }

        //Adding tail; traverse the list before the end; make current node's next point to a new node and boom. Tail added.
        public void AddTail(Ltype item)
        {
            var currentNode = head;

            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
            }
            size++;
            var newNode = new SLLNode<Ltype>(item);
            currentNode.next = newNode;

        }

        //Inverse of above; just save the data to return it tho.
        public Ltype RemoveTail()
        {
            var currentNode = head;
            while (currentNode.next.next != null)
            {
                currentNode = currentNode.next;
            }
            size--;
            var temp = currentNode.next;
            currentNode.next = null;
            return temp.Data;
          
        }

        //Before we get to the next two methods:
        //I  added logic to "round off" errors the user might do like addAt(#, 2) to be the same as just AddHead, same for AddTail. 
        //And also, I tend to throw Console messages instead of full blown exceptions, just for the sake of not killing the terminal preemptively.
        //Same goes for RemoveAt; I find that better user-wise than just throwing exceptions out and killing the terminal (at least in this case).
        //It's not hard for me to switch it out if given like 10 seconds, though; let me know if that's alright with you or not.

        //Add at method, pain.
        //If head's null/pos is <= 0; add a new Head; if pos is >= our list's size, add a tail
        //If not, traverse to the position given, and update the currentNode's next to a newNode, and then our newNode's next to the old currentNode's next.
        public void AddAt(Ltype item, int pos)
        {

            if (head == null)
            {
                AddHead(item);
            }

            if (pos <= 0)
            {
                Console.WriteLine("Your position is way out of bounds, but we'll add it as your head.");
                AddHead(item);
            }

            if (pos >= size)
            {
                AddTail(item);//add "rounding down" logic and prompt user with "fixing" their error.
            }

            var currentNode = head;
            SLLNode<Ltype> newNode = new SLLNode<Ltype>(item);
            for (int i = 0; i < pos - 1; i++)
            {
               
                currentNode = currentNode.next;
            }
            newNode.next = currentNode.next;
            currentNode.next = newNode;
            size++;

        }

        //As said about AddAt.
        //Remove anything <=0 or >= our list's size? removeHead/removeTail respectively.
        //If you remove anything in between the list; traverse to one before it, and update the currentNode's next to the node-to-remove's next.
        //Also return the node-to-remove data too.
        public Ltype RemoveAt(int pos)
        {
            if (head == null)
            {
                //add comment for "you need to add some values to the list"
                return default(Ltype);
            }
            if (pos <= 0)
            {
                return RemoveHead();
            }

            if (pos >= size)
            {
                return RemoveTail();
            }

            var currentNode = head;

            for (int i = 0; i < pos; i++)
            {
               
                currentNode = currentNode.next;
            }

            var value = currentNode.next;
            var temp = currentNode.next.next;
            currentNode.next = temp;
            size--;
            return value.Data;
        }

        public override string ToString()
        {
            string str = "";//"(" + head.Data + ")";
            var currentNode = head;
            while (currentNode != null)
            {

                str += "(" + currentNode.Data + ")";
                if (currentNode.next != null)
                {
                    str += " + ";
                }
                currentNode = currentNode.next;
            }

            return str;
        }

    }







}
