
using System;

namespace DataStructures
{

    public class Stack<Stype>
    {
        DynamicArray<Stype> dynamicArray;
        public Stack()
        {
            dynamicArray = new DynamicArray<Stype>();
        }

        public Stack(int len)
        {
            dynamicArray = new DynamicArray<Stype>(len);

        }

        public void Push(Stype value)
        {
            dynamicArray.Add(value, 0);
        }

        public Stype Pop()
        {
            if (dynamicArray.Size() == 0)
            {
                Console.WriteLine("Empty Stack to work off of, try adding some more values to the stack!");
                return default(Stype);
            }
            Stype value = dynamicArray.Remove(0);
            return value;

        }

        public Stype Peek()
        {
            return dynamicArray.Get(0);
        }

        public override String ToString()
        {
            string str = "";
            int length = dynamicArray.Size();

            for (int i = 0; i < length; i++)
            {
                str += "(" + dynamicArray.Get(i) + ")";

                if (i < length - 1)
                {
                    str += " ^ ";
                }

            }
            return str;
        }

        public int Size()
        {
            return dynamicArray.Size();
        }

        public bool isEmpty()
        {
            return dynamicArray.Size() == 0;
        }

    }










}
