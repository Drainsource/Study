public class CommissionEmployeeModel : Employee
{
    public decimal CommissionAmount { get; set; }

    public override decimal GetPayceckAmount(int hoursWorked)
    {
        decimal initialPay = base.GetPayceckAmount(hoursWorked);
        return initialPay + CommissionAmount;
    }
}
