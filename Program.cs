using System.IO;

static void main ()
{

    try
    {
        Console.WriteLine("Fortigate Backup Service Starting...");

        while (true)
        {
            string RootFilePath = @"\\NASBACKUP\Backup\InfrastructureBackups\FortiGates\";
            string TempRootFilePath = @"\\nasbackup\backup\InfrastructureBackups\FortiGateBackupTool\TempStore\";
            //string RootFilePath = @"D:\test\"; //Local testing path

            String Todaysdate = DateTime.Now.ToString("dd-MMMM-yyyy");
            
            if (!Directory.Exists(RootFilePath + Todaysdate))
            {
                Directory.CreateDirectory(RootFilePath + Todaysdate);
            }
            //Console.WriteLine(Todaysdate); //Printing foldername to test.

            string FileSource = TempRootFilePath + "\\backup_.conf";

            bool FileExists = File.Exists(FileSource);

            if (FileExists)
            {
                string DateTimeLog = DateTime.Now.ToString("dd_MM_yyyy_HH_mm");
                string FileDest = RootFilePath + "\\" + Todaysdate + "\\"+ DateTimeLog + "_backup.conf";

               File.Move(FileSource, FileDest); //Move files to destination.
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

