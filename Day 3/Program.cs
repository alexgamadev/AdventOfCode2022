
int prioritySum = 0;
List<string> rucksacks = File.ReadAllLines("input.txt").ToList();
const int MAX_GROUP_MEMBERS = 3;
int totalBadgePriority = 0;

// Part 1 - Cleaner
prioritySum = rucksacks.Select( rucksack => 
{
    // Wouldn't work for odd lengths but input guarantees even lengths
    string compartment1 = rucksack.Substring(0, rucksack.Length / 2);
    string compartment2 = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);

    char sharedItem = compartment1.Intersect(compartment2).FirstOrDefault();

    return GetItemPriority( sharedItem );
}).Sum();

 // Part 2 - Handles any group sizes
 totalBadgePriority = rucksacks.Chunk(MAX_GROUP_MEMBERS).Select( group => 
 {
    string potentialBadges = "";
    potentialBadges = group[0];

    for( int elf = 1; elf < MAX_GROUP_MEMBERS; elf++ )
    {
        potentialBadges = String.Join( "", potentialBadges.Intersect(group[elf]) );
    }

    return GetItemPriority( potentialBadges.FirstOrDefault() );
 } ).Sum();

int GetItemPriority( char item )
{
    return Char.IsLower( item ) ? (int)item - 96 : (int)item - 38;
}

Console.WriteLine( $"Final sum priority: {prioritySum}" );
Console.WriteLine( $"Final badge sum priority: {totalBadgePriority}" );
