








public static class ConsoleHelper
{
    public static string RequestString(this string message)
    {
        string output = "";

        while (string.IsNullOrWhiteSpace(output))
        {
            Console.Write(message);
            output = Console.ReadLine();
        }

        return output;
    }

    public static int RequestInt(this string message, int minValue, int maxValue)
    {
        return message.RequestInt(true, minValue, maxValue);
    }

    public static int RequestInt(this string message)
    {
        return message.RequestInt(false);
    }
    private static int RequestInt(this string message, bool useMinMax, int minValue = 0, int maxValue = 0)
    {
        bool isValid = false;
        bool isValidRange = true;
        int output = 0;
        do
        {
            Console.WriteLine(message);
            isValid = int.TryParse(Console.ReadLine(), out output);

            if (useMinMax == true)
            {
                if (output >= minValue && output  <= maxValue)
                {
                    isValidRange = true;
                }
                else
                {
                    isValidRange = false;
                }
            }

        } while (!isValid || !isValidRange);

        return output;
    }

}



