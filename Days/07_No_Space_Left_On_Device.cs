using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _07_No_Space_Left_On_Device
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\7day_input.txt";
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
        Directory parent = null;
        Directory current = null;

        for (var i = 0; i < data.Count; i++)
        {
            var line = data[i];
            if (line == "$ cd /")
            {
                current = parent = new Directory() { name = "/" };
            }
            else if (line.Split(' ')[1] == "ls")
            {
                i++;
                line = data[i];
                while (!line.StartsWith("$") && data.Count > i)
                {
                    if (line.Split(' ')[0] == "dir")
                    {
                        if (!current.childDirectories.Any(d => d.name == line.Split(' ')[1]))
                        {
                            current.childDirectories.Add(new Directory()
                            {
                                name = line.Split(' ')[1],
                                parentDirectory = current
                            });
                        }
                    }
                    else
                    {
                        if (!current.childFiles.Any(d => d.name == line.Split(' ')[1]))
                        {
                            current.childFiles.Add(new File() { name = line.Split(' ')[1], size = int.Parse(line.Split(' ')[0]) });
                        }
                    }
                    i++;
                    if (data.Count > i)
                    {
                        line = data[i];
                    }
                }
                i--;
            }
            else if (line.Split(' ')[1] == "cd")
            {
                if (line.Split(' ')[2] == "/")
                {
                    current = parent;
                }
                else if (line.Split(' ')[2] == "..")
                {
                    current = current.parentDirectory;
                }
                else
                {
                    bool change = false;
                    foreach (var dir in current.childDirectories)
                    {
                        if (dir.name == line.Split(' ')[2])
                        {
                            change = true;
                            current = dir;
                            break;
                        }
                    }
                }
            }
        }
        int num1 = parent.CalculateSize();
        return parent.CalculateResult1();
    }
    public int Result2()
    {
        Directory parent = null;
        Directory current = null;

        for (var i = 0; i < data.Count; i++)
        {
            var line = data[i];
            if (line == "$ cd /")
            {
                current = parent = new Directory() { name = "/" };
            }
            else if (line.Split(' ')[1] == "ls")
            {
                i++;
                line = data[i];
                while (!line.StartsWith("$") && data.Count > i)
                {
                    if (line.Split(' ')[0] == "dir")
                    {
                        if (!current.childDirectories.Any(d => d.name == line.Split(' ')[1]))
                        {
                            current.childDirectories.Add(new Directory()
                            {
                                name = line.Split(' ')[1],
                                parentDirectory = current
                            });
                        }
                    }
                    else
                    {
                        if (!current.childFiles.Any(d => d.name == line.Split(' ')[1]))
                        {
                            current.childFiles.Add(new File() { name = line.Split(' ')[1], size = int.Parse(line.Split(' ')[0]) });
                        }
                    }
                    i++;
                    if (data.Count > i)
                    {
                        line = data[i];
                    }
                }
                i--;
            }
            else if (line.Split(' ')[1] == "cd")
            {
                if (line.Split(' ')[2] == "/")
                {
                    current = parent;
                }
                else if (line.Split(' ')[2] == "..")
                {
                    current = current.parentDirectory;
                }
                else
                {
                    bool change = false;
                    foreach (var dir in current.childDirectories)
                    {
                        if (dir.name == line.Split(' ')[2])
                        {
                            change = true;
                            current = dir;
                            break;
                        }
                    }
                }
            }
        }
        int num1 = parent.CalculateSize();
        int availableSpace = 70000000;
        int unusedSpace = 30000000;
        int currentUnusedSpace = availableSpace - parent.size;
        int amountToDelete = unusedSpace - currentUnusedSpace;
        var candidates = new List<Directory>();

        parent.CalculateResult2(amountToDelete, candidates);
        return candidates.OrderBy(c => c.size).First().size;
    }
}
internal class File
{
    public string name;
    public int size;
}
internal class Directory
{
    public string name;
    public Directory parentDirectory;
    public List<Directory> childDirectories = new List<Directory>();
    public List<File> childFiles = new List<File>();
    public int size;
    public int CalculateSize()
    {
        size = childFiles.Sum(f => f.size);
        foreach (var dir in childDirectories)
        {
            size += dir.CalculateSize();
        }
        return size;
    }
    public int CalculateResult1 ()
    {
        int temp = 0;
        if (size <= 100000)
        {
            temp += size;
        }
        foreach (var dir in childDirectories)
        {
            temp += dir.CalculateResult1();
        }
        return temp;
    }
    public void CalculateResult2(int limit, List<Directory> list)
    {
        if (size >= limit)
        {
            list.Add(this);
        }

        foreach (var dir in childDirectories)
        {
            dir.CalculateResult2(limit, list);
        }
    }
}
