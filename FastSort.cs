using System;
using System.Security.Cryptography.X509Certificates;

namespace DataStructures
{
    //Still kind of wrapping my head around this but I mostly followed a guide to help me implement this.
    //Would like to redo this one with no int parameters for the sort, but idk how to do that yet.
    public class MergeSort{


        //Merge Sort: recursively calling a sort method until the array is broken up into subarrays that can't be broken further down
        //Then we merge those arrays while sorting them, until we reach the original array.. perfectly sorted.
        public static int[] sort(int[] list, int left, int right)
        {
            
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                int[] leftArr = sort(list, left, middle);
                int[] rightArr = sort(list, middle + 1, right);

                merge(list, left, middle, right);
            }

            return list;
         
        }

        //"All the merging magic" method.
        private static void merge(int[] arr, int left, int mid, int right)
        {
            //We make two lengths of our left and right arrays; adding one to left to combat zero-indexing.
            var leftLength = mid - left + 1;
            var rightLength = right - mid;

            //make ints for loops and new temp arrays.
            var leftTemp = new int[leftLength];
            var rightTemp = new int[rightLength];
            int i, j;

            //populate the arrays. add one to right to combat zero-indexing
            for (i = 0; i < leftLength; i++)
                leftTemp[i] = arr[left + i];
            for (j = 0; j < rightLength; j++)
                rightTemp[j] = arr[mid + 1 + j];
            
            //reset original ints, and add a new one for actually adding our elements into the "original" array.
            i = 0;
            j = 0;
            int arrPos = left;

            while (i < leftLength && j < rightLength)
            {
                //if left is >= right, add it to the array; else, add the right value instead
                if (leftTemp[i] <= rightTemp[j])
                {
                    arr[arrPos++] = leftTemp[i++];
                }
                else
                {
                    arr[arrPos++] = rightTemp[j++];
                }
            }

            //excess values? add them to the array, and let the other recursive calls of sort handle sorting it further.
            while (i < leftLength)
            {
                arr[arrPos++] = leftTemp[i++];
            }
            while (i < rightLength)
            {
                arr[arrPos++] = rightTemp[j++];
            }
        }

        //very tired of making "toString/printArray" comments, but I'm determined.
        public static string printArray(int[] list)
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
            return str;
        }



    }






}