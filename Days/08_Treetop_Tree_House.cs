using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _08_Treetop_Tree_House
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\8day_input.txt";
    public static List<List<int>> data = new List<List<int>>();

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
                List<int> nums = new List<int>();
                foreach (var item in temp)
                {
                    nums.Add(item - '0');
                }
                data.Add(nums);
            }
        }
    }
    public bool CheckTop(int j, int check, int col)
    {
        for (int i = 0; i < j; i++)
        {
            if (check <= data[i][col])
            {
                return false;
            }
        }
        return true;
    }
    public bool CheckBottom(int j, int check, int col)
    {
        for (int i = j + 1; i < data.Count; i++)
        {
            if (check <= data[i][col])
            {
                return false;
            }
        }
        return true;
    }
    public int LeftScore(List<int> left, int check)
    {
        int score = 0;

        for (int i = left.Count - 1; i >= 0; i--)
        {
            if (left[i] >= check)
            {
                score += 1;
                break;
            }
            else
            {
                score += 1;
            }
        }
        return score;
    }
    public int RightScore(List<int> right, int check)
    {
        int score = 0;

        for (int i = 0; i < right.Count; i++)
        {
            if (right[i] >= check)
            {
                score += 1;
                break;
            }
            else
            {
                score += 1;
            }
        }
        return score;
    }
    public int BottomScore(int check, int col, int row)
    {
        int score = 0;
        for (int i = row + 1; i < data.Count; i++)
        {
            if (check <= data[i][col])
            {
                score += 1;
                break;
            }
            else
            {
                score += 1;
            }
        }
        return score;
    }
    public int TopScore(int check, int col, int row)
    {
        int score = 0;

        for (int i = row - 1; i >= 0; i--)
        {
            if (check <= data[i][col])
            {
                score += 1;
                break;
            }
            else
            {
                score += 1;
            }
        }
        return score;
    }
    public int Result1()
    {
        int result = 0;

        for (int i = 1; i < data.Count - 1; i++)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            foreach (int item in data[i])
            {
                right.Add(item);
            }
            right.RemoveAt(0);

            for (int j = 1; j < data[i].Count - 1; j++)
            {
                left.Add(data[i][j - 1]);
                right.RemoveAt(0);
                int check = data[i][j];
                if (check > right.Max() || check > left.Max() || CheckTop(i, check, j) || CheckBottom(i, check, j))
                {
                    result += 1;
                }
            }
        }
        result += (data.Count - 2) * 2 + data[0].Count * 2;
        return result;
    }
    public int Result2()
    {
        List<int> result = new List<int>();

        for (int i = 1; i < data.Count - 1; i++)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            foreach (int item in data[i])
            {
                right.Add(item);
            }
            right.RemoveAt(0);

            for (int j = 1; j < data[i].Count - 1; j++)
            {
                left.Add(data[i][j - 1]);
                right.RemoveAt(0);
                int check = data[i][j];
                int lS = LeftScore(left, check);
                int rS = RightScore(right, check);
                int bS = BottomScore(check, j, i);
                int tS = TopScore(check, j, i);
                int score = lS * rS * bS * tS;
                result.Add(score);
            }
        }
        return result.Max();
    }
}
