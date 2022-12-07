
var pairs = File.ReadAllLines( "input.txt" );

int totalRedundantPairs = pairs.Select( pair =>
{
    String[] assignments = pair.Split( "," );
    int[] assignment1 = Array.ConvertAll(assignments[0].Split( "-" ), int.Parse);
    int[] assignment2 = Array.ConvertAll(assignments[1].Split( "-" ), int.Parse);
    return IsOverlap(assignment1, assignment2) ? 1 : 0;
} ).Sum();

Console.WriteLine( totalRedundantPairs );

bool IsOverlap( int[] assignment1, int[] assignment2 )
{
    return ( assignment1[0] >= assignment2[0] && assignment1[1] <= assignment2[1] 
    || assignment2[0] >= assignment1[0] && assignment2[1] <= assignment1[1]);
}
