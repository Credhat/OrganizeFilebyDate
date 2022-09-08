using System;

public class OrganizeFilesOperation
{
    #region privateField

    //获取软件当前位置
    private static string defaultPath = (Directory.GetCurrentDirectory() == null) ? "Null" : Directory.GetCurrentDirectory();
    private string userInputPath = null;
    //获取当前目录所有文件流数组
    private FileInfo[] fileInfo;
    private int filesNumberTotal = 0;
    private DirectoryInfo directoryInfo;

    #endregion

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
        this.directoryInfo = new DirectoryInfo(defaultPath);
        this.fileInfo = directoryInfo.GetFiles();
        this.filesNumberTotal = this.fileInfo.Count<FileInfo>();
        Console.WriteLine("Created by NoneParameter Method");
    }

    public OrganizeFilesOperation(string path)
    {
        this.userInputPath = String.IsNullOrEmpty(path) ? defaultPath : path;
        this.directoryInfo = new DirectoryInfo(userInputPath);
        this.fileInfo = directoryInfo.GetFiles();
        this.filesNumberTotal = this.fileInfo.Count<FileInfo>();
        Console.WriteLine("Created by Parameter Method\t Path: {0}", userInputPath);
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
            DateTime fileInfoDateTime = fileInfo[i].CreationTime;
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


    #endregion
}