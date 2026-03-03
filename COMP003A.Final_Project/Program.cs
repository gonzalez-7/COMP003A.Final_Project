using System;
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
				Console.Write("Choose an option from (1-5): ");

				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Console.WriteLine("\n--- Add New Record ---");
						AddNewRecord(members);
						break;
					case "2":
						Console.WriteLine("\n--- View All Records ---");
						ViewAllRecords(members);
						break;
					case "3":
						Console.WriteLine("\n--- Search Records ---");
						SearchRecords(members);
						break;
					case "4":
						Console.WriteLine("\n--- Summary Statistics ---");
						DisplaySummaryStatistics(members);
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
			bool isActive = true;
			DateTime joinDate = DateTime.Today;
			DateTime lastCheckInDate = DateTime.Today;

			Console.WriteLine($"Assigned member ID: {memberId}");
			Console.WriteLine($"Status: {membershipStatus}");

			string firstName = ReadString("First Name: ");
			string lastName = ReadString("Last Name: ");
			string phone = ReadString("Phone: ");
			string email = ReadString("Email: ");
			string address = ReadString("Address: ");
			string emergencyName = ReadString("Emergency Contact Name: ");
			string emergencyPhone = ReadString("Emergency Contact Phone: ");
			string emergencyAddress = ReadString("Emergency Contact Address: ");

			int age = ReadInt("Age: ", 12, 100);
			int membershipDurationMonths = ReadInt("Membership Duration (months): ", 1, 36);
			int visitsPerWeek = ReadInt("Visits Per Week: ", 0, 14);
			int trainingSessionsPerMonth = ReadInt("Training Sessions Per Month: ", 0, 31);

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

			double balanceDue = monthlyFee - registrationFeePaid;
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
				isActive,
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

		static void DisplaySummaryStatistics(List<GymMember> members)
		{
			if (members.Count == 0)
			{
				Console.WriteLine("No records available for summary.");
				return;
			}

			double totalMonthlyFees = 0;
			double totalBalanceDue = 0;
			int trainerCount = 0;
			double highestMonthlyFee = members[0].MonthlyFee;
			double lowestMonthlyFee = members[0].MonthlyFee;

			foreach ( GymMember member in members )
			{
				totalMonthlyFees += member.MonthlyFee;
				totalBalanceDue += member.BalanceDue;

				if (member.HasTrainer)
					trainerCount++;
				if (member.MonthlyFee > highestMonthlyFee)
					highestMonthlyFee = member.MonthlyFee;
				if (member.MonthlyFee < lowestMonthlyFee)
					lowestMonthlyFee= member.MonthlyFee;
			}

			double averageMonthlyFee = totalMonthlyFees / members.Count;
			double trainerPercent = (trainerCount * 100.0) / members.Count;

			Console.WriteLine($"\nTotal Members: {members.Count}");
			Console.WriteLine($"Average Monthly Fee: {averageMonthlyFee:F2}");
			Console.WriteLine($"Total Balance Due: {totalBalanceDue:F2}");
			Console.WriteLine($"Members with Trainer: {trainerCount} ({trainerPercent:F1}%)");
			Console.WriteLine($"Highest Monthly Fee: {highestMonthlyFee:F2}");
			Console.WriteLine($"Lowest Monthly Fee: {lowestMonthlyFee:F2}");
		}

		static void SearchRecords(List<GymMember> members)
		{
			if (members.Count == 0)
			{
				Console.WriteLine("No records to search.");
				return;
			}

			Console.WriteLine("Search by:");
			Console.WriteLine("1. Member ID");
			Console.WriteLine("2. Last Name");
			Console.WriteLine("Choose 1-2: ");
			string searchOption = Console.ReadLine();

			string query = ReadString("Enter search value: ");
			bool found = false;

			foreach (GymMember member in members)
			{
				bool isMatch = false;

				if (searchOption == "1")
				{
					if (member.MemberId.ToLower() == query.ToLower())
						isMatch = true;
				}
				else if (searchOption == "2")
				{
					if (member.LastName.ToLower() == query.ToLower())
						isMatch = true;
				}
				else
				{
					Console.WriteLine("Invalid search option");
					return;
				}
				if (isMatch)
				{
					found = true;
					Console.WriteLine("\n--- Match Found ---");
					PrintMemberDetails(member);
				}
			}
			if (!found)
			{
				Console.WriteLine("No matching records found.");
			}
		}

		static void PrintMemberDetails(GymMember member)
		{
			Console.WriteLine("\n--------------");
			Console.WriteLine($"Member ID: {member.MemberId}");
			Console.WriteLine($"Name: {member.FirstName} {member.LastName}");
			Console.WriteLine($"Status: {member.MembershipStatus}");
			Console.WriteLine($"Phone: {member.Phone}");
			Console.WriteLine($"Email: {member.Email}");
			Console.WriteLine($"Address: {member.Address}");
			Console.WriteLine($"Emergency Contact: {member.EmergencyContactName} - {member.EmergencyContactPhone}");
			Console.WriteLine($"Emergency Address: {member.EmergencyContactAddress}");
			Console.WriteLine($"Age: {member.Age}");
			Console.WriteLine($"Duration (months): {member.MembershipDurationMonths}");
			Console.WriteLine($"Visits/Week: {member.VisitsPerWeek}");
			Console.WriteLine($"Training Sessions/Month: {member.TrainingSessionsPerMonth}");
			Console.WriteLine($"Height (cm): {member.HeightCm}");
			Console.WriteLine($"Weight (kg): {member.WeightKg}");
			Console.WriteLine($"Registration Paid: {member.RegistrationFeePaid}");
			Console.WriteLine($"Monthly Fee: {member.MonthlyFee}");
			Console.WriteLine($"Balance Due: {member.BalanceDue}");
			Console.WriteLine($"Has Trainer: {member.HasTrainer}");
			Console.WriteLine($"Medical Condition: {member.HasMedicalCondition}");
			Console.WriteLine($"Student: {member.IsStudent}");
			Console.WriteLine($"AutoPay: {member.AutoPayEnabled}");
			Console.WriteLine($"Membership Type Code: {member.MembershipTypeCode}");
			Console.WriteLine($"Payment Plan Code: {member.PaymentPlanCode}");
			Console.WriteLine($"Join Date: {member.JoinDate:d}");
			Console.WriteLine($"Last Check-In: {member.LastCheckInDate:d}");
			Console.WriteLine($"BMI: {member.CalculateBMI():F2}");
			Console.WriteLine($"Risk Level: {member.DetermineHealthRisk()}");
		}

		static void ViewAllRecords(List<GymMember> members)
		{
			if (members.Count == 0)
			{
				Console.WriteLine("No records found.");
				return;
			}

			foreach (GymMember member in members)
			{
				Console.WriteLine("\n-----------------");
				Console.WriteLine($"Member ID: {member.MemberId}");
				Console.WriteLine($"Name: {member.FirstName} {member.LastName}");
				Console.WriteLine($"Status: {member.MembershipStatus}");
				Console.WriteLine($"Phone: {member.Phone}");
				Console.WriteLine($"Email: {member.Email}");
				Console.WriteLine($"Address: {member.Address}");
				Console.WriteLine($"Emergency Contact: {member.EmergencyContactName} - {member.EmergencyContactPhone}");
				Console.WriteLine($"Emergency Address: {member.EmergencyContactAddress}");
				Console.WriteLine($"Age: {member.Age}");
				Console.WriteLine($"Duration (months): {member.MembershipDurationMonths}");
				Console.WriteLine($"Visits/Week: {member.VisitsPerWeek}");
				Console.WriteLine($"Training Sessions/Month: {member.TrainingSessionsPerMonth}");
				Console.WriteLine($"Height (cm): {member.HeightCm}");
				Console.WriteLine($"Weight (kg): {member.WeightKg}");
				Console.WriteLine($"Registration Paid: {member.RegistrationFeePaid}");
				Console.WriteLine($"Monthly Fee: {member.MonthlyFee}");
				Console.WriteLine($"Balance Due: {member.BalanceDue}");
				Console.WriteLine($"Has Trainer: {member.HasTrainer}");
				Console.WriteLine($"Medical Condition: {member.HasMedicalCondition}");
				Console.WriteLine($"Student: {member.IsStudent}");
				Console.WriteLine($"AutoPay: {member.AutoPayEnabled}");
				Console.WriteLine($"Membership Type Code: {member.MembershipTypeCode}");
				Console.WriteLine($"Payment Plan Code: {member.PaymentPlanCode}");
				Console.WriteLine($"Join Date: {member.JoinDate:d}");
				Console.WriteLine($"Last Check-In: {member.LastCheckInDate:d}");
				Console.WriteLine($"BMI: {member.CalculateBMI():F2}");
				Console.WriteLine($"Risk Level: {member.DetermineHealthRisk()}");
			}
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

		static int ReadInt(string prompt, int min, int max)
		{
			while (true)
			{
				Console.Write(prompt);
				string input = Console.ReadLine();

				try
				{
					int value = int.Parse(input);

					if (value < min || value > max)
					{
						Console.WriteLine($"Enter a number between {min} and {max}.");
						continue;
					}
					return value;
				}
				catch
				{
					Console.WriteLine("Invalid Number. Please enter a whole number.");
				}
			}
		}

		static double ReadDouble(string prompt, double min, double max)
		{
			while (true)
			{
				Console.Write(prompt);
				string input = Console.ReadLine();

				try
				{
					double value = double.Parse(input);

					if (value < min || value > max)
					{
						Console.WriteLine($"Enter a number between {min} and {max}.");
						continue;
					}
					return value;
				}
				catch
				{
					Console.WriteLine("Invalid number. Please enter a numeric value.");
				}
			}
		}

		static bool ReadBool(string prompt)
		{
			while (true)
			{
				Console.Write(prompt);
				string input = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("Please enter y or n.");
					continue;
				}

				input = input.Trim().ToLower();

				if (input == "y" || input == "yes") return true;
				if (input == "n" || input == "no") return false;

				Console.WriteLine("Invalid input. Enter y or n");
			}
		}

		static int ReadMembershipTypeCode()
		{
			Console.WriteLine("\nMembership Type:");
			Console.WriteLine("1. Basic");
			Console.WriteLine("2. Standard");
			Console.WriteLine("3. Premium");
			Console.Write("Choose 1-3: ");

			while (true)
			{
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1": return 1;
					case "2": return 2;
					case "3": return 3;
					default:
						Console.WriteLine("Invalid choice. Enter 1-3: ");
						break;
				}
			}
		}

		static int ReadPaymentPlanCode()
		{
			Console.WriteLine("\nPayment Plan:");
			Console.WriteLine("1. Monthly");
			Console.WriteLine("2. Quarterly");
			Console.WriteLine("3. Yearly");
			Console.Write("Choose 1-3: ");

			while (true)
			{
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1": return 1;
					case "2": return 2;
					case "3": return 3;
					default:
						Console.WriteLine("Invalid choice enter 1-3: ");
						break;
				}
			}
		}
	}
}
