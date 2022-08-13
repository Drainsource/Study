string firstName = "Tim";

int age = 43;

switch (age)
{
	case >= 0 and < 18:
		Console.WriteLine("You are a child");
		break;
		case >= 18 and < 66:
		Console.WriteLine("You should have a jobb");
		break;
	case >= 66:
		Console.WriteLine("Hopefully you are retired");
		break;
	default:
		Console.WriteLine("Age was not in an expected range");
		break;
}



//switch (firstName.ToLower())
//{
//	case "Mate" or "Merci":
//		Console.WriteLine("Hello Mate");
//		break;
//	case "Fanni":
//		Console.WriteLine("Hello Fanni");
//		break;
//	default:
//		Console.WriteLine("I dont know you");
//		break;
//}
