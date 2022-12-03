using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _03_Rucksack_Reorganization
{
    //LdHVLDLDdHdtLMhcqCqGWcWg input string
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\3day_input.txt";
    List<string> data = new List<string>();

    public void GetData()
    {
        using (StreamReader fs = new StreamReader(path))
        {
            while (true)
            {
                string temp = fs.ReadLine();
                if (temp == null)
                {
                    break;
                }
                data.Add(temp);
            }
        }
    }
    public int GetIndex(char c)
    {
        int index = 0;
        if (Char.IsUpper(c))
        {
            index = ((int)c % 32)+26;
        }
        else
        {
            index = (int)c % 32;
        }
        
        return index;
    }
    public int Result1()
    {
        int result = 0;
        foreach(string item in data)
        {
            char[] word1 = item.Substring(0, item.Length / 2).ToCharArray();
            string word2 = item.Substring(item.Length/2);
            foreach(char c in word1)
            {
                if (word2.Contains(c))
                {
                    result+= GetIndex(c);
                    break;
                }
            }
        }
        return result;
    }
    public int Result2()
    {
        int result = 0;
        for (int i = 0; i < data.Count; i+=3)
        {
            char[] word1 = data[i].ToCharArray();
            foreach (char c in word1)
            {
                if (data[i+1].Contains(c) && data[i+2].Contains(c))
                {
                    result += GetIndex(c);
                    break;
                }
            }
        }
        return result;
    }
}
