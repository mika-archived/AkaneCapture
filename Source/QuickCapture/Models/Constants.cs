using System;
using System.IO;

namespace QuickCapture.Models
{
    internal static class Constants
    {
        public static string ApplicationDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mochizuki.moe", "QuickCapture");

        public static string HistoryFilePath => Path.Combine(ApplicationDir, "histories.json");
        public static string SituationsDirPath => Path.Combine(ApplicationDir, "situations");
    }
}