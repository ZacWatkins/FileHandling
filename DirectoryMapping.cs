using System.Management.Automation;

namespace DirectoryMapping
{
    public class Mapping
    {
        public static void Map(string mapLetter, string directory)
        {
            UnMap(mapLetter);
            PowerShell.Create().AddCommand("SUBST " + mapLetter + ": '" + directory + "'").Invoke();
        }

        public static void UnMap(string mapLetter)
        {
            try
            {
                //Remove any mapping to V letter
                PowerShell.Create().AddCommand("SUBST " + mapLetter + ": /D").Invoke();
            }
            catch (Exception e)
            {
                //If this error occurs, it just means the letter was already unmapped and we can ignore it.
                if (e.Message.Contains("Unable to cast object of type 'System.String' to type 'System.Management.Automation.PSObject'."))
                {
                    Console.WriteLine("Error matches expected error. Error: " + e.Message);
                }
                else
                {
                    Console.WriteLine("NO MATCH for expected error. Error: " + e.Message);
                    throw;
                }
            }
        }
    }
}