namespace Shared;

public class Banner
{
    public static void WriteBanner(string title, char c, int maxLength = 75)
    {
        int seperatorLength = (maxLength - title.Length) / 2;
        seperatorLength = seperatorLength % 2 == 0 ? seperatorLength : seperatorLength + 1;
        WriteLine();
        string separator = new string(c, seperatorLength);

        Write(separator);
        Write(title);
        Write(separator);

        WriteLine();
        Write(separator);
        Write(new string(c, title.Length));
        Write(separator);
        WriteLine();
        WriteLine();
    }
}