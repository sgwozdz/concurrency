var mutex = new Mutex();
var flag = false;

var pingThread = new Thread(Ping);
var pongThread = new Thread(Pong);

// allows application to exit after sleep in ln 14
pingThread.IsBackground = true;
pongThread.IsBackground = true;

pingThread.Start();
pongThread.Start();

Thread.Sleep(1000);

void Ping()
{
    while (true)
    {
        mutex.WaitOne();

        while (flag)
        {
            mutex.ReleaseMutex();
            mutex.WaitOne();
        }
        
        Console.WriteLine("Ping");
        flag = true;
        
        mutex.ReleaseMutex();
    }
}

void Pong()
{
    while (true)
    {
        mutex.WaitOne();

        while (!flag)
        {
            mutex.ReleaseMutex();
            mutex.WaitOne();
        }
        
        Console.WriteLine("Pong");
        flag = false;
        
        mutex.ReleaseMutex();
    }
}