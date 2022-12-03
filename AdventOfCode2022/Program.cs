﻿using AdventOfCode2022.Day_1;
using AdventOfCode2022.Day_2;

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

//Day 2
//Part 1
string[] strategyGuide = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Day 2\RockPaperScissorsStrategyGuide.txt"));
int totalPoints = strategyGuide.Select(x => x.Split(" ")).Select(y =>
{
    var opponentShape = ShapeIdentifier.IdentifyShape(y[0]);
    var myShape = ShapeIdentifier.IdentifyShape(y[1]);

    return (int)myShape + (int)PointCalculator.ResultTypeCalculator(opponentShape, myShape);
}).Sum();

//Part 2
int totalPointsWithModifiedStrategy = strategyGuide.Select(x => x.Split(" ")).Select(y =>
{
    var opponentShape = ShapeIdentifier.IdentifyShape(y[0]);
    var desiredResult = ResultIdentifier.IdentifyResult(y[1]);

    return (int)PointCalculator.ShouldBeChoosenShapeCalculator(opponentShape, desiredResult) + (int)desiredResult;
}).Sum(); ;

//Result
Console.WriteLine($"Day 2 Part 1 challenge answer: {totalPoints}");
Console.WriteLine($"Day 2 Part 2 challenge answer: {totalPointsWithModifiedStrategy}");

//Day 3
//Part 1
string[] itemsInRucksacks = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Day 3\Rucksacks.txt"));

int sumOfPriorities = itemsInRucksacks.Select(x =>
{
    string firstCompartment = x.Substring(0, x.Length / 2);
    string secondCompartment = x.Substring(x.Length / 2, x.Length / 2);

    char commonChar = firstCompartment.First(c => secondCompartment.Contains(c));

    return Char.IsUpper(commonChar) ? commonChar - 38 : commonChar - 96;
}).Sum();

//Part 2
int badgeSum = 0;

for (int i = 0; i < itemsInRucksacks.Length; i+=3)
{
    string firstElfRucksack = itemsInRucksacks[i];
    string secondElfRucksack = itemsInRucksacks[i+1];
    string thirdElfRucksack = itemsInRucksacks[i+2];

    char commonChar = firstElfRucksack.Intersect(secondElfRucksack).First(c => thirdElfRucksack.Contains(c));

    badgeSum = badgeSum + (Char.IsUpper(commonChar) ? commonChar - 38 : commonChar - 96);
}

//Result
Console.WriteLine($"Day 3 Part 1 challenge answer: {sumOfPriorities}");
Console.WriteLine($"Day 3 Part 2 challenge answer: {badgeSum}");


//Day 4

//Day 5

//Day 6

//Day 7