
const int CRATE_SIZE = 3;
const int SPACE_BETWEEN_CRATES = 1;
const int MAX_STACKS = 9;
const string INITAL_ACTION = "move";

bool searchingForCrates = true;

List<Stack<char>> stacksOfCrates = new();
List<string> lines = File.ReadAllLines( "input.txt" ).ToList(); 

for( int i = 0; i < MAX_STACKS; i++ ) 
{
    stacksOfCrates.Add( new Stack<char>() );
}

lines.ForEach( line => 
{
    if( searchingForCrates )
    {
        if( !SearchForCrates( line ) ) 
        {
            searchingForCrates = false;
            ReverseStacks();
        }
    }

    if ( line.Contains( INITAL_ACTION ) ) 
    {
        string[] splitStrings = line.Split( " " );
        int[] values = splitStrings.Where(s => int.TryParse(s, out _)).Select(i => Convert.ToInt32(i)).ToArray();
        ProcessInstructionV2( values );
    }
} );


foreach ( var stack in stacksOfCrates )
{
    if( stack.Count > 0 ) 
    {
        Console.Write( stack.ElementAt( 0 ) );
    } 
}

bool SearchForCrates( string line )
{
    bool crateFound = false;
    int charIndex = 0;
    while ( charIndex < line.Length ) 
    {
        if( charIndex % ( CRATE_SIZE + SPACE_BETWEEN_CRATES ) == 0 )
        {
            if( line[charIndex] == '[' )
            {
                crateFound = true;
                int crateIndex = (int)charIndex / CRATE_SIZE + SPACE_BETWEEN_CRATES;
                stacksOfCrates[crateIndex].Push( line[charIndex + 1] );
            }
        }

        charIndex++;
    }

    return crateFound;
}

// Part 1
void ProcessInstructionV1( int[] values ) 
{
    int cratesToMove = values[0];
    int stackToMoveFrom = values[1] - 1;
    int stackToMoveTo = values[2] - 1;

    for( int i = 0; i < cratesToMove; i++ )
    {
        var crate = stacksOfCrates[stackToMoveFrom].Pop();
        stacksOfCrates[stackToMoveTo].Push(crate);
    }
}

// Part 2
void ProcessInstructionV2( int[] values ) 
{
    int cratesToMove = values[0];
    int stackToMoveFrom = values[1] - 1;
    int stackToMoveTo = values[2] - 1;

    List<char> crates = new List<char>();

    for( int i = 0; i < cratesToMove; i++ )
    {
        crates.Add( stacksOfCrates[stackToMoveFrom].Pop());
    }
    
    crates.Reverse();
    crates.ForEach( c => stacksOfCrates[stackToMoveTo].Push(c));
    
}

void ReverseStacks()
{
    // Very inefficient, I know 
    stacksOfCrates = stacksOfCrates.Select( stack => 
    {
        var newStack = new Stack<char>();
        while( stack.Count > 0 )
        {
            newStack.Push(stack.Pop());
        }
        return newStack;
    }).ToList() ;
}
