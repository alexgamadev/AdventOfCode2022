﻿
int prioritySum = 0;
List<string> rucksacks = File.ReadAllLines("input.txt").ToList();
rucksacks.ForEach( rucksack => 
{
    // Wouldn't work for odd lengths but input guarantees even lengths
    string compartment1 = rucksack.Substring(0, rucksack.Length / 2);
    string compartment2 = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);

    char sharedItem = compartment1.Intersect(compartment2).FirstOrDefault();

    int priority = Char.IsLower( sharedItem ) ? (int)sharedItem - 96 : (int)sharedItem - 38;
    prioritySum += priority;

    Console.WriteLine($"{sharedItem} with priority of {priority}");
});

Console.WriteLine( $"Final sum priority: {prioritySum}" );