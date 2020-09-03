using System.IO;

namespace NaturalnieApp.ElzabDriver
{
    public class ElzabFileOperation
    {

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
            string fullPatch = patch + fileName;
            result = File.Exists(fullPatch);

            return result;
        }
    }
}
