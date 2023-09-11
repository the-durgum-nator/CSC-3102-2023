using System;

namespace DataStructures
{
    //A simple queue class based off a Dynamic Array.
    public class Queue<Qtype>
    {
        //Instance variable; instance variable.
        private DynamicArray<Qtype> dynamicArray;

        //Two constructors to handle null parameters and custom lengths.
        public Queue()
        {
            dynamicArray = new DynamicArray<Qtype>();
        }

        public Queue(int len)
        {
            dynamicArray = new DynamicArray<Qtype>(len);
        }

        //Enqueue method using the leftmost index as our back.
        public void Enqueue(Qtype value)
        {
            dynamicArray.Add(value, 0);
        }

        //Dequeue method referring to the rightmost index as our front.
        public Qtype? Dequeue()
        {
            int length = dynamicArray.Size();
            if (length == 0)
            {
                //Console.WriteLine("Empty Queue to work off of, try adding some more values to the queue!");
                return default;
            }

            Qtype value = dynamicArray.Remove(length - 1);
            return value;

        }

        //Peek method... it's a peek method!
        public Qtype Peek()
        {
            return dynamicArray.Get(dynamicArray.Size() - 1);
        }

        //Same stuff for the "toString" method as Stack, but (v)s instead of (^)s.
        public override String ToString()
        {
            int length = dynamicArray.Size();
            string str = "";

            for (int i = 0; i < length; i++)
            {
                str += "(" + dynamicArray.Get(i) + ")";

                if (i < length - 1)
                {
                    str += " v ";
                }

            }
            return str;
        }

        //Size method... yeah!
        public int Size()
        {
            return dynamicArray.Size();
        }

        //____
        //get it? it's a "isEmpty" comment..? 
        public bool isEmpty()
        {
            return dynamicArray.Size() == 0;
        }

        //A peekahead method from a front of the line to a position of user-given amount back.
        //Haven't properly tested this but it seems like it'll work. ¯\_(ツ)_/¯
        public Qtype PeekAhead(int num)
        {
            int len = dynamicArray.Size();

            return dynamicArray.Get(len - num);
        }
    }



}