using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _11_Monkey_in_the_Middle
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\11day_input.txt";
    List<string> data = new List<string>();
    List<int> check = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
    Queue<int> monkey0 = new Queue<int>();
    Queue<int> monkey1 = new Queue<int>();
    Queue<int> monkey2 = new Queue<int>();
    Queue<int> monkey3 = new Queue<int>();
    Queue<int> monkey4 = new Queue<int>();
    Queue<int> monkey5 = new Queue<int>();
    Queue<int> monkey6 = new Queue<int>();
    Queue<int> monkey7 = new Queue<int>();
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
    public int Operation(char monkey, int level)
    {
        switch (monkey)
        {
            case '0':
                check[0] += 1;
                return level * 5;
                break;
            case '1':
                check[1] += 1;
                return level + 3;
                break;
            case '2':
                check[2] += 1;
                return level + 7;
                break;
            case '3':
                check[3] += 1;
                return level + 5;
                break;
            case '4':
                check[4] += 1;
                return level + 2;
                break;
            case '5':
                check[5] += 1;
                return level * 19;
                break;
            case '6':
                check[6] += 1;
                return level * level;
                break;
            case '7':
                check[7] += 1;
                return level + 4;
                break;
            default:
                return level;
        }
    }
    public void Throw(int level, char toMonkey)
    {
        switch (toMonkey)
        {
            case '0':
                monkey0.Enqueue(level);
                break;
            case '1':
                monkey1.Enqueue(level);
                break;
            case '2':
                monkey2.Enqueue(level);
                break;
            case '3':
                monkey3.Enqueue(level);
                break;
            case '4':
                monkey4.Enqueue(level);
                break;
            case '5':
                monkey5.Enqueue(level);
                break;
            case '6':
                monkey6.Enqueue(level);
                break;
            case '7':
                monkey7.Enqueue(level);
                break;
            default:
                break;
        }
    }
    public int Result1()
    {
        int result = 0;
        int round = 1;
        int count = 0;
        for (int k = 0; k < data.Count; k++)
        {
            var monkey = data[k].Split(" "); // Monkey 0:
            var num_monkey = monkey[1][0];  // 0
            var start_items = data[k + 1].Split(":"); // Starting items: 79, 98
            string items = start_items[1].TrimStart(); // 79, 98
            switch (num_monkey)
            {
                case '0':
                    foreach (var item in items.Split(","))
                    {
                        monkey0.Enqueue(int.Parse(item));
                    }
                    break;
                case '1':
                    foreach (var item in items.Split(","))
                    {
                        monkey1.Enqueue(int.Parse(item));
                    }
                    break;
                case '2':
                    foreach (var item in items.Split(","))
                    {
                        monkey2.Enqueue(int.Parse(item));
                    }
                    break;
                case '3':
                    foreach (var item in items.Split(","))
                    {
                        monkey3.Enqueue(int.Parse(item));
                    }
                    break;
                case '4':
                    foreach (var item in items.Split(","))
                    {
                        monkey4.Enqueue(int.Parse(item));
                    }
                    break;
                case '5':
                    foreach (var item in items.Split(","))
                    {
                        monkey5.Enqueue(int.Parse(item));
                    }
                    break;
                case '6':
                    foreach (var item in items.Split(","))
                    {
                        monkey6.Enqueue(int.Parse(item));
                    }
                    break;
                case '7':
                    foreach (var item in items.Split(","))
                    {
                        monkey7.Enqueue(int.Parse(item));
                    }
                    break;
            }
            k += 6;
        }
        while (round != 21)
        {
            for (int i = 0; i < data.Count; i += 4)
            {
                var monkey = data[i].Split(" "); // Monkey 0:
                var num_monkey = monkey[1][0];  // 0
                i += 3;
                var test = data[i].Replace("Test: divisible by ", "");
                test = test.TrimStart();
                switch (num_monkey)
                {
                    case '0':
                        count = monkey0.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey0.Dequeue();
                            level = Operation(num_monkey, level) / 3;
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '1':
                        count = monkey1.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey1.Dequeue();
                            level = Operation(num_monkey, level) / 3;
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '2':
                        count = monkey2.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey2.Dequeue();
                            level = Operation(num_monkey, level) / 3;
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '3':
                        count = monkey3.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey3.Dequeue();
                            level = Operation(num_monkey, level) / 3;
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '4':
                        count = monkey4.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey4.Dequeue();
                            level = Operation(num_monkey, level) / 3;
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '5':
                        count = monkey5.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey5.Dequeue();
                            level = Operation(num_monkey, level) / 3;
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '6':
                        count = monkey6.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey6.Dequeue();
                            level = Operation(num_monkey, level) / 3;
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '7':
                        count = monkey7.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey7.Dequeue();
                            level = Operation(num_monkey, level) / 3;
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                }
            }
            round += 1;
        }
        check.Sort();
        Console.WriteLine($"{check[6]} * {check[7]}");
        result = check[6] * check[7];
        return result;
    }
    public int Result2()
    {
        int result = 0;
        for (int k = 0; k < check.Count; k++)
        {
            check[k] = 0;
        }
        monkey0.Clear();
        monkey1.Clear();
        monkey2.Clear();
        monkey3.Clear();
        monkey4.Clear();
        monkey5.Clear();
        monkey6.Clear();
        monkey7.Clear();
        int round = 1;
        int count = 0;
        for (int k = 0; k < data.Count; k++)
        {
            var monkey = data[k].Split(" "); // Monkey 0:
            var num_monkey = monkey[1][0];  // 0
            var start_items = data[k + 1].Split(":"); // Starting items: 79, 98
            string items = start_items[1].TrimStart(); // 79, 98
            switch (num_monkey)
            {
                case '0':
                    foreach (var item in items.Split(","))
                    {
                        monkey0.Enqueue(int.Parse(item));
                    }
                    break;
                case '1':
                    foreach (var item in items.Split(","))
                    {
                        monkey1.Enqueue(int.Parse(item));
                    }
                    break;
                case '2':
                    foreach (var item in items.Split(","))
                    {
                        monkey2.Enqueue(int.Parse(item));
                    }
                    break;
                case '3':
                    foreach (var item in items.Split(","))
                    {
                        monkey3.Enqueue(int.Parse(item));
                    }
                    break;
                case '4':
                    foreach (var item in items.Split(","))
                    {
                        monkey4.Enqueue(int.Parse(item));
                    }
                    break;
                case '5':
                    foreach (var item in items.Split(","))
                    {
                        monkey5.Enqueue(int.Parse(item));
                    }
                    break;
                case '6':
                    foreach (var item in items.Split(","))
                    {
                        monkey6.Enqueue(int.Parse(item));
                    }
                    break;
                case '7':
                    foreach (var item in items.Split(","))
                    {
                        monkey7.Enqueue(int.Parse(item));
                    }
                    break;
            }
            k += 6;
        }
        while (round != 10001)
        {
            for (int i = 0; i < data.Count; i += 4)
            {
                var monkey = data[i].Split(" "); // Monkey 0:
                var num_monkey = monkey[1][0];  // 0
                i += 3;
                var test = data[i].Replace("Test: divisible by ", "");
                test = test.TrimStart();
                switch (num_monkey)
                {
                    case '0':
                        count = monkey0.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey0.Dequeue();
                            level = Operation(num_monkey, level) / int.Parse(test);
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '1':
                        count = monkey1.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey1.Dequeue();
                            level = Operation(num_monkey, level) / int.Parse(test);
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '2':
                        count = monkey2.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey2.Dequeue();
                            level = Operation(num_monkey, level) / int.Parse(test);
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '3':
                        count = monkey3.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey3.Dequeue();
                            level = Operation(num_monkey, level) / int.Parse(test);
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '4':
                        count = monkey4.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey4.Dequeue();
                            level = Operation(num_monkey, level) / int.Parse(test);
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '5':
                        count = monkey5.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey5.Dequeue();
                            level = Operation(num_monkey, level) / int.Parse(test);
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '6':
                        count = monkey6.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey6.Dequeue();
                            level = Operation(num_monkey, level) / int.Parse(test);
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                    case '7':
                        count = monkey7.Count;
                        for (int j = 0; j < count; j++)
                        {
                            int level = monkey7.Dequeue();
                            level = Operation(num_monkey, level) / int.Parse(test);
                            if (level % int.Parse(test) == 0)
                            {
                                var true_throw = data[i + 1].Replace("If true: throw to monkey ", "");
                                true_throw = true_throw.TrimStart();
                                Throw(level, true_throw[0]);
                            }
                            else
                            {
                                var false_throw = data[i + 2].Replace("If false: throw to monkey ", "");
                                false_throw = false_throw.TrimStart();
                                Throw(level, false_throw[0]);
                            }
                        }
                        break;
                }
            }
            round += 1;
        }
        check.Sort();
        Console.WriteLine($"{check[6]} * {check[7]}");
        result = check[6] * check[7];
        return result;
    }
}
