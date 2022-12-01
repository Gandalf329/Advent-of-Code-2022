using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Advent_of_Code_2022.Days;
public class _01_Calorie_Counting
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\1day_input.txt";
    List<int> data = new List<int>();
    public void GetData()
    {
        int sum = 0;
        using (StreamReader fs = new StreamReader(path))
        {
            while (true)
            {
                string temp = fs.ReadLine();
                if (temp == null)
                {
                    data.Add(sum);
                    break;
                }

                if (temp.Length == 0)
                {
                    data.Add(sum);
                    sum = 0;
                }
                else
                {
                    sum += int.Parse(temp);
                }
            }
        }
    }
    public int Result1()
    {
        return data.Max();
    }
    public int Result2()
    {
        var data2 = from d in data orderby d descending select d;
        return data2.Take(3).Sum();
    }
}
