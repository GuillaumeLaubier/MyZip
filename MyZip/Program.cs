// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using MyZip;
using MyZipArchiver;

if (args.Length == 0)
{
    Helper.PrintHelpMessage();
    return 0;
}
else
{
    List<string> files = new List<string>();
    
    foreach (string arg in args)
    {
        if (arg.StartsWith("-h"))
        {
            Helper.PrintHelpMessage();
            return 0;
        }
        else if (arg.StartsWith('-'))
        {
            // Ignore other options
        }
        else
        {
            files.Add(arg);
        }
    }

    if (files.Count > 0)
    {
        var myZipFile = files[0];
        files.RemoveAt(0);
        return MyZipArchiver.MyZipArchiver.Zip(myZipFile, files.ToArray());
    }
    
    Console.WriteLine("myzip error: Invalid command arguments. Use -h option for help.");
    return -1;
}