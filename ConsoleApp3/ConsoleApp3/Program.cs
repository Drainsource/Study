

Console.WriteLine(Factorial(4));

int Factorial(int x)
{
    if (x > 1)
    {
        return Factorial(x -1) * x;
    }

    return x;
}

