
List<string> rounds = File.ReadAllLines( "input.txt" ).ToList();
int playerScoreP1 = 0;
int playerScoreP2 = 0;

rounds.ForEach( round => {
    var actions = round.Split(" ");
    ACTION aiAction = GetAction(actions[0]);

    // Part 1
    ACTION playerAction = GetAction(actions[1]);
    playerScoreP1 += (int)GetRoundResult( aiAction, playerAction );
    playerScoreP1 += (int)playerAction;

    // Part 2
    OUTCOME expectedOutcome = GetExpectedOutcome(actions[1]);
    ACTION expectedAction = GetExpectedAction( aiAction, expectedOutcome );
    playerScoreP2 += (int)GetRoundResult( aiAction, expectedAction );
    playerScoreP2 += (int)expectedAction;
} );

Console.WriteLine( playerScoreP1 );
Console.WriteLine( playerScoreP2 );

ACTION GetAction( string actionCode ) 
{
    return actionCode switch
    {
        "A" or "X" => ACTION.ROCK,
        "B" or "Y" => ACTION.PAPER,
        "C" or "Z" => ACTION.SCISSORS,
        _ => throw new ArgumentOutOfRangeException("Invalid Action Code")
    };
}

OUTCOME GetExpectedOutcome( string actionCode ) 
{
    return actionCode switch 
    {
        "X" => OUTCOME.LOSE,
        "Y" => OUTCOME.DRAW,
        "Z" => OUTCOME.WIN,
        _ => throw new ArgumentOutOfRangeException("Invalid Expected Outcome")
    };
}

ACTION GetExpectedAction( ACTION aiAction, OUTCOME expectedOutcome ) 
{
    // Not efficient but works fine
    for( int i = 1; i <= 3; i++ )
    {
        var actionToTry = (ACTION)i;
        if ( (int)GetRoundResult(aiAction, (ACTION)i ) == (int)expectedOutcome )
        {
            return (ACTION)i;
        }
    }
    throw new Exception( "Invalid Expected Action " + aiAction + " " + expectedOutcome );
}

OUTCOME GetRoundResult( ACTION aiAction, ACTION playerAction ) 
{
    if( (int)aiAction == (int)playerAction ) 
    {
        return OUTCOME.DRAW;
    } 

    return playerAction switch
    {
        ACTION.ROCK => aiAction == ACTION.PAPER ? OUTCOME.LOSE : OUTCOME.WIN,
        ACTION.PAPER => aiAction == ACTION.SCISSORS ? OUTCOME.LOSE : OUTCOME.WIN,
        ACTION.SCISSORS => aiAction == ACTION.ROCK ? OUTCOME.LOSE : OUTCOME.WIN,
        _ => throw new ArgumentOutOfRangeException("Invalid Round Action")
    };
}

enum OUTCOME
{
    LOSE = 0,
    DRAW = 3,
    WIN = 6
}

enum ACTION 
{
    ROCK = 1,
    PAPER = 2,
    SCISSORS = 3
}

