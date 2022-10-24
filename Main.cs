using FileHandling;
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello.");
        Console.WriteLine("Type the full filepath of the file that you want to move. Then press enter.");
        string currentFilePath = Console.ReadLine();
        Console.WriteLine("Type the full path of the directory for where you want to move the file too. Add the filename if you want it to change. Then press enter.");
        string destinationFilePath = Console.ReadLine();
        LongFilePaths.MoveFile(currentFilePath, destinationFilePath);
    }
}