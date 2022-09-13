
namespace OrganizePLNfiles;
class Program
{

    static void Main(string[] args)
    {

        Console.SetWindowSize(width: 60, height: 30);
        Console.WriteLine("Hello, World!");


        while (true)
        {
            PrintFounciton();
            string userChoice = Console.ReadLine();
            userChoice = String.IsNullOrEmpty(userChoice) ? "Ur input is not right!Pls input right number." : userChoice;

            switch (userChoice)
            {
                case "1":
                    CreatDirs();
                    break;
                case "2":
                    OutputFileVersionInfo();
                    break;
                case "3":
                    Console.Clear();
                    continue;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("No fucntion selected! Go back to main menu.");
                    continue;
            }


        }

    }

    #region  输出功能信息表
    static void PrintFounciton()
    {
        Console.WriteLine("Choose function with Number_input in this Concole:");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("1: Organize Files by CreatedTime.");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("2: LookUp fileVersion Info.(iface.dll)");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("3: Go back to MainMenu.");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("|Tips: Input \"exit\" to exit|\r\n");
    }
    #endregion

    #region 输出文件Version信息
    static void OutputFileVersionInfo()
    {
        Console.WriteLine("\r\nInput iface will display iface.dll Version.");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Pls input file Full_Path with Name: ");
        string userInputPathAndName_console = Console.ReadLine();
        OrganizeFilesOperation organizeFilesOperation;
        if (userInputPathAndName_console.ToLower() == "iface")
        {
            organizeFilesOperation = new OrganizeFilesOperation(OrganizeFilesOperation.ifaceDllPath_Default);
        }
        else
        {
            organizeFilesOperation = new OrganizeFilesOperation(userInputPathAndName_console);
        }

        organizeFilesOperation.PrintFileInfoVersion();
    }
    #endregion

    #region  创建文件夹
    static void CreatDirs()
    {
        Console.WriteLine("\r\nPls input organized files DirPath: ");
        string userInputPath_console = Console.ReadLine();
        //实例化文件操作对象
        OrganizeFilesOperation organizeFilesOperation = new OrganizeFilesOperation(userInputPath_console);
        String[] filesCreatedTimesAll = organizeFilesOperation.FilesCreatedTime();
        organizeFilesOperation.CreatDirectories(filesCreatedTimesAll);
        Console.WriteLine("\r\n");
    }
    #endregion

    #region EnterToExitConsole
    static void EnterToExitConsole()
    {
        Console.Write("Press <Enter> to exit... \r\n");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }
    #endregion

}