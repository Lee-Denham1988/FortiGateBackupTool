using System.IO;
using Microsoft.Extensions.Configuration;

static IConfigurationRoot LoadConfiguration()
{
    return new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
}

static void main()
{
    var config = LoadConfiguration();

    string RootFilePath = config["Backup:RootFilePath"];
    string TempRootFilePath = config["Backup:TempRootFilePath"];
    string fortigateUrl = config["Fortigate:Url"];
    string apiToken = config["Fortigate:ApiToken"];

    try
    {
        Console.WriteLine("Fortigate Backup Service Starting...");

        while (true)
        {
            String Todaysdate = DateTime.Now.ToString("dd-MMMM-yyyy");

            if (!Directory.Exists(RootFilePath + Todaysdate))
            {
                Directory.CreateDirectory(RootFilePath + Todaysdate);
            }

            string FileSource = TempRootFilePath + "\\backup_.conf";
            bool FileExists = File.Exists(FileSource);

            if (FileExists)
            {
                string DateTimeLog = DateTime.Now.ToString("dd_MM_yyyy_HH_mm");
                string FileDest = RootFilePath + "\\" + Todaysdate + "\\" + DateTimeLog + "_backup.conf";

                File.Move(FileSource, FileDest);
                Console.WriteLine("Moving files to: " + FileDest);
            }
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex);
    }
}

main();

