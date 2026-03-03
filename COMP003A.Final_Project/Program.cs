using System.Collections.Generic;

namespace COMP003A.Final_Project
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<GymMember> members = new List<GymMember>();

			bool running = true;

			while (running)
			{
				Console.WriteLine("\n=== Gym Membership System ===");
				Console.WriteLine("1. Add New Record");
				Console.WriteLine("2. View All Records");
				Console.WriteLine("3. Search Records");
				Console.WriteLine("4. Display Summary Statistics");
				Console.WriteLine("5. Exit");
				Console.WriteLine("Choose an option from (1-5): ");

				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Console.WriteLine("\n--- Add New Record ---");
						break;
					case "2":
						Console.WriteLine("\n--- View All Records ---");
						break;
					case "3":
						Console.WriteLine("\n--- Search Records ---");
						break;
					case "4":
						Console.WriteLine("\n--- Summary Statistics ---");
						break;
					case "5":
						running = false;
						Console.WriteLine("Exiting program...");
						break;
					default:
						Console.WriteLine("Invalid option. Please enter a number between 1-5. ");
						break;
				}
			}
		}
	}
}
