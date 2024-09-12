using System;
using System.IO;

public static class DotEnv
{
    private static string GetEnvFilePath()
    {
        var entryAssembly = System.Reflection.Assembly.GetExecutingAssembly();
        if (entryAssembly == null)
        {
            throw new Exception("Cannot find entry assembly.");
        }

        var projectDir = Path.GetDirectoryName(entryAssembly.Location);

        if (projectDir == null)
        {
            throw new Exception("Cannot find project directory.");
        }

        var envFilePath = Path.Combine(projectDir, ".env");

        return envFilePath;
    }
    public static void Load()
    {
        var envFilePath = GetEnvFilePath();

        if (!File.Exists(envFilePath))
        {
            throw new FileNotFoundException($"File {envFilePath} not found.");
        }

        var envLines = File.ReadAllLines(envFilePath);
        foreach (var line in envLines)
        {
            var firstEqualIndex = line.IndexOf('=');
            if (firstEqualIndex == -1)
            {
                continue;
            }

            var key = line.Substring(0, firstEqualIndex);
            var value = line.Substring(firstEqualIndex + 1);

            if (value.StartsWith("\"") && value.EndsWith("\""))
            {
                value = value[1..^1];
            }

            Environment.SetEnvironmentVariable(key, value);
        }
    }
}