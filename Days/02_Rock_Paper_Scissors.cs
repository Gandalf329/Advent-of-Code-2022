using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
public class _02_Rock_Paper_Scissors
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\2day_input.txt";
    List<string> data = new List<string>();
    List<string> draw = new List<string>() {"A X", "B Y", "C Z" }; //+3
    List<string> win = new List<string>() { "C X", "A Y", "B Z" }; //+6
    int result = 0;

    public void GetData()
    {

        using (StreamReader fs = new StreamReader(path))
        {
            while (true)
            {
                string temp = fs.ReadLine();
                if (temp == null)
                {
                    //data.Add(temp);
                    break;
                }
                data.Add(temp);
            }
        }
    }
    public int Result1()
    {
        foreach (var item in data)
        {
            if (draw.Contains(item))
            {
                result+= 3;
            }else if (win.Contains(item))
            {
                result += 6;
            }
            switch (item[2])
            {
                case 'X':
                    result += 1;
                    break;
                case 'Y':
                    result += 2;
                    break;
                case 'Z':
                    result += 3;
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}
