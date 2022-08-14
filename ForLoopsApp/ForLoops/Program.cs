
List<decimal> charges = new();

charges.Add(234M);
charges.Add(2M);
charges.Add(2344M);

decimal total = 0;

for (int i = 0; i < charges.Count; i++)
{
    total += charges[i];
}
