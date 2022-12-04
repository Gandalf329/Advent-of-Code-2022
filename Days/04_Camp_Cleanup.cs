using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _04_Camp_Cleanup
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\4day_input.txt";
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
    public int Result1()
    {
        int result = 0;

        foreach (string item in data)
        {
            var part = item.Split(",");
            var numbers1 = part[0].Split('-');
            var numbers2 = part[1].Split('-');
            if (int.Parse(numbers1[0]) <= int.Parse(numbers2[0]) && int.Parse(numbers1[1]) >= int.Parse(numbers2[1]))
            {
                result++;
            }else if(int.Parse(numbers1[0]) >= int.Parse(numbers2[0]) && int.Parse(numbers1[1]) <= int.Parse(numbers2[1]))
            {
                result++;
            }
        }
        return result;
    }
    public int Result2()
    {
        int result = 0;

        foreach (string item in data)
        {
            var part = item.Split(",");
            var numbers1 = part[0].Split('-');
            var numbers2 = part[1].Split('-');
            var min1 = int.Parse(numbers1[0]);
            var min2 = int.Parse(numbers2[0]);
            var max1 = int.Parse(numbers1[1]);
            var max2 = int.Parse(numbers2[1]);

            if (int.Parse(numbers1[0]) >= int.Parse(numbers2[0]) &&
                int.Parse(numbers1[0]) <= int.Parse(numbers2[1]))
            {
                result++;
                continue;
            }

            // numbers1 1 falls in between numbers2 0 and 1
            if (int.Parse(numbers1[1]) >= int.Parse(numbers2[0]) &&
                int.Parse(numbers1[1]) <= int.Parse(numbers2[1]))
            {
               result++;
                continue;
            }

            // numbers2 0 falls in between numbers1 0 and 1
            if (int.Parse(numbers2[0]) >= int.Parse(numbers1[0]) &&
                int.Parse(numbers2[0]) <= int.Parse(numbers1[1]))
            {
                result++;
                continue;
            }

            // numbers2 1 falls in between numbers1 0 and 1
            if (int.Parse(numbers2[1]) >= int.Parse(numbers1[0]) &&
                int.Parse(numbers2[1]) <= int.Parse(numbers1[1]))
            {
                result++;
                continue;
            }
        }
        return result;
    }
}
