//////^(.*)(\n\1) +$

//namespace StringManipulation
//{
// class Program
// {
// static void Main(string[] args)
// {
// bool showMenu = true;
// while (showMenu)
// {
// showMenu = MainMenu();
// }
// }
// private static bool MainMenu()
// {
// Console.Clear();
// Console.WriteLine("Choose an option:");
// Console.WriteLine("1) Reverse String");
// Console.WriteLine("2) Remove Whitespace");
// Console.WriteLine("3) Exit");
// Console.Write("\r\nSelect an option: ");

// switch (Console.ReadLine())
// {
// case "1":
// ReverseString();
// return true;
// case "2":
// RemoveWhitespace();
// return true;
// case "3":
// return false;
// default:
// return true;
// }
// }

// private static string CaptureInput()
// {
// Console.Write("Enter the string you want to modify: ");
// return Console.ReadLine();
// }

// private static void ReverseString()
// {
// Console.Clear();
// Console.WriteLine("Reverse String");

// char[] charArray = CaptureInput().ToCharArray();
// Array.Reverse(charArray);
// DisplayResult(String.Concat(charArray));
// }

// private static void RemoveWhitespace()
// {
// Console.Clear();
// Console.WriteLine("Remove Whitespace");

// DisplayResult(CaptureInput().Replace(" ", ""));
// }

// private static void DisplayResult(string message)
// {
// Console.WriteLine($"\r\nYour modified string is: {message}");
// Console.Write("\r\nPress Enter to return to Main Menu");
// Console.ReadLine();
// }
// }
//}






//namespace EmployeeStartPlus
//{
// class Program
// {
// static void Main(string[] args)
// {
// bool showMenu = true;
// while (showMenu)
// {
// showMenu = MainMenu();
// }
// }
// private static bool MainMenu()
// {
// Console.Clear();
// Console.WriteLine("Choose an option:");
// Console.WriteLine("1) About the Employee Start Plus");
// Console.WriteLine("2) Let's start!!");
// Console.WriteLine("3) Exit");
// Console.Write("\r\nSelect an option: ");

// switch (Console.ReadLine())
// {
// case "1":
// About();
// return true;
// case "2":
// EmployeeStart();
// return true;
// case "3":
// return false;
// default:
// return true;
// }
// }

// private static string CaptureInput()
// {
// return Console.ReadLine();
// }

// private static void About()
// {
// Console.Clear();
// Console.WriteLine("Program przeznaczony do oceny pracowników w czasie okresu próbnego");
// Console.WriteLine("\r\nWybierz pracownika i oceń jego zrealizowane zadania");
// Console.WriteLine("\r\nProbram przygotuje Ci statystykę na podstawie wprowadzonych danych");

// BackToMainManu("");
// }

// private static void EmployeeStart(string[] args)
// {
// Console.Clear();
// Console.WriteLine("1 - Wybierz Id pracownika, którego chcesz ocenić");
// Console.WriteLine("2 - Wprowadź dane nowego pracownika, którego będziesz oceniać");


// bool showEmployeeMenu = true;
// while (showEmployeeMenu)
// {
// showEmployeeMenu = EmployeeMenu();
// }


// switch (Console.ReadLine())
// {
// case "1":
// RateEmployee();
// return true;
// case "2":
// AddEmployee();
// return true;
// case "3":
// return false;
// default:
// return true;
// }


// BackToMainManu(CaptureInput());
// }

// private static void BackToMainManu(string message) //zmienić na info, że enter wraca do menu
// {
// Console.WriteLine($"\r\nYour modified string is: {message}");
// Console.Write("\r\nPress Enter to return to Main Menu");
// Console.ReadLine();
// }
// }
//}

