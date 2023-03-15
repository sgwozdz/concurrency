using System.Diagnostics;
using Concurrency.Monitor;
//
// // example 1
// var threads = new List<Thread>();
// var stopwatch = new Stopwatch();
// var objLock = new object();
// stopwatch.Start();
//
// for (var i = 0; i < 3; i++)
// {
//     threads.Add(new Thread(() =>
//     {
//         Monitor.Enter(objLock);
//         Console.WriteLine($"Thread id {Environment.CurrentManagedThreadId} enters the critical section");
//         Thread.Sleep(1000);
//         Console.WriteLine($"Thread id {Environment.CurrentManagedThreadId} exits the critical section");
//         Monitor.Exit(objLock);
//     }));
// }
//
// threads.ForEach(t => t.Start());
// threads.ForEach(t => t.Join());
//
// stopwatch.Stop();
// Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}");
//
// // example 2
// var finderThread = new Thread(PrimeNumberMonitor.Find);
// var finderThread2 = new Thread(PrimeNumberMonitor.Find);
// var finderThread3 = new Thread(PrimeNumberMonitor.Find);
// var printerThread = new Thread(PrimeNumberMonitor.Print);
//
// finderThread.Start();
// finderThread2.Start();
// finderThread3.Start();
// printerThread.Start();
//
// finderThread.Join();
// finderThread2.Join();
// finderThread3.Join();
// printerThread.Join();

// example 3
var pingThread = new Thread(PingPongMonitor.Ping);
var pongThread = new Thread(PingPongMonitor.Pong);

pingThread.Start();
pongThread.Start();

pingThread.Join();
pongThread.Join();
