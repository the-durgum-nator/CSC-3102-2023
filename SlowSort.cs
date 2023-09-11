using System;

namespace DataStructures
{
    public class InsertionSort
    {
        public void sort(int[] list)
        {
            printArray(list);
            Console.WriteLine("Sorting (via insertion sort)!");
            for (int i = 0; i < list.Length; i++)
            {
                int leftMost = list[i];
                int j = i - 1;
                while (j >= 0 && list[j] > leftMost)
                {
                    list[j + 1] = list[j];
                    j -= 1;
                }
                list[j + 1] = leftMost;
            }
            printArray(list);
        }
    
        private void printArray(int[] list)
        {
            string str = "[";
            for (int i = 0; i < list.Length; i++)
            {
                if (i != list.Length - 1)
                {
                    str += list[i] + ", ";
                }
                else
                {
                    str += list[i] + "]";
                }
            }
            Console.WriteLine(str);
        }
    
    
    }
}

