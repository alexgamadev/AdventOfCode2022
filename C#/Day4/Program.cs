
var pairs = File.ReadAllLines( "input.txt" );

// Part 1
int totalOverlapPairs = pairs.Select( pair =>
{
    String[] assignments = pair.Split( "," );
    int[] assignment1 = Array.ConvertAll(assignments[0].Split( "-" ), int.Parse);
    int[] assignment2 = Array.ConvertAll(assignments[1].Split( "-" ), int.Parse);
    return IsFullOverlap(assignment1, assignment2) ? 1 : 0;
} ).Sum();

// Part 2
int anyOverlapPairs = pairs.Select( pair =>
{
    String[] assignments = pair.Split( "," );
    int[] assignment1 = Array.ConvertAll(assignments[0].Split( "-" ), int.Parse);
    int[] assignment2 = Array.ConvertAll(assignments[1].Split( "-" ), int.Parse);
    return IsAnyOverlap(assignment1, assignment2) ? 1 : 0;
} ).Sum();

Console.WriteLine( totalOverlapPairs );
Console.WriteLine( anyOverlapPairs );

bool IsFullOverlap( int[] assignment1, int[] assignment2 )
{
    return ( assignment1[0] >= assignment2[0] && assignment1[1] <= assignment2[1] 
    || assignment2[0] >= assignment1[0] && assignment2[1] <= assignment1[1]);
}

bool IsAnyOverlap( int[] assignment1, int[] assignment2 )
{
    return !( assignment1[1] < assignment2[0] || assignment2[1] < assignment1[0] );
}
