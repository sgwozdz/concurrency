var threads = new List<Thread>();
long a = 0;
long b = 0;
for (var i = 0; i < 10; i++)
{
    threads.Add(new Thread(() =>
    {
        for (long k = 0; k < 100000; k++)
        {
            a++;
            Interlocked.Increment(ref b);
        }
    }));
}

threads.ForEach(t => t.Start());
threads.ForEach(t => t.Join());


Console.WriteLine($"a equals {a}");
Console.WriteLine($"b equals {b}");
