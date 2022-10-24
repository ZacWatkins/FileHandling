// See https://aka.ms/new-console-template for more information
using System.Management.Automation;
using DirectoryMapping;
using System.IO;

namespace FileHandling
{
    public class LongFilePaths
    {
        //Checks if Current or Destination file path lengths are greater than 256 characters. if they are, map them to drives and then do the move.
        public static void MoveFile(string CurrentFilePath, string DestinationFilePath)
        {
            //Check CurrentFilePath length and map directory to letter if needed
            string NewCurrentFilePath = CurrentFilePath;
            if (CurrentFilePath.Length > 256)
            {
                //Map the file to 
                Mapping.Map("V", CurrentFilePath.Replace("\\" + Path.GetFileName(CurrentFilePath), ""));
                //Assign newly created Current file path
                NewCurrentFilePath = "V:\\" + Path.GetFileName(CurrentFilePath);
            }
            //Check DestinationFilePath length and map directory to letter if needed
            string NewDestinationFilePath = DestinationFilePath;
            if (DestinationFilePath.Length > 256)
            {
                //Map the file to 
                Mapping.Map("X", DestinationFilePath.Replace("\\" + Path.GetFileName(DestinationFilePath), ""));
                //Assign newly created Destination file path
                NewDestinationFilePath = "X:\\" + Path.GetFileName(DestinationFilePath);
            }

            //MOVE THE FILE
            File.Move(NewCurrentFilePath, NewDestinationFilePath);

            //Same checks as above to see if UnMapping needed
            if (CurrentFilePath.Length > 256)
            {
                Mapping.UnMap("V");
            }
            if (DestinationFilePath.Length > 256)
            {
                Mapping.UnMap("X");
            }
        }
    }
}
