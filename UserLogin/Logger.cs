using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UserLogin
{
    static public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
             + LoginValidation.currentUserRoles + ";"
             + LoginValidation.currentUserRoles + ";"
             + activity;
            currentSessionActivities.Add(activityLine);
            StreamWriter sr = new StreamWriter("test.txt");
            sr.Write(activityLine);
            sr.Close();
        }

        static public void ReadLogFile()
        {
            StreamReader streamReader = new StreamReader("test.txt");
            Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }
        static public void GetCurrentSessionActivities()
        {
            Console.WriteLine(currentSessionActivities);
        }
    }
}
