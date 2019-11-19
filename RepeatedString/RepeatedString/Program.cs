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
    //helper function to count number of a's in a string
    static long aInString(string s)
    {
        int counter = 0;
        foreach (char c in s)
        {
            if (c == 'a')
            {
                counter++;
            }
        }
        return counter;
    }
    // Complete the repeatedString function below.
    static long repeatedString(string s, long n)
    {
        long originalA = 0;
        long wholeTimes, wholeTimesA, moduleTimes, moduleTimesA;

        originalA = aInString(s);
        wholeTimes = n / s.Length;
        wholeTimesA = originalA * wholeTimes;

        moduleTimes = n % s.Length;
        moduleTimesA = aInString(s.Substring(0, (int)moduleTimes));
        return wholeTimesA + moduleTimesA;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("d:\\textwriter.txt", true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);

        Console.Out.WriteLine(result);
        //textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
