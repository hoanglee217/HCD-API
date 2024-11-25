using Hcd.Common.Exceptions;

namespace Hcd.Common
{
    public class EnvMigrateLoader
    {
        public static string LoadMigrateEnv()
        {
            string filePath = File.Exists(".env") ? ".env" : "../../../.env"; 
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The .env file was not found at path: {filePath}");
            }

            var lines = File.ReadAllLines(filePath);
            
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                {
                    continue;
                }

                var parts = line.Split('=', 2);

                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }
                    Environment.SetEnvironmentVariable(key, value);
                }
            }
            string CONNECTION_STRING = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new NotFoundException("CONNECTION_STRING is not set in the .env file.");
            return CONNECTION_STRING;
        }
    }
}