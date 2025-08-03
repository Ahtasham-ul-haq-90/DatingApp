// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Singleton singleton = Singleton.Instance;
singleton.DoSomeWork();
grandchild grandchild = new grandchild();
public class grandchild
{
    Singleton singletons2 = Singleton.Instance;
    public grandchild()
    {
        singletons2.DoSomeWork();
    }

    public int Mul(int a, int b)
    {
        throw new NotImplementedException();
    }

    public int sum(int a, int b)
    {
        throw new NotImplementedException();
    }
}

public sealed class Singleton
{
    
    private static  Singleton _instance = null;
    private static readonly object _instanceLock = new object();
    private Singleton() { }
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                        _instance = new Singleton();
                }
            }
            return _instance;
        }
    }
    public void DoSomeWork()
    {
        Console.WriteLine("Do some work");
    }
}