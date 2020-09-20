using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalnieApp.ElzabDriver
{
    class ElzabCommandGeneral
    {

    }

    //Class used to define single element of Elzab command.
    //Below visual explanation of naming convesion.
    //=====================================================
    //                   |  "AttributeName" = 1               |  "AttributeName" = 2            |
    //  "ElementName"    |  "AttributeValue" = TestValue1     |   "AttributeValue" = TestValue2 |
    class ElzabCommElementObject
    {
        //Define class elements
        private string ElementName { get; }
        private string[] AttributeName { get; set; }
        private string[] AttributeValue { get; set; }

        ElzabCommElementObject(string elementName)
        {
            this.ElementName = elementName;
        }

        //Method used to add new attribute to the element
        public void AddAttribute(string attributeName, string attributeValue)
        {
            this.AttributeName.Append(attributeName);
            this.AttributeValue.Append(attributeValue);
        }

        //Method used to find value of given element name. 
        //Only first occurence of element will be found.
        //If nothing found, return empty string
        public string FindAttribute(string attributeName)
        {
            //Local variables
            int index = 0;
            Boolean findingResult = false;

            //Loop through attribute name, to check if any of it element match given name
            for(int i = 0; i < this.AttributeName.Length; i++)
            {
                //If attribueName match, save index and break;
                if (attributeName == this.AttributeName[i])
                {
                    index = i;
                    findingResult = true;
                }
            }

            //Check if any of element match, if not return empty string
            if (findingResult)
            {
                return this.AttributeValue[index];
            }
            else
            {
                return "";
            }
            
        }

        //Method used to change value of given element name
        //Only first occurence of element will be changed.
        public void ChangeAttribute(string attributeName, string newValue)
        {
            //Loop through attribute name, to check if any of it element match given name
            for (int i = 0; i < this.AttributeName.Length; i++)
            {
                //If attribueName match, save index and break;
                if (attributeName == this.AttributeName[i])
                {
                    //Override value
                    this.AttributeValue[i] = newValue;
                }
            }

        }

        //Method used to delete given attribute and its value
        //Only first occurence of element will be deleted.
        public void DeleteAttribute(string attributeName)
        {
            //Loop through attribute name, to check if any of it element match given name
            for (int i = 0; i < this.AttributeName.Length; i++)
            {
                //If attribueName match, save index and break;
                if (attributeName == this.AttributeName[i])
                {
                    //Remove attribut and its value
                    this.AttributeValue = this.AttributeValue.Skip(i).ToArray();
                    this.AttributeName = this.AttributeName.Skip(i).ToArray();
                }
            }

        }



    }

    class Otowar_Command: ElzabCommandGeneral
    {
  
        
    }
}
