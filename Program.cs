using System.IO;

static void main ()
{

    try
    {

        while (true)
        {
            string FileSource = @"\\nas2.lan\ConfigBackups\backup_.conf";

            bool FileExists = File.Exists(FileSource);

            if (FileExists)
            {
                string DateTimeLog = DateTime.Now.ToString("dd_MM_yyyy_HH_mm");
                string FileDest = @"\\nas2.lan\ConfigBackups\" + DateTimeLog + "_backup.conf";

                File.Move(FileSource, FileDest); //Move files to destination.
                
            }
        }

    }
    catch (IOException ex)
    {
        Console.WriteLine(ex); 
    }


}

main();

