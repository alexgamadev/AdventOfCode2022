
var data = File.ReadAllLines("input.txt").ToList();

List<Vector> coordinatesVisited = new();
Vector currentHeadPos = new Vector(0, 0);
Vector currentTailPos = new Vector(0, 0);

data.ForEach( instruction =>
{
    var args = instruction.Split(" ");
    MoveHead(args[0], int.Parse(args[1]));
} );

void MoveHead(string direction, int distance)
{
    Vector moveVector = GetDirectionVector(direction);
    for( int d = 0; d < distance; d++ )
    {
        currentHeadPos += moveVector;
        UpdateTail();
    }
}

Vector GetFollowVector(Vector head, Vector tail)
{
    if( tail.IsAdjacent( head ) ) 
    {
        return new Vector(0, 0);
    }
    else
    {
        if( tail.X == head.X ) // Same row
        {
            int xMovement = head.X - tail.X > 0 ? 1 : -1;
            return new Vector(xMovement, 0);
        } 
        else if ( tail.Y == head.Y ) // Same column
        {
            int yMovement = head.Y - tail.Y > 0 ? 1 : -1;
            return new Vector(0, yMovement);
        }
        else
        {
            int xIncrement = head.X - tail.X;
            int yIncrement = head.Y - tail.Y;
        }
    }
}

void AddVisitedCoord(Vector coord)
{
    if (!coordinatesVisited.Contains(coord))
    {
        coordinatesVisited.Add(coord);
    }
}

Vector GetDirectionVector(string str)
{
    return str switch
    {
        "U" => DirectionVectors.UP,
        "L" => DirectionVectors.LEFT,
        "R" => DirectionVectors.RIGHT,
        "D" => DirectionVectors.DOWN,
        _ => throw new ArgumentOutOfRangeException("Direction doesn't exist")
    };
}

struct Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vector operator +(Vector a, Vector b)
        => new Vector(a.X + b.X, a.Y + b.Y);

    public static Vector operator ==(Vector a, Vector b)
        => a.X == b.X && a.Y == b.Y;

    public static Vector operator !=(Vector a, Vector b)
        => a.X != b.X || a.Y != b.Y;

    public static bool IsAdjacent(this Vector posA, Vector posB)
    {
        foreach( Vector dir in Enum.GetValues(typeof(DirectionVectors)))
        {
            if( posA + dir == posB ) 
            {
                return true;
            }
        }

        return false;
    }
}

enum DirectionVectors
{
    UP = new Vector(0, 1),
    RIGHT = new Vector(1, 0),
    DOWN = new Vector(0, -1),
    LEFT = new Vector(-1, 0),
    UP_LEFT = new Vector(-1, 1),
    UP_RIGHT = new Vector(1, 1),
    DOWN_LEFT = new Vector(-1, -1),
    DOWN_RIGHT = new Vector(1, -1),
}