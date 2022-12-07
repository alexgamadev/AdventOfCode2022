
int prioritySum = 0;
List<string> rucksacks = File.ReadAllLines("input.txt").ToList();
int groupMemberIndex = 0;
const int MAX_GROUP_MEMBERS = 3;
int totalBadgePriority = 0;
string groupPotentialBadges = String.Empty;

rucksacks.ForEach( rucksack => 
{
    // Part 1
    // Wouldn't work for odd lengths but input guarantees even lengths
    string compartment1 = rucksack.Substring(0, rucksack.Length / 2);
    string compartment2 = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);

    char sharedItem = compartment1.Intersect(compartment2).FirstOrDefault();

    int priority = GetItemPriority( sharedItem );
    prioritySum += priority;

    // Part 2
    if ( groupMemberIndex == 0 ) 
    {
        groupPotentialBadges = rucksack;
        groupMemberIndex++;
    } 
    else
    {
        groupPotentialBadges = String.Join("", groupPotentialBadges.Intersect( rucksack ));
        
        if ( groupMemberIndex == MAX_GROUP_MEMBERS - 1 ) 
        {
            char badge = groupPotentialBadges.FirstOrDefault();
            totalBadgePriority += GetItemPriority( badge );
            groupPotentialBadges = String.Empty;
            groupMemberIndex = 0;
        } 
        else 
        {
            groupMemberIndex++;
        }
    }
});

int GetItemPriority( char item )
{
    return Char.IsLower( item ) ? (int)item - 96 : (int)item - 38;
}

Console.WriteLine( $"Final sum priority: {prioritySum}" );
Console.WriteLine( $"Final badge sum priority: {totalBadgePriority}" );
