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
        List<string> draw = new List<string>() { "A X", "B Y", "C Z" }; //+3
        List<string> win = new List<string>() { "C X", "A Y", "B Z" }; //+6
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
    public int Result2()
    {
        int result = 0;
        foreach (var item in data)
        {
            switch (item[2])
            {
                case 'X':  // Lose
                    result += 0;
                    switch (item[0])
                    {
                        case 'A': result += 3; break;
                        case 'B': result += 1; break;
                        case 'C': result += 2; break;
                        default: break;
                    }
                    break;
                case 'Y': // Draw 
                    result += 3;
                    switch (item[0])
                    {
                        case 'A': result += 1; break;
                        case 'B': result += 2; break;
                        case 'C': result += 3; break;
                        default: break;
                    }
                    break;
                case 'Z': // Win
                    result += 6;
                    switch (item[0])
                    {
                        case 'A': result += 2; break;
                        case 'B': result += 3; break;
                        case 'C': result += 1; break;
                        default: break;
                    }
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}
