using GuestBook;



List<(string, int)> familyList = new();
do
{
   var newFamily = Methods.NewGuestFamily();
   familyList.Add(newFamily);
} while (Methods.AreNewFamiliesComming());



Methods.PrintOutFamilies(familyList);


