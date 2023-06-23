// See https://aka.ms/new-console-template for more information

using Delegete;
using DelegateLib;

CalculateIt<int> calculateInt = new ();
Console.WriteLine(calculateInt.SumOrSub(BasicCalc.Subtract, 2, 4));

CalculateIt<double> calculateDouble = new ();
Console.WriteLine(calculateDouble.SumOrSub(BasicCalc.Add,23.3,41.9));

Console.ReadLine();