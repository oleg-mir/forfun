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

    static void swap(ref int x,ref int y)
    {
        int tmp;
        tmp = x;
        x = y;
        y = tmp;
    }
    
    // Complete the countSwaps function below.
    static void countSwaps(int[] a)
    {
        int n = a.Length;
        int counter = 0;
        for (int i = 0; i < n; i++)
        {

            for (int j = 0; j < n - 1; j++)
            {
                // Swap adjacent elements if they are in decreasing order
                if (a[j] > a[j + 1])
                {
                    swap(ref a[j], ref a[j + 1]);
                    counter++;
                }
            }

        }

        Console.WriteLine("Array is sorted in {0} swaps.",counter);
        Console.WriteLine("First Element: {0}", a[0]);
        Console.WriteLine("Last Element: {0}", a[n-1]);

    }
        
    static void Main(string[] args)
    {
        //int n = Convert.ToInt32(Console.ReadLine());

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        countSwaps(a);
    }
}
