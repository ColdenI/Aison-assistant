using CWR;
using System;

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
                string fileName = DateTime.Now.Date.ToString().Split(new string[] { " " }, StringSplitOptions.None)[0] + "-log.txt";
                if (!System.IO.File.Exists(Path + fileName)) new CWRFile(Path + fileName).Write("");

                new CWRFile(Path + fileName).Append(DateTime.Now.ToString() + " -> " + str + "\n");
            }
        }
    }
}
