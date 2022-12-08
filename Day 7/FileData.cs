public class FileData
{
    public string Name { get; set; } = String.Empty;
    public int Size { get; set; } = 0;

    public FileData(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public void Print()
    {
        Console.WriteLine( $"\t {Name} (File, Size={Size})" );
    }
}