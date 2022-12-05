using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _05_Supply_Stacks
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\5day_input.txt";
    public static List<string> data = new List<string>();
    public static List<string> data1 = new List<string>() { "T", "P", "Z", "C", "S", "L", "Q", "N" };
    public static List<string> data2 = new List<string>() { "L", "P", "T", "V", "H", "C", "G" };
    public static List<string> data3 = new List<string>() { "D", "C", "Z", "F"};
    public static List<string> data4 = new List<string>() { "G", "W", "T", "D", "L", "M", "V", "C" };
    public static List<string> data5 = new List<string>() { "P", "W", "C" };
    public static List<string> data6 = new List<string>() { "P", "F", "J", "D", "C", "T", "S", "Z" };
    public static List<string> data7 = new List<string>() { "V", "W", "G", "B", "D"};
    public static List<string> data8 = new List<string>() { "N", "J", "S", "Q", "H", "W"};
    public static List<string> data9 = new List<string>() { "R", "C", "Q", "F", "S", "L", "V"};

    Stack<string> t1 = new Stack<string>(data1);
    Stack<string> t2 = new Stack<string>(data2);
    Stack<string> t3 = new Stack<string>(data3);
    Stack<string> t4 = new Stack<string>(data4);
    Stack<string> t5 = new Stack<string>(data5);
    Stack<string> t6 = new Stack<string>(data6);
    Stack<string> t7 = new Stack<string>(data7);
    Stack<string> t8 = new Stack<string>(data8);
    Stack<string> t9 = new Stack<string>(data9);

    string text1 = "NQLSCZPT";
    string text2 = "GCHVTPL";
    string text3 = "FZCD";
    string text4 = "CVMLDTWG";
    string text5 = "CWP";
    string text6 = "ZSTCDJFP";
    string text7 = "DBGWV";
    string text8 = "WHQSJN";
    string text9 = "VLSFQCR";

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
    public void Replace(char c, string letter)
    {
        switch (c)
        {
            case '1':
                t1.Push(letter);
                break;
            case '2':
                t2.Push(letter);
                break;
            case '3':
                t3.Push(letter);
                break;
            case '4':
                t4.Push(letter);
                break;
            case '5':
                t5.Push(letter);
                break;
            case '6':
                t6.Push(letter);
                break;
            case '7':
                t7.Push(letter);
                break;
            case '8':
                t8.Push(letter);
                break;
            case '9':
                t9.Push(letter);
                break;
            default: break;
        }
    }
    public void Replace1(char c, string word)
    {
        switch (c)
        {
            case '1':
                text1 = text1.Insert(0, word);
                break;
            case '2':
                text2 = text2.Insert(0, word);
                break;
            case '3':
                text3 = text3.Insert(0, word);
                break;
            case '4':
                text4 = text4.Insert(0, word);
                break;
            case '5':
                text5 = text5.Insert(0, word);
                break;
            case '6':
                text6 = text6.Insert(0, word);
                break;
            case '7':
                text7 = text7.Insert(0, word);
                break;
            case '8':
                text8 = text8.Insert(0, word);
                break;
            case '9':
                text9 = text9.Insert(0, word);
                break;
            default: break;
        }
    }
    public string Result1()
    {
        string result = "";

        foreach(string item in data)
        {
            var part = item.Split(" from ");
            var move = part[0].Split(' ')[1];
            var from = part[1][0];
            var to = part[1][5];

            switch (from)
            {
                case '1':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t1.Pop();
                        Replace(to, ch);
                    }
                    break;
                case '2':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t2.Pop();
                        Replace(to, ch);
                    }
                    break;
                case '3':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t3.Pop();
                        Replace(to, ch);
                    }
                    break;
                case '4':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t4.Pop();
                        Replace(to, ch);
                    }
                    break;
                case '5':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t5.Pop();
                        Replace(to, ch);
                    }
                    break;
                case '6':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t6.Pop();
                        Replace(to, ch);
                    }
                    break;
                case '7':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t7.Pop();
                        Replace(to, ch);
                    }
                    break;
                case '8':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t8.Pop();
                        Replace(to, ch);
                    }
                    break;
                case '9':
                    for (int i = 0; i < int.Parse(move); i++)
                    {
                        string ch = t9.Pop();
                        Replace(to, ch);
                    }
                    break;
                default:
                    break;
            }
        }
        result += t1.Peek()+ t2.Peek()+ t3.Peek()+ t4.Peek() + t5.Peek() + t6.Peek()+ t7.Peek() + t8.Peek() + t9.Peek();
        return result;
    }
    public string Result2()
    {
        string result = "";
        foreach(string item in data)
        {
            var part = item.Split(" from ");
            var move = part[0].Split(' ')[1];
            var from = part[1][0];
            var to = part[1][5];
            string ch = "";

            switch (from)
            {
                case '1':
                    ch = text1.Substring(0,int.Parse(move));
                    text1 = text1.Substring(int.Parse(move));
                    Replace1(to, ch);
                    break;
                case '2':
                    ch = text2.Substring(0, int.Parse(move));
                    text2 = text2.Substring(int.Parse(move));
                    Replace1(to, ch);                   
                    break;
                case '3':
                    ch = text3.Substring(0, int.Parse(move));
                    text3 = text3.Substring(int.Parse(move));
                    Replace1(to, ch);
                    break;
                case '4':
                    ch = text4.Substring(0, int.Parse(move));
                    text4 = text4.Substring(int.Parse(move));
                    Replace1(to, ch);
                    break;
                case '5':
                    ch = text5.Substring(0, int.Parse(move));
                    text5 = text5.Substring(int.Parse(move));
                    Replace1(to, ch);
                    break;
                case '6':
                    ch = text6.Substring(0, int.Parse(move));
                    text6 = text6.Substring(int.Parse(move));
                    Replace1(to, ch);
                    break;
                case '7':
                    ch = text7.Substring(0, int.Parse(move));
                    text7 = text7.Substring(int.Parse(move));
                    Replace1(to, ch);
                    break;
                case '8':
                    ch = text8.Substring(0, int.Parse(move));
                    text8 = text8.Substring(int.Parse(move));
                    Replace1(to, ch);
                    break;
                case '9':
                    ch = text9.Substring(0, int.Parse(move));
                    text9 = text9.Substring(int.Parse(move));
                    Replace1(to, ch);
                    break;
                default:
                    break;
            }
        }
        result += text1[0] +"" +text2[0]+ "" + text3[0]+ "" + text4[0]+ "" + text5[0]+ "" + text6[0]+ "" + text7[0]+ "" + text8[0]+ "" + text9[0];
        return result;
    }
}
