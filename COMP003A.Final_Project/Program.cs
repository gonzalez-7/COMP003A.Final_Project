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
						AddNewRecord(members);
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

		static void AddNewRecord(List<GymMember> members)
		{
			string memberId = "M" + (members.Count + 1).ToString("D4");

			string membershipStatus = "Active";
			bool isActice = true;
			DateTime joinDate = DateTime.Today;
			DateTime lastCheckInDate = DateTime.Today;

			Console.WriteLine($"Assigned member ID: {memberId}");
			Console.WriteLine($"Status: {membershipStatus}");

			string firstName = ReadString("First Name: ");
			string lastName = ReadString("Last Name: ");
			string phone = ReadString("Phone: ");
			string email = ReadString("Email: ");
			string address = ReadString("Address");
			string emergencyName = ReadString("Emergency Contact Name: ");
			string emergencyPhone = ReadString("Emergency Contact Phone: ");
			string emergencyAddress = ReadString("Emergency Contact Address: ");

			int age = ReadInt("Age: ", 12, 100);
			int membershipDurationMonths = ReadInt("Membership Duration (months): ", 1, 36);
			int visitsPerWeek = ReadInt("Visits Per Week: ", 0, 14);
			int trainingSessionsPerMonth = ReadInt("Traininf Sessions Per Month: ", 0, 31);

			double heightCm = ReadDouble("Height (cm): ", 50, 250);
			double weightKg = ReadDouble("Weight (kg): ", 20, 300);
			double registrationFeePaid = ReadDouble("Registration Fee Paid: ", 0, 1000);
			double monthlyFee = ReadDouble("Monthly Fee: ", 0, 1000);

			bool hasTrainer = ReadBool("Has Trainer (y/n): ");
			bool hasMedicalCondition = ReadBool("Has Medical Condition (y/n): ");
			bool isStudent = ReadBool("Is Student (y/n): ");
			bool autoPayEnabled = ReadBool("AutoPay enabled (y/n): ");

			int membershipTypeCode = ReadMembershipTypeCode();
			int paymentPlanCode = ReadPaymentPlanCode();

			double balanceDue = monthlyFee + registrationFeePaid;
			if (balanceDue < 0)
				balanceDue = 0;

			GymMember newMember = new GymMember
				(
				memberId,
				membershipStatus,
				firstName,
				lastName,
				phone,
				email,
				address,
				emergencyName,
				emergencyPhone,
				emergencyAddress,
				age,
				membershipDurationMonths,
				visitsPerWeek,
				trainingSessionsPerMonth,
				heightCm,
				weightKg,
				registrationFeePaid,
				monthlyFee,
				balanceDue,
				hasTrainer,
				hasMedicalCondition,
				isActice,
				isStudent,
				autoPayEnabled,
				membershipTypeCode,
				paymentPlanCode,
				joinDate,
				lastCheckInDate
				);

				members.Add( newMember );

			Console.WriteLine("\nMember added successfully!");
			Console.WriteLine($"BMI: {newMember.CalculateBMI():F2}");
			Console.WriteLine($"Risk Level: {newMember.DetermineHealthRisk()}");
		}

		static string ReadString(string prompt)
		{
			while (true)
			{
				Console.Write(prompt);
				string input = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(input))
					return input.Trim();

				Console.WriteLine("Input cannot be empty. Try Again. ");
			}
		}
	}
}
