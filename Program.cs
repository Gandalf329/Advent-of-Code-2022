using Advent_of_Code_2022.Days;
namespace Advent_of_Code_2022;

internal class Program
{
    static void Main(string[] args)
    {
        var day1 = new _01_Calorie_Counting();
        var day2 = new _02_Rock_Paper_Scissors();

        day1.GetData();
        day2.GetData();

        Console.WriteLine("Advent of code 2022!");
        Console.WriteLine($"Day 1. Result 1: {day1.Result1()} \t Result 2: {day1.Result2()}");
        Console.WriteLine($"Day 2. Result 1: {day2.Result1()} \t Result 2: {day1.Result2()}");
    }
}
