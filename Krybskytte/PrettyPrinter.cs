


/*HOW TO USE
 
 1)
Create text file in Text_Files folder

2)
Call method using text file name
PrettyPrinter.TextToString("FileName.txt");

3)
TextToString returns a string. To print the string use Shell.PrintLine([returned string]);

*/

using Microsoft.Win32;
using System;

static class PrettyPrinter
{
 
    //ATTRIBUTES
    
    //CONSTRUCTORS
    
    
    //METHODS
    
    
    //SOURCE: https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
    public static string TextToString(string directory)
    {
        string text = "";
        
        //Get full directory path
        directory = FindLocalPath() + "/Text_Files/" + directory;
        
        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr = new StreamReader(directory);
        
        //Read the first line of the text-file
        string? line = sr.ReadLine();
        
        //Continue to read until you reach end of file
        while (line != null)
        {
            //Add the line to string text and shift to next line
            text = text + line + "\n";
            
            //Read the next line
            line = sr.ReadLine();
        }
        //Close the file
        sr.Close();
        
        return text;
    }

    public static string FindLocalPath()
    {

        string localDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        return localDir;
    }



}