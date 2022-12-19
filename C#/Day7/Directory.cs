
public class Directory
{
    public string Name { get; set; }
    public Directory? ParentDirectory { get; set; }
    public List<Directory> Directories { get; set; } = new();
    public List<FileData> Files { get; set; } = new();
    public int TotalSize { get; set; } = 0;

    public Directory(string name, Directory? parent)
    {
        Name = name;
        ParentDirectory = parent;
    }

    public Directory? GetChildDirectory( string directoryName )
    {
        return Directories.Find( d => d.Name == directoryName );
    }

    public void AddDirectory( string directoryName )
    {
        Directories.Add( new Directory( directoryName, this ) );
    }

    public void AddFile( string fileName, int size )
    {
        Files.Add( new FileData( fileName, size ) );
        UpdateTotalSize( size );
    }

    public void UpdateTotalSize( int add ) 
    {
        TotalSize += add;
        if( ParentDirectory is not null ) 
        {
            ParentDirectory.UpdateTotalSize( add );
        }
    }

    public void Print( int? totalSize = null)
    {
        Console.WriteLine( $"\t- {Name} (dir)");
        Directories.ForEach( directory => 
        {
            directory.Print( totalSize );
        });

        Files.ForEach( file => 
        {
            file.Print();
        });
    }

    public static List<Directory> GetDirectoriesWithMaxSize( Directory directory, int maxSize )
    {
        var allDirectories = directory.Directories.Select( d => 
        {
            List<Directory> directories = Directory.GetDirectoriesWithMaxSize( d, maxSize );
            if( d.TotalSize <= maxSize ) 
            {
                directories.Add( d );
            }
            return directories;
        } ).SelectMany( d => d ).ToList();

        return allDirectories;
    }

    public static List<Directory> GetDirectoriesWithMinSize( Directory directory, int maxSize )
    {
        var allDirectories = directory.Directories.Select( d => 
        {
            List<Directory> directories = Directory.GetDirectoriesWithMinSize( d, maxSize );
            if( d.TotalSize >= maxSize ) 
            {
                directories.Add( d );
            }
            return directories;
        } ).SelectMany( d => d ).ToList();

        return allDirectories;
    }
}