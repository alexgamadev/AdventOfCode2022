
var data = File.ReadAllText("input.txt");
bool packetMarkerFound = false;
bool messageMarkerFound = false;
int currentIndex = 0;
const int PACKET_MARKER_LENGTH = 4;
const int MESSAGE_MARKER_LENGTH = 14;

while( !(packetMarkerFound && messageMarkerFound) )
{
    if ( !packetMarkerFound && IsDistinct( data.Substring( currentIndex, PACKET_MARKER_LENGTH ) ) )
    {
        Console.WriteLine( currentIndex + PACKET_MARKER_LENGTH );
        packetMarkerFound = true;
    }

    if ( !messageMarkerFound && IsDistinct( data.Substring( currentIndex, MESSAGE_MARKER_LENGTH ) ) )
    {
        Console.WriteLine( currentIndex + MESSAGE_MARKER_LENGTH );
        messageMarkerFound = true;
    }

    currentIndex++;
}

bool IsDistinct( string str )
{
    return str.Distinct().Count() == str.Length;
}



