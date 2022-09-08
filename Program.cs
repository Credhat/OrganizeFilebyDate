namespace OrganizePLNfiles;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //实例化文件操作对象
        Console.WriteLine("Pls input organized files DirPath: ");
        string userInputPath_console = Console.ReadLine();
        OrganizeFilesOperation organizeFilesOperation = new OrganizeFilesOperation(userInputPath_console);
        String[] filesCreatedTimesAll = organizeFilesOperation.FilesCreatedTime();
        organizeFilesOperation.CreatDirectories(filesCreatedTimesAll);

        #region EnterToExitConsole

        Console.Write("Press <Enter> to exit... \r\n");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }

        #endregion


    }
}
