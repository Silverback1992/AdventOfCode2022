using AdventOfCode2022.Day_1;
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

//Day 4

//Day 5

//Day 6

//Day 7