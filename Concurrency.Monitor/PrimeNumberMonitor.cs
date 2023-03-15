namespace Concurrency.Monitor;

using System.Threading;

public static class PrimeNumberMonitor
{
    private static bool _found;
    private static int _currentNumber = 1;
    private static readonly List<int> Primes = new();
    private static readonly object LockObj = new();
    
    private static bool ShouldContinue => Primes.Count < 10;

    public static void Print()
    {
        while (ShouldContinue)
        {
            Monitor.Enter(LockObj);

            while (!_found && ShouldContinue)
            {
                Monitor.Wait(LockObj);
            }

            Console.WriteLine("Next prime number is " + Primes.Last());

            _found = false;
            Monitor.PulseAll(LockObj);
            Monitor.Exit(LockObj);
        }
    }

    public static void Find()
    {
        while (ShouldContinue)
        {
            Monitor.Enter(LockObj);
            while (_found && ShouldContinue)
            {
                Monitor.Wait(LockObj);
            }

            if (IsPrime(_currentNumber))
            {
                _found = true;
                Primes.Add(_currentNumber);
                Monitor.PulseAll(LockObj);
            }

            _currentNumber++;
            Monitor.Exit(LockObj);
        }
    }

    private static bool IsPrime(int n)
    {
        switch (n)
        {
            case <= 1:
                return false;
            case 2:
                return true;
            default:
            {
                var p = (int)Math.Pow(2, n - 1) % n;
                return p == 1;
            }
        }
    }
}