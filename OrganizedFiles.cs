
using System.Diagnostics;


public class OrganizeFilesOperation
{
    #region privateField

    //获取软件当前位置
    private static string defaultPath = (Directory.GetCurrentDirectory() == null) ? "Null" : Directory.GetCurrentDirectory();
    //用户输入地址
    private string userInputPath = string.Empty;
    //获取当前目录所有文件流数组
    private FileInfo[] fileInfo;
    private int filesNumberTotal = 0;
    private DirectoryInfo directoryInfo;

    #endregion

    //默认iface.DLL地址
    public static string ifaceDllPath_Default = "C:\\Program Files\\AspenTech\\Aspen HYSYS V14.0\\iface.dll";
    // public FileInfo[] FileInfos
    // {
    //     get
    //     {
    //         return this.fileInfo;
    //     }
    //     set
    //     {
    //         this.fileInfo = value;
    //     }
    // }

    #region  初始化构造器

    public OrganizeFilesOperation()
    {
        this.directoryInfo = new DirectoryInfo(defaultPath.Trim('"'));
        this.fileInfo = directoryInfo.GetFiles();
        this.filesNumberTotal = this.fileInfo.Count<FileInfo>();
#if !DEBUG
        Console.WriteLine("Created by NoneParameter Method");
#endif
    }

    public OrganizeFilesOperation(string path)
    {
        //处理输入文本
        this.userInputPath = String.IsNullOrEmpty(path) ? defaultPath : path;
        this.userInputPath = this.userInputPath.Trim('"');
        //处理结束
        //判断输入字符串是文件还是文件夹
        if (File.Exists(this.userInputPath))
        {
            this.fileInfo = new FileInfo[1];
            fileInfo[0] = new FileInfo(userInputPath);
            this.filesNumberTotal = this.fileInfo.Count<FileInfo>();
        }
        else if (Directory.Exists(this.userInputPath))
        {
            this.directoryInfo = new DirectoryInfo(this.userInputPath);
            this.fileInfo = directoryInfo.GetFiles();
            this.filesNumberTotal = this.fileInfo.Count<FileInfo>();
        }
        else
        {
            Console.WriteLine("---------------Wrong Path or DIR/File doesn't exist.-------------\r\n ");
        }

#if !DEBUG
        Console.WriteLine("Created by Parameter Method --- Path: {0}", userInputPath);
#endif

    }


    #endregion


    #region 文件操作函数
    //获取所有文件数
    public int FilesNumberTotal()
    {
        return filesNumberTotal;
    }

    //获取所有文件名
    public string[] FilesName()
    {
        string[] tempFilesNameArray = new string[filesNumberTotal];
        for (int i = 0; i < filesNumberTotal; i++)
        {
            tempFilesNameArray[i] = fileInfo[i].Name;
        }
        return tempFilesNameArray;
    }

    //获取所有文件创建时间(HashSet)
    public string[] FilesCreatedTime()
    {
        string[] tempFilesCreatedTimeArray = new string[filesNumberTotal];
        for (int i = 0; i < filesNumberTotal; i++)
        {
            DateTime fileInfoDateTime = fileInfo[i].LastWriteTime;
            tempFilesCreatedTimeArray[i] = "Month " + fileInfoDateTime.Month + "-Day " + fileInfoDateTime.Day + "-Hr " + fileInfoDateTime.Hour + "-Y " + fileInfoDateTime.Year;
            Console.WriteLine("Add item: {0}", tempFilesCreatedTimeArray[i]);
        }
        HashSet<string> createdTime_HashSet = tempFilesCreatedTimeArray.ToHashSet<string>();
        tempFilesCreatedTimeArray = new string[createdTime_HashSet.Count];

        // for (int i = 0; i < createdTime_HashSet.Count; i++)
        // {

        //     tempFilesCreatedTimeArray[i] = createdTime_HashSet[i];
        // }
        createdTime_HashSet.CopyTo(tempFilesCreatedTimeArray);

        return tempFilesCreatedTimeArray;
    }

    //根据文件创建时间创建文件夹
    public void CreatDirectories(string[] filesTime)
    {
        if (filesTime.Length <= 0 || String.IsNullOrEmpty(filesTime[0]))
        {
            throw new ArgumentOutOfRangeException("No Files Created Time Get!");
        }

        foreach (var item in filesTime)
        {
            directoryInfo.CreateSubdirectory(item);
            Console.WriteLine("Dir: {0} created!", item);
        }
        Console.WriteLine("All Dir created!");
    }
    //获取文件InfoVersion
    public void PrintFileInfoVersion()
    {
        if (filesNumberTotal > 0 && fileInfo[0].Exists)
        {
            FileVersionInfo fVersionInfo = FileVersionInfo.GetVersionInfo(fileInfo[0].FullName);
            Console.WriteLine("\r\nFile {0} detected.\r\n-Current_ProductVersion: {1} \r\n-Current_FileVersion: {2}\r\n", fileInfo[0].Name, fVersionInfo.ProductVersion, fVersionInfo.FileVersion);
        }
        else
        {
            new ArgumentOutOfRangeException("-------------文件未找到！文件位置或者文件名错误~(Files unmatched! Maybe caused by wrong path.)--------");
        }
    }

    #endregion
}