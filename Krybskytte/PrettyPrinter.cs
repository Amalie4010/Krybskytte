


/*HOW TO USE
 
 1)
Create text file in Text_Files folder

2)
Call method using text file name
PrettyPrinter.Printer("FileName.txt");

*/

static class PrettyPrinter
{
 
    //ATTRIBUTES
    
    
    //CONSTRUCTORS
    
    
    //METHODS
    
    
    //SOURCE: https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
    public static void Printer(string directory)
    {
        
        //Get full directory path
        directory = FindLocalPath() + "/Text_Files/" + directory;
        
        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr = new StreamReader(directory);
        
        //Read the first line of text
        string line = sr.ReadLine();
        
        //Continue to read until you reach end of file
        while (line != null)
        {
            //write the line to console window
            Console.WriteLine(line);
            
            //Read the next line
            line = sr.ReadLine();
        }
        //close the file
        sr.Close();
        Console.ReadLine();
    }

    public static string FindLocalPath()
    {

        string localDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        
        Console.WriteLine(localDir);

        return localDir;
    }



}