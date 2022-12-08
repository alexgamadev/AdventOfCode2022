var data = File.ReadAllLines( "input.txt" ).ToList();

int TREE_COUNT_COLUMNS = data[0].Length;
int TREE_COUNT_ROWS = data.Count;

var totalTrees = data.Select( ( row, rowIndex ) => 
{
    if( rowIndex == 0 || rowIndex == TREE_COUNT_ROWS - 1) 
    {
        return TREE_COUNT_COLUMNS;
    }

    return row.Select( ( tree, colIndex) =>
    {
        if( colIndex == 0 || colIndex == TREE_COUNT_COLUMNS - 1 ) 
        {
            return 1;
        } 
        else
        {
            return GetVisible( data, rowIndex, colIndex ) ? 1 : 0;
        }
    }).Sum();
} ).Sum();

Console.WriteLine( totalTrees );


// I know this is horribly inefficient but it works and I'm in a rush, will optimise when done
bool GetVisible( List<string> data, int row, int col )
{
    int height = data[row][col];
    bool visibleLeft = true;
    bool visibleUp = true;
    bool visibleRight = true;
    bool visibleDown = true;

    // Check left
    for( int x = 0; x < col; x++ )
    {
        if( data[row][x] >= height )
        {
            // Not visible
            visibleLeft = false;
            break;
        }
    }

    // Check right
    for( int x = col + 1; x < TREE_COUNT_COLUMNS; x++ )
    {
        if( data[row][x] >= height )
        {
            // Not visible
            visibleRight = false;
            break;
        }
    }

    // Check up
    for( int y = 0; y < row; y++ )
    {
        if( data[y][col] >= height )
        {
            // Not visible
            visibleUp = false;
            break;
        }
    }

    // Check down
    for( int y = row + 1; y < TREE_COUNT_ROWS; y++ )
    {
        if( data[y][col] >= height )
        {
            // Not visible
            visibleDown = false;
            break;
        }
    }

    return visibleDown || visibleLeft || visibleRight || visibleUp;
}

