namespace DecryptWare
{
    public class Program
    {
        static void Main(string[] args)
        {
            DecryptFiles();
        }

        private static void DecryptFiles()
        {
            string dir = @"D:\Dev course\C#\learning C#\OpenSource\KingWare\KingWare\TestFiles";

            foreach (var file in Directory.GetFiles(dir))
            {
                string Filename = Path.GetFileName(file);

                if (Filename.Contains(".king"))
                {
                    string decryptedFilePath = Path.Combine(dir, Filename.Replace(".king", string.Empty));
                    SharpAESCrypt.SharpAESCrypt.Decrypt("password", file, decryptedFilePath);
                    File.Delete(file);
                }
            }

            Console.WriteLine("Your files have been decrypted successfully. \nThank you for your money");
        }
    }
}
