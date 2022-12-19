// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var data = File.ReadAllLines("input.txt").ToList();

var individualElfCalories = new List<int>() { 0 };

// Part 1
data.ForEach( line => {
    if ( String.IsNullOrWhiteSpace(line) ) {
        individualElfCalories.Add(0);
    } else {
        int number = Int32.Parse(line);
        individualElfCalories[individualElfCalories.Count - 1] += number;
    }
} ); 
Console.WriteLine( "Part 1: " + individualElfCalories.Max());  

// Part 2
individualElfCalories.Sort( ( a, b ) => b - a );
var top3Sum = individualElfCalories.Take(3).Sum();
Console.WriteLine( "Part 2: " + top3Sum );