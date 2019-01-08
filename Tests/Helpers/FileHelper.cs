using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Tests.Helpers
{
    public static class FileHelper
    {
        public static T GetEntityFromJsonFile<T>(string jsonName)
        {
            var jsonPath = GetFileFullName(jsonName + ".json");
            var jsonString = File.ReadAllText(jsonPath);
            var entity = JsonConvert.DeserializeObject<T>(jsonString);
            return entity;
        }

        private static string GetFileFullName(string fileName)
        {
            var dirInfo = new DirectoryInfo(PathHelper.GetProjectPath());
            var filesInfo = dirInfo.GetFiles(fileName, SearchOption.AllDirectories).Single();
            return filesInfo.FullName;
        }
    }
}
