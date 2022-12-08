Directory root = new Directory( "/", null );
Directory currentDirectory = root;

const int TOTAL_SYSTEM_SIZE = 70_000_000;
const int MIN_UNUSED_SPACE = 30_000_000;

var data = File.ReadAllLines( "input.txt" ).ToList();

data.ForEach( line => 
{
    if( line.StartsWith( "$" ) ) 
    {
        ProcessCommand( line.Substring( 2 ) );
    } 
    else
    {
        string[] splitString = line.Split( " " );
        if( Char.IsDigit( line.Substring(0, 1)[0] ) )
        {
            int size = int.Parse( splitString[0] );
            string name = splitString[1];
            currentDirectory.AddFile( name, size );
        }
        else
        {
            currentDirectory.AddDirectory( splitString[1] );
        }
    }
} );

root.Print();

// Part 1
var limitedDirectories = Directory.GetDirectoriesWithMaxSize( root, 100000 );
var sum = limitedDirectories.Select( d => d.TotalSize ).Sum();
Console.WriteLine( sum );

// Part 2
int minSpaceToBeFreed = MIN_UNUSED_SPACE - (TOTAL_SYSTEM_SIZE - root.TotalSize);
var directoriesWithEnoughSpace = Directory.GetDirectoriesWithMinSize( root, minSpaceToBeFreed );
directoriesWithEnoughSpace.Sort( ( a, b ) => a.TotalSize - b.TotalSize );
Console.WriteLine( directoriesWithEnoughSpace[0].TotalSize );

void ProcessCommand( string command )
{
    string[] args = command.Split(" ");

    var successful = args[0] switch
    {
        "ls" => ListItems( args[0] ),
        "cd" => ChangeDirectory( args[1] ),
        _ => throw new ArgumentException( "Invalid Command")
    };
}


bool ListItems( string args )
{
    return true;
}

bool ChangeDirectory( string args )
{
    if( args == "/" ) 
    {
        currentDirectory = root;
    }
    else if( args == ".." ) 
    {
        if( currentDirectory.ParentDirectory is null )
        {
            throw new NullReferenceException( "Parent directory doesn't exist" );
        }
        currentDirectory = currentDirectory.ParentDirectory;
    } 
    else
    {
        var newDirectory = currentDirectory.GetChildDirectory( args );
        if( newDirectory is null )
        {
            throw new NullReferenceException( "Child directory doesn't exist" );
        }
        currentDirectory = newDirectory;
    }
    

    return true;
}



