using System.Reflection.Metadata.Ecma335;

interface ICounter
{
    void Increase();
    public int Current { get; }
}

class Counter : ICounter
{
    private int current;
    public int Current => current;

    public void Increase()
    {
        current++;
    }
}

class CounterService(ICounter counter)
{
    private ICounter counter = counter;

    public void Increase() => counter.Increase();
    public int Current => counter.Current;
}