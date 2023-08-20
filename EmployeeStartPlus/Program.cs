namespace EmployeeStartPlus
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

            static bool MainMenu()
            {
                Console.Clear();
                Console.WriteLine(" What are you going to do?");
                Console.WriteLine(" 1 => Rate and get statistics only");
                Console.WriteLine(" 2 => Evaluate, get statistics and save points in file");
                Console.WriteLine(" 3 => Read more about the Employee Start Plus");
                Console.WriteLine(" Q => Exit");
                Console.Write("\r\n Type you choice and press Enter: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        PointsToMemory();
                        return true;
                    case "2":
                        PointsToFile();
                        return true;
                    case "3":
                        InfoAboutProgram();
                        return true;
                    case "Q":
                    case "q":
                        return false;
                    default:
                        return true;
                }
            }
        }
        static void IfLetterAverageIsE(object sender, EventArgs args)
        {
            Console.WriteLine($"\nUnfortunately, Assesstment does not allow promote");
        }

        private static void PointsToMemory()
        {
            Console.Clear();
            string staffName = GetStaffDetailFromUser("Enter name");
            string staffSurname = GetStaffDetailFromUser("Enter surname");

            if (staffName != "" && staffSurname != "")
            {
                var StaffInMemory = new StaffInMemory(staffName, staffSurname);
                StaffInMemory.WorseThenD += IfLetterAverageIsE;
                EnterPoints(StaffInMemory);
                StaffInMemory.PreviewStatistics();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" You did not enter name or surname");
                BackToMainManu("");
            }
        }

        private static void PointsToFile()
        {
            Console.Clear();
            string staffName = GetStaffDetailFromUser("Enter name");
            string staffSurname = GetStaffDetailFromUser("Enter surname");
            if (staffName != "" && staffSurname != "")
            {
                var StaffInFile = new StaffInFile(staffName, staffSurname);
                StaffInFile.WorseThenD += IfLetterAverageIsE;
                EnterPoints(StaffInFile);
                StaffInFile.PreviewStatistics();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" You did not enter name or surname");
                BackToMainManu("");
            }
        }

        private static void EnterPoints(IStaff staff)
        {
            Console.Clear();
            Console.WriteLine($" To leave and get statistics enter Q\n");
            Console.WriteLine($"\nEnter points for {staff.Name} {staff.Surname}:\n");
            while (true)
            {
                Console.WriteLine(" Add points: ");
                var input = Console.ReadLine();
                if (input == "Q" || input == "q")
                {
                    break;
                }
                try
                {
                    if (input != null)
                    {
                        staff.AddPoint(input);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception catched: {ex.Message}");
                }
            }
        }

        private static string GetStaffDetailFromUser(string comment)
        {
            Console.WriteLine(comment);
            string userInput = Console.ReadLine();
            return userInput;
        }

        private static void InfoAboutProgram()
        {
            Console.Clear();
            Console.WriteLine(" This program is used to evaluate employees during a trial period");
            Console.WriteLine(" Choose an employee and evaluate their completed tasks");
            Console.WriteLine(" The program will prepare statistics for you based on the entered data");
            Console.WriteLine("\r\n Scope of points");
            Console.WriteLine(" You can enter a points from range 1-6. Entering '+' means +0.4, sign '-' decreases the point by -0.2");
            Console.WriteLine(" It is allowed to provide grades in fractional form, e.g. 4.3, as well as in percentage form in the range of 0-100%, e.g. 0% = 1 and 100% = 6");

            BackToMainManu(" ");
        }

        private static void BackToMainManu(string message)
        {
            Console.Write("\r\n Press Enter to return to Main Menu");
            Console.ReadLine();
        }
    }
}