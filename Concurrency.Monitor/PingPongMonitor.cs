namespace Concurrency.Monitor;

using System.Threading;

public static class PingPongMonitor
{
    private static int _hits;
    private static bool _shouldContinue = true;
    private static readonly Random Random = new();
    private static readonly object LockObj = new();

    public static void Ping()
    {
        while (_shouldContinue)
        {
            Monitor.Enter(LockObj);

            while (_shouldContinue && _hits % 2 == 1)
            {
                Monitor.Wait(LockObj);
            }

            if (_shouldContinue)
            {
                if (IsHit())
                {
                    Console.WriteLine("Ping");
                    _hits++;
                }
                else
                {
                    Console.WriteLine("Miss");
                    _shouldContinue = false;
                }
            }

            Monitor.Pulse(LockObj);
            Monitor.Exit(LockObj);
        }
    }

    public static void Pong()
    {
        while (_shouldContinue)
        {
            Monitor.Enter(LockObj);

            while (_shouldContinue && _hits % 2 == 0)
            {
                Monitor.Wait(LockObj);
            }

            if (_shouldContinue)
            {
                if (IsHit())
                {
                    Console.WriteLine("Pong");
                    _hits++;
                }
                else
                {
                    Console.WriteLine("Miss");
                    _shouldContinue = false;
                }
            }

            Monitor.Pulse(LockObj);
            Monitor.Exit(LockObj);
        }
    }

    private static bool IsHit()
    {
        return Random.Next(1, 100) % 5 != 0;
    }
}