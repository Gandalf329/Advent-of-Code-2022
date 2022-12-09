using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _09_Rope_Bridge
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\9day_input.txt";
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

    public bool Check(int rowT, int colT, int rowH, int colH, int c)
    {
        for (int i = -1; i < c; i++)
        {
            for (int j = -1; j < c; j++)
            {
                if (rowT + i == rowH && colT + j == colH)//1,1
                {
                    return false;
                }

            }
        }
        return true;
    }
    public bool CheckItem(List<List<int>> pos, List<int> check)
    {
        foreach (var item in pos)
        {
            if (item[0] == check[0] && item[1] == check[1])
            {
                return false;
            }
        }
        return true;
    }
    public int Result1()
    {
        //int result = 0;

        List<int> head = new List<int>() { 0, 0 };//row col
        List<int> tail = new List<int>() { 0, 0 };
        List<List<int>> positions = new List<List<int>>();
        List<List<int>> result = new List<List<int>>();
        positions.Add(new List<int>() { tail[0], tail[1] });
        foreach (string item in data)
        {
            var move = item.Split(" ");
            int num = int.Parse(move[1]);

            for (int i = 0; i < num; i++)
            {
                int lastCol = 0;
                int lastRow = 0;
                switch (move[0])
                {
                    case "R":
                        lastCol = 0;
                        lastCol += head[1];
                        lastRow = 0;
                        lastRow += head[0];
                        head[1] += 1;
                        if (Check(tail[0], tail[1], head[0], head[1], 2))
                        {
                            tail[0] = lastRow;
                            tail[1] = lastCol;
                            if (CheckItem(positions, tail))
                            {
                                positions.Add(new List<int>() { tail[0], tail[1] });
                            }

                        }
                        break;
                    case "L":
                        lastCol = 0;
                        lastCol += head[1];
                        lastRow = 0;
                        lastRow += head[0];
                        head[1] -= 1;
                        if (Check(tail[0], tail[1], head[0], head[1], 2))
                        {
                            tail[0] = lastRow;
                            tail[1] = lastCol;
                            if (CheckItem(positions, tail))
                            {
                                positions.Add(new List<int>() { tail[0], tail[1] });
                            }
                        }
                        break;
                    case "U":
                        lastCol = 0;
                        lastCol += head[1];
                        lastRow = 0;
                        lastRow += head[0];
                        head[0] += 1;
                        if (Check(tail[0], tail[1], head[0], head[1], 2))
                        {
                            tail[0] = lastRow;
                            tail[1] = lastCol;
                            if (CheckItem(positions, tail))
                            {
                                positions.Add(new List<int>() { tail[0], tail[1] });
                            }
                        }
                        break;
                    case "D":
                        lastCol = 0;
                        lastCol += head[1];
                        lastRow = 0;
                        lastRow += head[0];
                        head[0] -= 1;
                        if (Check(tail[0], tail[1], head[0], head[1], 2))
                        {
                            tail[0] = lastRow;
                            tail[1] = lastCol;
                            if (CheckItem(positions, tail))
                            {
                                positions.Add(new List<int>() { tail[0], tail[1] });
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        result = positions.Distinct().ToList();
        return result.Count;
    }

}
