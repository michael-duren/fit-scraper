namespace Shared;

public static class DotEnv
{
    public static void Load()
    {
        bool found = false;
        string filePath = Directory.GetCurrentDirectory();
        while (!found)
        {
            if (File.Exists(Path.Combine(filePath, ".env")))
            {
                found = true;
            }
            else
            {
                DirectoryInfo directoryInfo = new(filePath);
                // if we are at the users profile we don't want to move up further
                if (directoryInfo.Parent is null || directoryInfo.Parent.ToString() ==
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
                {
                    throw new FileNotFoundException(
                        $"Could not find a .env file starting from {Directory.GetCurrentDirectory()}");
                }

                filePath = directoryInfo.Parent.ToString();
            }
        }

        foreach (string line in File.ReadAllLines(Path.Combine(filePath, ".env")))
        {
            var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                continue;
            }

            Environment.SetEnvironmentVariable(parts[0].Trim('"'), parts[1].Trim('"'));
        }
    }
}