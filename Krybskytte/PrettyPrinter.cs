

static class PrettyPrinter
{
 
    //ATTRIBUTES
    
    
    
    //CONSTRUCTORS
    
    
    
    
    //METHODS
    
    
    //SOURCE: https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
    public static void Printer(string directory)
    {
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
    
    
    
}