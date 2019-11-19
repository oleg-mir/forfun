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

    // Complete the whatFlavors function below.
    static void whatFlavors(int[] cost, int money)
    {
        Hashtable ht = new Hashtable();

        //building hash
        for(int i=0; i<cost.Length;i++)
        {
            if(ht.ContainsKey(cost[i]))
            {
                if(cost[i] + cost[i] == money)
                {
                    int key1 = (int)ht[cost[i]] + 1;
                    int key2 = i + 1;
                    Console.WriteLine(key1 + " " + key2);
                    return;
                }
            }

            ht.Add(cost[i], i);
        }

        foreach(DictionaryEntry h in ht)
        {
            if(ht.ContainsKey(money - (int)h.Key))
            {
                int key1 = (int)ht[money - (int)h.Key] + 1;
                int key2 = (int)ht[h.Key] + 1;
                Console.WriteLine( key1+" "+key2);
                return;
            }
        }

    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int money = Convert.ToInt32(Console.ReadLine());

            int n = Convert.ToInt32(Console.ReadLine());

            int[] cost = Array.ConvertAll(Console.ReadLine().Split(' '), costTemp => Convert.ToInt32(costTemp))
            ;
            whatFlavors(cost, money);
        }
    }
}
