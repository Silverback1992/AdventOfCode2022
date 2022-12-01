using AdventOfCode2022.Day_1;

//Day 1
//Part 1
string[] calories = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Day 1\ElfCalories.txt"));
var caloriesCalculator = new CaloriesCalculator(calories);
var elvesAndTotalCalories = caloriesCalculator.CalculateTotalCarriedCaloriesByElf();
int mostCalories = elvesAndTotalCalories.Max(x => x.TotalCarriedCalories);

//Part 2
int topThreeElvesTotalCalories = elvesAndTotalCalories.OrderByDescending(x => x.TotalCarriedCalories)
    .Take(3).Sum(y => y.TotalCarriedCalories);

//Result
Console.WriteLine($"Day 1 Part 1 challenge answer: {mostCalories}");
Console.WriteLine($"Day 1 Part 2 challenge answer: {topThreeElvesTotalCalories}");

//var caloriesCalculator = new CaloriesCalculator(calories);


//Day 2

//Day 3

//Day 4

//Day 5

//Day 6

//Day 7