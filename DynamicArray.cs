using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
Basic attempt for a Dynamic Array data structure.
Implemented all the basic methods, but would like to add more optional methods given time.
*/
namespace DataStructures
{
    class DynamicArray<Atype>
    {
        //Instance variables for both the array we'll use and the length.
        private Atype[] darr;
        private int length { get; set; }

        //initializing the first instance of length of our array.
        //Three constructors (idea from Donze's code for double linked lists)
        public DynamicArray()
        {
            darr = Array.Empty<Atype>();
        }

        public DynamicArray(int len)
        {
            darr = new Atype[len];
            length = len;
        }

        public DynamicArray(IEnumerable<Atype> enumerable)
        {
            darr = enumerable.ToArray();
            length = enumerable.Count();

        }

        //A getter for our dynamic array value at a zero-indexed position.
        public Atype Get(int pos)
        {
            return darr[pos];
        }

        //Our add method, but with a recursive call to reduce memory usage.
        public void Add(Atype item, int pos)
        {
            if (darr.Length == 0)
            {
                darr = new Atype[1];
                length++;
            }

            //if the add call is outside our bounds, we tell our user to try again and return early.
            if (pos < 0 || pos > length)
            {
                Console.WriteLine("Out of array bounds! Try changing your bounds to properly add your value.");
                //throw new IndexOutOfRangeException("Out of array bounds! Try changing your bounds to properly add your value.");
                return;
            }


            //else, we do a "check" of sorts; if the value in our array at position pos is equal to the default value of T we set the value to what our user wanted.
            //or simply: if the value at pos in the array is the default null value, then we swap.
            if (object.Equals(darr[pos], default(Atype)))
            {
                darr[pos] = item;
                return;
            }


            //but if it isn't null; we need to make some space.
            //call the sizeup method, then recall the add method to continuously call this method until a free spot appears.
            else
            {
                SizeUp(pos, length);
                Add(item, pos);
            }

        }

        //Our size up method. (technically a shiftup method, but it works the same in how I used it.)
        public void SizeUp(int pivot, int end)
        {
            //created a new array of the current length but plus 1, and update our global with the same value. 
            Atype[] newArr = new Atype[length + 1];
            length++;


            //copy the terms from the pivot to our current "pivot" to the new array in the same position/a position up if they're past the pivot.
            for (int i = 0; i <= end; i++)
            {
                Atype temp = default(Atype);

                if (i < pivot)
                {
                    temp = darr[i];
                }
                if (i > pivot)
                {
                    temp = darr[i - 1];
                }

                newArr[i] = temp;
            }


            //then, make the old arr point to the new array. The GC of CS will handle removing the old array.
            //(I'd rather have a deliberate removal statement, but I can't seem to find it on C#'s docs)
            darr = newArr;
        }

        //Our size down  method. (technically a shiftdown method, but it works the same in how I used it.)
        public void SizeDown(int pivot, int end)
        {
            //created a new array of the current length but minus 1, and update our global with the same value. 
            Atype[] newArr = new Atype[length - 1];
            length--;

            //Similar to the SizeUp method, but instead we change the if statements to include the pivot position instead.
            //Additionally, from the pivot to the end position, the newArr value needs to be shifted up from darr.
            for (int i = 0; i < end - 1; i++)
            {
                Atype temp = default(Atype);

                if (i < pivot)
                {
                    temp = darr[i];
                }
                if (i >= pivot)
                {
                    temp = darr[i + 1];
                }

                newArr[i] = temp;
            }
            darr = newArr;

        }

        //Setting method... setting method. Kind of straight forward; check bounds, then set arr[pos] the T val.
        public Atype? Set(Atype val, int pos)
        {

            if (pos < 0 || pos > length)
            {
                Console.WriteLine("Out of array bounds! Try changing your position to set a value in this array.");
                //throw new IndexOutOfRangeException("Out of array bounds! Try changing your bounds to properly set your value.");
                return default(Atype);
            }
            else
            {

                Atype temp = darr[pos];
                darr[pos] = val;
                return temp;
            }

        }

        //Printing statement.. printing statement.
        public string printArray()
        {
            string list = "[";
            for (int i = 0; i < length; i++)
            {
                if (i != length - 1)
                {
                    list += darr[i] + ", ";
                }
                else
                {
                    list += darr[i] + "]";
                }
            }
            return list;
        }

        //Remove method, similar to our add method but... the inverse.
        public Atype? Remove(int pos)
        {
            //Console.WriteLine(Get(pos));
            if (darr.Length == 0)
            {
                Console.WriteLine("No array to delete values from!");

                return default(Atype);
            }

            if (pos < 0 || pos > length)
            {
                Console.WriteLine("Out of array bounds! Try changing your position to remove a value in this array.");
                //throw new IndexOutOfRangeException("Out of array bounds! Try changing your bounds to properly remove your value.");
                return default(Atype);

            }
            else
            {

                Atype temp = darr[pos];
                SizeDown(pos, length);

                return temp;
            }
        }


        public int Size()
        {
          /*  int size = 0;
            for (int i = 0; i < length; i++)
            {
                Atype temp = darr[i];
                if (temp != null)
                {
                    size++;
                }

            }*/
            return darr.Length;
        }

    }
}

