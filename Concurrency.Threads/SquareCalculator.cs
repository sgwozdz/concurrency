namespace Concurrency.Threads;

public class SquareCalculator
{
    private readonly int _value;
    private readonly ResultCallback _callback;

    public SquareCalculator(int value, ResultCallback callback)
    {
        _value = value;
        _callback = callback;
    }

    public void Square()
    {
        var square = _value * _value;
        _callback(square);
    }
}