﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Empeek.WebApi.Models
{
    public class SearchingFilesAndDirectories
    {
        private static SearchingFilesAndDirectories _result = new SearchingFilesAndDirectories();

        public static SearchingFilesAndDirectories Current { get { return _result; } }

        private string exceptionMessage = "";
        private bool exception = false;
        private List<string> dataDisk = new List<string>();
        private List<string> dataDir = new List<string>();
        public List<string> dataFile = new List<string>();
        private FilesAndDirsEntity dataEntity = new FilesAndDirsEntity();

        //private SearchingFilesAndDirectories(string path)
        //{
        //    _search.dataEntity = Set(path);
        //}


        public FilesAndDirsEntity Set(string path)
        {
            ResetValues();

            dataDir = GetAllDirs(path);

            if (dataDisk.Count == 0)
            {
                dataDisk = GetHardDisks();
            }

            if (dataEntity.CurrentPath != null && dataEntity.CurrentPath.Length >= 4)
            {
                dataEntity.BackPath = BackPath(dataEntity.CurrentPath);
            }

            dataEntity.ExceptionMessage = exceptionMessage;
            dataEntity.Exception = exception;
            dataEntity.DataDisk = dataDisk;
            dataEntity.DataDir = dataDir;
            dataEntity.DataFile = dataFile;

            return dataEntity;
        }

        private List<string> GetAllDirs(string path)
        {
            dataEntity.CurrentPath = path;
            SeeDirContents(path);
            GetCount(path);
            return dataDir;
        }

        #region FIRST TASK

        // Get all directories and files in current directory
        private void SeeDirContents(string path)
        {
            // Find all subdirectories and files
            if (Directory.Exists(path))
            {
                try
                {
                    dataDir.AddRange(Directory.GetDirectories(path).ToList());
                }
                catch
                {
                    exception = true;
                    exceptionMessage = "Denied access on the path " + path;
                    return;
                }

                try
                {
                    var tempList = Directory.GetFiles(path).ToList();
                    foreach (var item in tempList)
                    {
                        dataFile.Add(item.Split('\\').LastOrDefault());
                    }
                }
                catch
                {
                    exception = true;
                    exceptionMessage = "Access is denied to the file " + path.Split('\\').LastOrDefault();
                    return;
                }
            }
            else return;
        }

        #endregion

        #region SECOND TASK

        // Get count files
        private void GetCount(string strPath)
        {
            if (!Directory.Exists(strPath))
                return;

            DirectoryInfo dir = new DirectoryInfo(strPath);

            GetCountAllFiles(dir);
        }

        // Get Count All Files In Curent Directories And Subdirectories
        List<FileInfo> dirGetFiles = new List<FileInfo>();
        private void GetCountAllFiles(DirectoryInfo dir)
        {
            dirGetFiles.Clear();
            // Cheking if UnauthorizedAccessException Проверка для случаев, когда отказано в доступе к файлу или директории
            try
            {
                dirGetFiles.AddRange(dir.GetFiles());
            }
            catch
            {
                return;
            }

            foreach (FileInfo fileInfo in dirGetFiles)
            {
                if (fileInfo.Length <= 10485760)
                    dataEntity.Less10Mb++;
                else if (10485760 <= fileInfo.Length && fileInfo.Length <= 52428800)
                    dataEntity.More10Less50Mb++;
                else if (52428800 <= fileInfo.Length && fileInfo.Length <= 104857600)
                    dataEntity.More50Less100Mb++;
                else dataEntity.More100Mb++;
            }

            try
            {
                foreach (DirectoryInfo subDirs in dir.GetDirectories())
                {
                    if (subDirs.Attributes != FileAttributes.Directory)
                        continue;
                    GetCountAllFiles(subDirs);
                }
            }
            catch
            {
                return;
            }
        }

        #endregion

        // Get hard disks 
        private List<string> GetHardDisks()
        {
            foreach (var item in DriveInfo.GetDrives())
            {
                dataDisk.Add(item.ToString());
            }
            return dataDisk;
        }

        private string BackPath(string str)
        {
            //dataEntity.BackPath = 
            string item = dataEntity.CurrentPath.Remove(dataEntity.CurrentPath.LastIndexOf('\\'));
            if (item.Length == 2)
            {
                item = item + @"\";
            }
            return item;
        }

        private void ResetValues()
        {
            exception = false;
            exceptionMessage = "";
            dataEntity.Less10Mb = 0;
            dataEntity.More10Less50Mb = 0;
            dataEntity.More50Less100Mb = 0;
            dataEntity.More100Mb = 0;
            dataEntity.CurrentPath = "";
            dataDir.Clear();
            dataFile.Clear();
        }
    }
}
