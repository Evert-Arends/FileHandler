using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginModule
{
    class FileHandler
    {
        //Name = Filename (no extension!!), text = text for textfile, extension is file extention (example ".txt").
        //Set Encryption default to false. Unless you use DataEncryptor.cs (Copyed from so).
        public void writeToFile(string name, string text, string extension, Boolean encryption)
        {
           if(name == string.Empty || text == string.Empty || extension == string.Empty){
                name = "Error";
                text = "No value given...";
                extension = ".txt";
            }
            // Create a file to write to. 
            if(encryption == true)
            {
                text = encrypt(text);
                write(name, text, extension);

                //TO DECRYPT:
                //string actual=keys.DecryptString(encr);
            }
            else
            {
                write(name, text, extension);
            }
        }
        private string encrypt(string text)
        {
            DataEncryptor keys = new DataEncryptor();
            string encr = keys.EncryptString(text);
            return text = encr;

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
