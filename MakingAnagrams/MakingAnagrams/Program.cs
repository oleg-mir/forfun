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

    // Complete the makeAnagram function below.
    static int makeAnagram(string a, string b)
    {
        Hashtable histogramA = new Hashtable();
        Hashtable histogramB = new Hashtable();
        int counter = 0;

        foreach (char c in a)
        {
            if (histogramA.ContainsKey(c))
            {
                histogramA[c] = (int)histogramA[c] + 1; ;
            }
            else
            {
                histogramA.Add(c, 1);
            }
        }

        foreach (char c in b)
        {
            if (histogramB.ContainsKey(c))
            {
                histogramB[c] = (int)histogramB[c] + 1; ;
            }
            else
            {
                histogramB.Add(c, 1);
            }
        }

        foreach (var key in histogramA.Keys)
        {

            if (histogramB.ContainsKey(key))
            {
                if ((int)histogramA[key] == (int)histogramB[key])
                    continue;
                if((int)histogramA[key] > (int)histogramB[key])
                    counter = counter + (int)histogramA[key] - (int)histogramB[key];
            }
            else
            {
                counter = counter + (int)histogramA[key];
            }
        }

        foreach (var key in histogramB.Keys)
        {
            if (histogramA.ContainsKey(key))
            {
                if ((int)histogramA[key] == (int)histogramB[key])
                    continue;
                if ((int)histogramA[key] < (int)histogramB[key])
                    counter = counter + (int)histogramB[key] - (int)histogramA[key];
            }
            else
            {
                counter = counter + (int)histogramB[key];
            }

        }
        return counter;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter("", true);

        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = makeAnagram(a, b);

        //textWriter.WriteLine(res);
        Console.Out.WriteLine(res);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
