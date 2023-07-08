using CWR;
using System;
using System.IO;

namespace Aison___assistant
{
    static class Loger
    {
        public static string Path = "data/logs/";
        public static bool isLog = true;

        public static void print(string str)
        {
            if (isLog)
            {
                if(!Directory.Exists(Path)) Directory.CreateDirectory(Path);
                string fileName = DateTime.Now.Date.ToString().Split(new string[] { " " }, StringSplitOptions.None)[0] + "-log.txt";
                if (!File.Exists(Path + fileName)) new CWRFile(Path + fileName).Write("");

                new CWRFile(Path + fileName).Append(DateTime.Now.ToString() + " -> " + str + "\n");
            }
        }
    }
}
