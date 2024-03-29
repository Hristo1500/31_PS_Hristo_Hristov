﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    public static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            StringBuilder sb = new StringBuilder();
            Logs logs = new Logs();
            sb.Append(DateTime.Now + "; ");
            sb.Append(LoginValidation.currentUserName + "; ");
            sb.Append(LoginValidation.currentUserRole + "; ");
            sb.Append(activity).Append(Environment.NewLine);

            string activityLine = sb.ToString();
            
            logs.LogContent = activityLine;
            currentSessionActivities.Add(activityLine);

            if (File.Exists("Logs.txt"))
            {
                File.AppendAllText("Logs.txt", activityLine);
            }

            LogContext logContext = new LogContext();
            logContext.Logs.Add(logs);
            logContext.SaveChanges();
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();

            return filteredActivities;
        }

        public static IEnumerable<string> GetLogsFromFile()
        {
            List<string> result = new List<string>();

            StreamReader sr = new StreamReader("Logs.txt");
            string line = String.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                result.Add(line);
                line = String.Empty;
            }

            sr.Close();

            return result;
        }
    }
}
