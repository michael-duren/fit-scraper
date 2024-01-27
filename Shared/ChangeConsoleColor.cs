namespace Shared;

public class ChangeConsoleColor : IDisposable
{
    private readonly ConsoleColor _originalColor;

    public ChangeConsoleColor(ConsoleColor newColor)
    {
        _originalColor = ForegroundColor;
        ForegroundColor = newColor;
    }

    public void Dispose()
    {
        ForegroundColor = _originalColor;
    }
}