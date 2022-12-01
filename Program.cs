using Advent_of_Code_2022.Days;
namespace Advent_of_Code_2022;

internal class Program
{
    static void Main(string[] args)
    {
        var day1 = new _01_Calorie_Counting();
        day1.GetData();       

        Console.WriteLine("Advent of code 2022!");
        Console.WriteLine($"Result 1: {day1.Result1()} \t Result 2: {day1.Result2()}");
        
    }
}
