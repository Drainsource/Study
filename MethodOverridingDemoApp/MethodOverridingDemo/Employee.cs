
using MethodOverridingDemo;

public class Employee : PersonModel
{
    public decimal HourlyRate { get; set; }
    public virtual decimal GetPayceckAmount(int hoursWorked) 
    { 
        return HourlyRate * hoursWorked;
    }
}
