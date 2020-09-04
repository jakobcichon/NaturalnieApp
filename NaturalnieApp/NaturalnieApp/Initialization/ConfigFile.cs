using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace NaturalnieApp.Initialization
{
    class ConfigFile
    {

        private class ConfigFileStruct
        {
            //To Do!!!!!!!!!!!!!!!!!!!!!!!1
            string Path1;
        }

        bool CheckIfConfigFileExist(string path)
        {
            //To Do!!!!!!!!!!!!!!!!!!!!!!!1
            return false;
        }

        bool CreateFile(string path, string fileName)
        {
            //To Do!!!!!!!!!!!!!!!!!!!!!!!1
            return false;
        }

        string[] ReadFile(string path, string fileName)
        {
            //To Do!!!!!!!!!!!!!!!!!!!!!!!1
            string[] returnVal = new string[] { "" } ;
            return returnVal;
        }

        ConfigFileStruct ParseConfigFile(string[] configFile)
        {
            //To Do!!!!!!!!!!!!!!!!!!!!!!!1
            ConfigFileStruct confFileParse = new ConfigFileStruct();
            return confFileParse;
        }

        void CreateConfigFile()
        {
            //To Do!!!!!!!!!!!!!!!!!!!!!!!1
        }
    }

    class ConfigFileDefaults
    {
        string ElzabCommandsPath = "";

        void Init()
        {
            this.ElzabCommandsPath = Directory.GetCurrentDirectory();

        }


        
    }
        
}
