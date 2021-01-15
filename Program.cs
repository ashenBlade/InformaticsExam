using System;
using System.IO;
using System.Xml;

namespace InformaticsExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            Console.WriteLine(new Tasks88_104().Task94(n));
        }

        #region CreateFileWithTasks

        private static void CreateFileWithTasks()
        {
            var file = new FileInfo("Tasks.txt");
            if (file.Exists && 0 < file.Length)
                return;
            if (!file.Exists)
                file.Create();

            using var fs = file.AppendText();
            for (int i = 88; i <= 104; i++)
                fs.WriteLine(i.ToString());
            for (int i = 110; i <= 119; i++)
                fs.WriteLine(i.ToString());
            for (int i = 334; i <= 336; i++)
                fs.WriteLine(i.ToString());
            for (int i = 373; i <= 396; i++)
                fs.WriteLine(i.ToString());
            for (int i = 676; i <= 693; i++)
                fs.WriteLine(i.ToString());
            for (int i = 802; i < 821; i++)
                fs.WriteLine(i.ToString());
        }

        #endregion

    }
}