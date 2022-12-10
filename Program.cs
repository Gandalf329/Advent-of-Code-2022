using Advent_of_Code_2022.Days;
namespace Advent_of_Code_2022;

internal class Program
{
    static void Main(string[] args)
    {
        var day1 = new _01_Calorie_Counting();
        var day2 = new _02_Rock_Paper_Scissors();
        var day3 = new _03_Rucksack_Reorganization();
        var day4 = new _04_Camp_Cleanup();
        var day5 = new _05_Supply_Stacks();
        var day6 = new _06_Tuning_Trouble();
        var day7 = new _07_No_Space_Left_On_Device();
        var day8 = new _08_Treetop_Tree_House();
        var day9 = new _09_Rope_Bridge();
        var day10 = new _10_Cathode_Ray_Tube();
        
        day1.GetData();
        day2.GetData();
        day3.GetData();
        day4.GetData();
        day5.GetData();
        day6.GetData();
        day7.GetData();
        day8.GetData();
        day9.GetData();
        day10.GetData();

        Console.WriteLine("Advent of code 2022!");
        Console.WriteLine($"Day 1. Result 1: {day1.Result1()} \t Result 2: {day1.Result2()}");
        Console.WriteLine($"Day 2. Result 1: {day2.Result1()} \t Result 2: {day2.Result2()}");
        Console.WriteLine($"Day 3. Result 1: {day3.Result1()} \t Result 2: {day3.Result2()}");
        Console.WriteLine($"Day 4. Result 1: {day4.Result1()} \t Result 2: {day4.Result2()}");
        Console.WriteLine($"Day 5. Result 1: {day5.Result1()} \t Result 2: {day5.Result2()}");
        Console.WriteLine($"Day 6. Result 1: {day6.Result1()} \t Result 2: {day6.Result2()}");
        Console.WriteLine($"Day 7. Result 1: {day7.Result1()} \t Result 2: {day7.Result2()}");
        Console.WriteLine($"Day 8. Result 1: {day8.Result1()} \t Result 2: {day8.Result2()}");
        Console.WriteLine($"Day 9. Result 1: {day9.Result1()} \t Result 2(not working): {day9.Result2()}");
        Console.WriteLine($"Day 10. Result 1: {day10.Result1()} \nDay10. Result 2: RKPJBPLA \n");
        day10.Result2();

    }
}
