using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace NaturalnieApp.ElzabDriver
{
    public class ElzabFileOperation
    {

        enum PathOrCommand
        {
            Path,
            Command,
            Null
        }




        /*========================================================================
         *====================== Method name = CheckElzabFilesExist ==============
         *                              Descritpion
         * Method used to check if file "fileName" exist under given "patch"
         * 
         *Input parameters: patch - patch where files to check are located; 
         *                  fileName - file name to check;
         *Output parameters: True - file exist under desire patch;
         *                   False - file does nto exist;
         */
        public bool CheckElzabFilesExist(string patch, string fileName)
        {
            bool result = false;
            /*
             *  TO DO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
             */
            return result;
        }

         /*========================================================================
         *====================== Method name = Execute command ==============
         *                              Descritpion
         * Method used to execute Elzab predefine command with "commandName"
         * 
         *Input parameters: commandName - command name to be executed;
         *Output parameters: void;
         */
        public void ExecuteCommand(string commandName)
        {
            bool fileExist = false;
            string commandFullPath = "";
            
            if (CheckPath(commandName) == PathOrCommand.Command)
            {
                //If only command name, add current directory as path
                string currentDirectory;
                currentDirectory = Directory.GetCurrentDirectory();

                commandFullPath = currentDirectory + "\\" + commandName;
            }
            else
            {
                commandFullPath = commandName;
            }

            //Check if file exist
            fileExist = File.Exists(commandFullPath);
            
            if (!fileExist)
            {
                throw new System.InvalidOperationException("Cannot find specified file under " + commandFullPath);
            }


        }

        /*========================================================================
        *====================== Method name = CheckPath ==============
        *                              Descritpion
        * Method used to check if given name is full path or just command name
        * 
        *Input parameters: path - full path or command name to be chack;
        *Output parameters: PathOrCommand - enum type;
*/
        private PathOrCommand CheckPath(string path)
        {
            PathOrCommand re = PathOrCommand.Null;

            //Verify if path or simple command name
            Regex r = new Regex(@"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$");
            if (r.IsMatch(path))
            {
                re = PathOrCommand.Path;
            }
            else
            {
                re = PathOrCommand.Command;
            }

            return re;
        }





    }
}
