var semaphore1 = new SemaphoreSlim(0,1);
var semaphore2 = new SemaphoreSlim(0,1);

var pingThread = new Thread(() =>
{
    while (true)
    {
        semaphore1.Wait();
        Console.WriteLine("Ping");
        semaphore2.Release();
    }
});
var pongThread = new Thread(() =>
{
    while (true)
    {
        semaphore1.Release();
        semaphore2.Wait();
        Console.WriteLine("Pong");
    }
});

pingThread.IsBackground = true;
pongThread.IsBackground = true;

pingThread.Start();
pongThread.Start();

Thread.Sleep(1000);