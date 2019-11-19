using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    public static int[] mergeSort(int[] a, int leftStart, int rightEnd)
    {
        int leftEnd = (leftStart + rightEnd) / 2;
        int rightStart = leftEnd + 1;

        if (leftStart+1 == rightEnd)
        {
            return mergeArrays(new int[] { a[leftStart] }, new int[] { a[rightEnd] });
        }
        if(leftStart == rightEnd)
        {
            var temp = new int[] { a[leftStart] };
            return temp;
        }

        
        var left = mergeSort(a, leftStart, leftEnd);
        var right = mergeSort(a, rightStart, rightEnd);
        var merged = mergeArrays(left, right);

        return merged;
    }

    public static int[] mergeArrays(int[] arr1, int[] arr2)
    {
        int leftStart = 0;
        int leftEnd = arr1.Length - 1;
        int rightStart = 0;
        int rightEnd = arr2.Length - 1;

        int[] result = new int[leftEnd+1+ rightEnd +1];
        int i = 0;

        while(leftStart<=leftEnd && rightStart<=rightEnd)
        {
            if(arr1[leftStart]<=arr2[rightStart])
            {
                result[i] = arr1[leftStart];
                leftStart++;
            }
            else
            {
                result[i] = arr2[rightStart];
                rightStart++;
            }

            i++;
        }

        //copying the rest of right array
        if(leftStart >= leftEnd)
        {
            while(rightStart<=rightEnd)
            {
                result[i] = arr2[rightStart];
                rightStart++;
                i++;
            }
        }
        //copying the rest of left array
        if (rightStart >= rightEnd)
        {
            while (leftStart <= leftEnd)
            {
                result[i] = arr1[leftStart];
                leftStart++;
                i++;
            }
        }

        return result;
    }

    // Complete the minimumAbsoluteDifference function below.
    static int minimumAbsoluteDifference(int[] arr, int n)
    {
        int minDifference = int.MaxValue;

        var sortedArray = mergeSort(arr, 0, n-1);

        for(int i=0;i<n-1;i++)
        {
            if (Math.Abs(sortedArray[i] - sortedArray[i + 1]) < minDifference)
            {
                minDifference = Math.Abs(sortedArray[i] - sortedArray[i + 1]);
            }
        }
        return minDifference;

    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        int result = minimumAbsoluteDifference(arr, arr.Length);

        //var result = mergeSort(arr, 0, arr.Length-1);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
