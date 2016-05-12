using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Testapp
{
    class FileHandler
    {
        //Name = Filename (no extension!!), text = text for textfile, extension is file extention (example ".txt").
        //Set Encryption default to false. Unless you use DataEncryptor.cs (Copyed from so).
        public string writeToFile(string name, string text, string extension, Boolean encryption)
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

    }
}
