using System;

class IndexOutOfRangeExceptionCustom : Exception
{
    public IndexOutOfRangeExceptionCustom(string message) : base(message)
    {
    }
}

class VectorByte
{
    private byte[] ByteArray;
    private uint size;
    private static uint num_vec;

    public VectorByte()
    {
        ByteArray = new byte[1];
        ByteArray[0] = 0;
        size = 1;
        num_vec++;
    }

    public VectorByte(uint size)
    {
        ByteArray = new byte[size];
        for (var i = 0; i < size; i++)
        {
            ByteArray[i] = 0;
        }

        this.size = size;
        num_vec++;
    }

    public VectorByte(uint size, byte num)
    {
        ByteArray = new byte[size];
        for (var i = 0; i < size; i++)
        {
            ByteArray[i] = num;
        }

        this.size = size;
        num_vec++;
    }

    ~VectorByte()
    {
        Console.WriteLine("Destructor");
    }

    public void inputArr()
    {
        for (var i = 0; i < size; i++)
        {
            byte.TryParse(Console.ReadLine(), out ByteArray[i]);
        }
    }

    public void printArr()
    {
        for (var i = 0; i < size; i++)
        {
            Console.Write($"{ByteArray[i]} ");
        }
        Console.WriteLine();
    }

    public void setArr(byte num)
    {
        for (var i = 0; i < size; i++)
        {
            ByteArray[i] = num;
        }
    }

    public uint getSize()
    {
        return size;
    }

    public byte this[uint index]
    {
        get
        {
            if (index >= size)
            {
                throw new IndexOutOfRangeExceptionCustom("Index is out of range.");
            }
            return ByteArray[index];
        }
        set
        {
            if (index >= size)
            {
                throw new IndexOutOfRangeExceptionCustom("Index is out of range.");
            }
            else
            {
                ByteArray[index] = value;
            }
        }
    }
}

class Market
{
    public event EventHandler<string> Rise; // Event for rise
    public event EventHandler<string> Fall; // Event for fall

    public void SimulateRise()
    {
        Console.WriteLine("Market is rising...");
        Rise?.Invoke(this, "Market is rising."); // Raise the rise event
    }

    public void SimulateFall()
    {
        Console.WriteLine("Market is falling...");
        Fall?.Invoke(this, "Market is falling."); // Raise the fall event
    }
}

class Bull
{
    public Bull(Market market)
    {
        market.Rise += (sender, message) => Console.WriteLine($"Bull received: {message}");
    }
}

class Bear
{
    public Bear(Market market)
    {
        market.Fall += (sender, message) => Console.WriteLine($"Bear received: {message}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lab#10");
        Console.WriteLine("Task 1");
        VectorByte vector = new VectorByte(5, 1);

        try
        {
            Console.WriteLine($"Trying to print [2]: {vector[2]}");
            Console.WriteLine($"Trying to print [6]: {vector[6]}");
        }
        catch (IndexOutOfRangeExceptionCustom ex)
        {
            Console.WriteLine($"Custom Exception: {ex.Message}");
        }

        Console.WriteLine("End of task 1.");

        Console.WriteLine("Task 2");
        Market market = new Market();
        Bull bull = new Bull(market);
        Bear bear = new Bear(market);

        // Simulate market events
        market.SimulateRise();
        market.SimulateFall();

        Console.WriteLine("End of task 2.");
    }
}

