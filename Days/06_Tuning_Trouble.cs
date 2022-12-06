using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _06_Tuning_Trouble
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\6day_input.txt";
    string data = "";

    public void GetData()
    {
        using (StreamReader sr = new StreamReader(path))
        {
            data = sr.ReadToEnd();
            
        }
    }
    public bool CheckString(List<char> word)
    {
        HashSet<char> check = new HashSet<char>(word);
        if(check.Count == word.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int Result1()
    {
        int result = 0;
        for (int i = 0; i < data.Length-3; i++)
        {
            List<char> word = new List<char>();
            word.Add(data[i]);
            word.Add(data[i+1]);
            word.Add(data[i+2]);
            word.Add(data[i+3]);
            if (CheckString(word))
            {
                result += i + 4;
                break;
            }
        }
        return result;
    }
    public int Result2()
    {
        int result = 0;
        for (int i = 0; i < data.Length - 14; i++)
        {
            List<char> word = new List<char>();
            for (int j = 0; j < 14; j++)
            {
                word.Add(data[i + j]);
            }
            if (CheckString(word))
            {
                result += i + 14;
                break;
            }
        }
        return result;
    }
}
