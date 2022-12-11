using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _10_Cathode_Ray_Tube
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\10day_input.txt";
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
    public bool CheckLoop(int loop)
    {
        if (loop == 20 || loop == 60 || loop == 100 || loop == 140 || loop == 180 || loop == 220)
        {
            return true;
        }
        return false;
    }
    public int Result1()
    {
        int result = 0;
        int loop = 0;
        int check = 1;
        foreach (string item in data)
        {
            if (item == "noop")
            {
                loop += 1;
                if (CheckLoop(loop))
                {
                    result += loop * check;
                }
            }
            else
            {
                int add = int.Parse(item.Split(" ")[1]);
                loop += 1;
                if (CheckLoop(loop))
                {
                    result += loop * check;
                }
                loop += 1;

                if (CheckLoop(loop))
                {
                    result += loop * check;
                }
                check += add;
            }
        }
        return result;
    }
    public bool CheckSprite(int sprite, int index)
    {
        if (sprite - 1 == index || sprite == index || sprite + 1 == index)
        {
            return true;
        }
        return false;
    }
    public void Print(List<List<string>> monitor)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Console.Write(monitor[i][j]);
            }
            Console.WriteLine("");
        }
        Console.ResetColor();
    }
    public void Result2()
    {
        List<List<string>> monitor = new List<List<string>>();
        for (int ind = 0; ind < 6; ind++)
        {
            monitor.Add(new List<string>());
            for (int k = 0; k < 40; k++)
            {
                monitor[ind].Add(".");
            }
        }
        int startSprite = 1; // 0,1,2
        int loop = -1;
        int i = 0;
        int j = 0;
        foreach (string item in data)
        {

            if (item == "noop")
            {
                loop += 1;
                i = loop / 40;
                j = loop % 40;
                if (CheckSprite(startSprite, loop % 40))
                {
                    monitor[i][j] = "#";
                }
            }
            else
            {
                int add = int.Parse(item.Split(" ")[1]);
                loop += 1;
                i = loop / 40;
                j = loop % 40;
                if (CheckSprite(startSprite, loop % 40))
                {
                    monitor[i][j] = "#";
                }
                loop += 1;
                i = loop / 40;
                j = loop % 40;
                if (CheckSprite(startSprite, loop % 40))
                {
                    monitor[i][j] = "#";
                }
                startSprite += add;
            }
        }
        Print(monitor);

    }
}
