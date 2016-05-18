using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//CHANGE NAMESPACE!1!1!11
namespace TestApp
{
    class FileHandler
    {
        //Name = Filename (no extension!!), text = text for textfile, extension is file extention (example ".txt").
        //Set Encryption default to false. Unless you use DataEncryptor.cs (Copyed from so).

        //Write to array: var filehandler = new FileHandler();
        //string test = filehandler.writeToFile("Kees", "okok", ".txt", false, true, arraysource);
        public string writeToFile(string name, string text, string extension, Boolean encryption, Boolean IsArray, string[] array = null)
        {
            if (name == string.Empty || text == string.Empty || extension == string.Empty)
            {
                return "1";
            }
            // Create a file to write to. 
            if (encryption)
            {
                text = encrypt(text);
            }
            if (IsArray)
            {
                writeArray(name, array, extension);
                return "1";
            }
            write(name, text, extension);
            return "0";
        }
        private string encrypt(string text)
        {
            return text += " This should be encrypted.";
        }
        private void write(string name, string text, string extension)
        {
            name += extension;
            string fileName = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), name);

            string fulltext = text + Environment.NewLine;
            File.WriteAllText(fileName, fulltext);
        }
        private void writeArray(string name, string[] array, string extension)
        {
            name += extension;
            string fileName = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), name);

            File.WriteAllLines(fileName, array);
        }

    }
}
