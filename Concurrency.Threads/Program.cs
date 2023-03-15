using Concurrency.Threads;

static void SayHi()
{
    Console.WriteLine($"Hi from '{nameof(SayHi)}' method");
}

// method parameter have to be boxed
void SayHello(object? nameObject)
{
    var message = nameObject is string name
        ? $"Hello {name} from '{nameof(SayHello)}' method"
        : "Method requires valid string argument.";

    Console.WriteLine(message);
}

// basic thread
var threadStart = new ThreadStart(SayHi);
var thread = new Thread(threadStart);
thread.Start();
thread.Join();

// parametrized thread
var threadStart2 = new ParameterizedThreadStart(SayHello);
var thread2 = new Thread(threadStart2);
thread2.Start("John");
thread2.Join();

// callback & type safe property passing
const int input = 4;
var results = new SquareCalculator(input, res => { Console.WriteLine($"{input}^2 = {res}"); });
var threadStart3 = new ThreadStart(results.Square);
var thread3 = new Thread(threadStart3);
thread3.Start();
thread3.Join();

// nothing will be printed because ThreadPool consists of background threads
// only foreground thread hold up an application
ThreadPool.QueueUserWorkItem(_ =>
{
    Thread.Sleep(5000);
    Console.WriteLine("Hello");
});

