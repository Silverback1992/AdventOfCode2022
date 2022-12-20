using AdventOfCode2022.Day_1;
using AdventOfCode2022.Day_2;
using AdventOfCode2022.Day_6;
using AdventOfCode2022.Day_8;
using System.Diagnostics;

#region Day 1
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

#endregion

#region Day 2
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

#endregion

#region Day 3
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

#endregion

#region Day 4
//Part 1
string[] sectionAssignmentPairs = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Day 4\ListOfSectionAssignmentPairs.txt"));

int assigmentsWhereOneRangeFullyContainTheOther = sectionAssignmentPairs.Select(x =>
{
    var pairOfElves = x.Split(",");

    var firstElfAssigment = pairOfElves[0].Split("-");
    var secondElfAssigment = pairOfElves[1].Split("-");

    int x1 = int.Parse(firstElfAssigment[0]);
    int x2 = int.Parse(firstElfAssigment[1]);

    int y1 = int.Parse(secondElfAssigment[0]);
    int y2 = int.Parse(secondElfAssigment[1]);

    if ((x1 <= y1 && x2 >= y2) || (y1 <= x1 && y2 >= x2))
    {
        return 1;
    }

    return 0;
}).Sum();

//Part 2
int assigmentsWhereOneRangeOverlapTheOther = sectionAssignmentPairs.Select(x =>
{
    var pairOfElves = x.Split(",");

    var firstElfAssigment = pairOfElves[0].Split("-");
    var secondElfAssigment = pairOfElves[1].Split("-");

    int x1 = int.Parse(firstElfAssigment[0]);
    int x2 = int.Parse(firstElfAssigment[1]);

    int y1 = int.Parse(secondElfAssigment[0]);
    int y2 = int.Parse(secondElfAssigment[1]);

    if ((x1 < y1 && x2 < y1) || (y1 < x1 && y2 < x1))
    {
        return 0;
    }

    return 1;
}).Sum(); ;

//Result
Console.WriteLine($"Day 4 Part 1 challenge answer: {assigmentsWhereOneRangeFullyContainTheOther}");
Console.WriteLine($"Day 4 Part 2 challenge answer: {assigmentsWhereOneRangeOverlapTheOther}");

#endregion

#region Day 5
var stacks = new Dictionary<int, Stack<char>>() 
{
    { 1, new Stack<char>(new[] { 'B', 'V', 'S', 'N', 'T', 'C', 'H', 'Q' }) },
    { 2, new Stack<char>(new[] { 'W', 'D', 'B', 'G' }) },
    { 3, new Stack<char>(new[] { 'F', 'W', 'R', 'T', 'S', 'Q', 'B' }) },
    { 4, new Stack<char>(new[] { 'L', 'G', 'W', 'S', 'Z', 'J', 'D', 'N' }) },
    { 5, new Stack<char>(new[] { 'M', 'P', 'D', 'V', 'F' }) },
    { 6, new Stack<char>(new[] { 'F', 'W', 'J' }) },
    { 7, new Stack<char>(new[] { 'L', 'N', 'Q', 'B', 'J', 'V' }) },
    { 8, new Stack<char>(new[] { 'G', 'T', 'R', 'C', 'J', 'Q', 'S', 'N' }) },
    { 9, new Stack<char>(new[] { 'J', 'S', 'Q', 'C', 'W', 'D', 'M' }) }
};

var stacksForCrateMover9001 = new Dictionary<int, Stack<char>>()
{
    { 1, new Stack<char>(new[] { 'B', 'V', 'S', 'N', 'T', 'C', 'H', 'Q' }) },
    { 2, new Stack<char>(new[] { 'W', 'D', 'B', 'G' }) },
    { 3, new Stack<char>(new[] { 'F', 'W', 'R', 'T', 'S', 'Q', 'B' }) },
    { 4, new Stack<char>(new[] { 'L', 'G', 'W', 'S', 'Z', 'J', 'D', 'N' }) },
    { 5, new Stack<char>(new[] { 'M', 'P', 'D', 'V', 'F' }) },
    { 6, new Stack<char>(new[] { 'F', 'W', 'J' }) },
    { 7, new Stack<char>(new[] { 'L', 'N', 'Q', 'B', 'J', 'V' }) },
    { 8, new Stack<char>(new[] { 'G', 'T', 'R', 'C', 'J', 'Q', 'S', 'N' }) },
    { 9, new Stack<char>(new[] { 'J', 'S', 'Q', 'C', 'W', 'D', 'M' }) }
};

//Part 1
string[] rearrangementProcedure = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Day 5\RearrangementProcedure.txt"));

foreach (var x in rearrangementProcedure)
{
    var arr = x.Split(" ");

    int howManyToMove = int.Parse(arr[1]);
    int fromWhichStack = int.Parse(arr[3]);
    int toWhichStack = int.Parse(arr[5]);

    while (howManyToMove > 0)
    {
        char crate = stacks[fromWhichStack].Pop();
        stacks[toWhichStack].Push(crate);
        howManyToMove--;
    }
}

string topCratesAcrossTheStacks = String.Join("", stacks.Select(x => x.Value.Peek()));

//Part 2
foreach (var x in rearrangementProcedure)
{
    var arr = x.Split(" ");

    int howManyToMove = int.Parse(arr[1]);
    int fromWhichStack = int.Parse(arr[3]);
    int toWhichStack = int.Parse(arr[5]);

    var cratesToMove = new List<char>();

    while (howManyToMove > 0)
    {
        cratesToMove.Add(stacksForCrateMover9001[fromWhichStack].Pop());
        howManyToMove--;
    }

    cratesToMove.Reverse();
    cratesToMove.ForEach(x => stacksForCrateMover9001[toWhichStack].Push(x));
}

string topCratesAcrossTheStacksForCrateMover9001 = String.Join("", stacksForCrateMover9001.Select(x => x.Value.Peek()));

//Result
Console.WriteLine($"Day 5 Part 1 challenge answer: {topCratesAcrossTheStacks}");
Console.WriteLine($"Day 5 Part 2 challenge answer: {topCratesAcrossTheStacksForCrateMover9001}");

#endregion

#region Day 6
//Part 1
string dataStreamBuffer = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Day 6\DataStreamBuffer.txt"));

int startOfPackerMarker = MarkerPositionCalculator.CalculateMarkerPosition(dataStreamBuffer, 4);

//Part 2
int startOfMessageMarker = MarkerPositionCalculator.CalculateMarkerPosition(dataStreamBuffer, 14);

//Result
Console.WriteLine($"Day 6 Part 1 challenge answer: {startOfPackerMarker}");
Console.WriteLine($"Day 6 Part 2 challenge answer: {startOfMessageMarker}");

#endregion

#region Day 7
//Part 1

//Part 2

//Result

#endregion

#region Day 8
//Part 1
string[] treeHeights = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Day 8\TreeHeights.txt"));
//Visible on the edge:
int visibleTrees = treeHeights.Length * 2 + (treeHeights[0].Length - 2) * 2;

var trees = TreeObjectCreatorService.CreateTreeObjects(treeHeights);

visibleTrees = visibleTrees + trees.Count(tree =>
{
    return VisibilityChecker.IsVisibleFromTheTop(treeHeights, tree) ||
           VisibilityChecker.IsVisibleFromTheBottom(treeHeights, tree) ||
           VisibilityChecker.IsVisibleFromTheLeft(treeHeights, tree) ||
           VisibilityChecker.IsVisibleFromTheRight(treeHeights, tree);
});

//Part 2
int maxScenicSore = trees.Select(tree =>
{
    return ScenicScoreCalculatorService.TreesVisibleLookingAtTheTop(treeHeights, tree) *
           ScenicScoreCalculatorService.TreesVisibleLookingAtTheBottom(treeHeights, tree) *
           ScenicScoreCalculatorService.TreesVisibleLookingAtTheLeft(treeHeights, tree) *
           ScenicScoreCalculatorService.TreesVisibleLookingAtTheRight(treeHeights, tree);

}).Max();

//Result
Console.WriteLine($"Day 8 Part 1 challenge answer: {visibleTrees}");
Console.WriteLine($"Day 8 Part 2 challenge answer: {maxScenicSore}");

#endregion

//Day 9

//Day 10

//Day 11

//Day 12

//Day 13

//Day 14

//Day 15

//Day 16

//Day 17

//Day 18

//Day 19

//Day 20

//Day 21

//Day 22

//Day 23

//Day 24

//Day 25