using System;
using System.Collections.Generic;
using System.Text;

namespace COMP003A.Final_Project
{
	internal class GymMember
	{
		public string MemberId;
		public string MembershipStatus;
		public string FirstName;
		public string LastName;
		public string Phone;
		public string Email;
		public string Address;
		public string EmergencyContactName;
		public string EmergencyContactPhone;
		public string EmergencyContactAddress;

		public int Age;
		public int MembershipDurationMonths;
		public int VisitsPerWeek;
		public int TrainingSessionsPerMonth;

		public double HeightCm;
		public double WeightKg;
		public double RegistrationFeePaid;
		public double MonthlyFee;
		public double BalanceDue;

		public bool HasTrainer;
		public bool HasMedicalCondition;
		public bool IsActive;
		public bool IsStudent;
		public bool AutoPayEnabled;

		public int MembershipTypeCode;
		public int PaymentPlanCode;

		public DateTime JoinDate;
		public DateTime LastCheckInDate;

		public GymMember(
		string memberId,
		string membershipStatus,
		string firstName,
		string lastName,
		string phone,
		string email,
		string address,
		string emergencyContactName,
		string emergencyContactPhone,
		string emergencyContactAddress,
		int age,
		int membershipDurationMonths,
		int visitsPerWeek,
		int trainingSessionsPerMonth,
		double heightCm,
		double weightKg,
		double registrationFeePaid,
		double monthlyFee,
		double balanceDue,
		bool hasTrainer,
		bool hasMedicalCondition,
		bool isActive,
		bool isStudent,
		bool autoPayEnabled,
		int membershipTypeCode,
		int paymentPlanCode,
		DateTime joinDate,
		DateTime lastCheckInDate
		)
		{
			MemberId = memberId;
			MembershipStatus = membershipStatus;
			FirstName = firstName;
			LastName = lastName;
			Phone = phone;
			Email = email;
			Address = address;
			EmergencyContactName = emergencyContactName;
			EmergencyContactPhone = emergencyContactPhone;
			EmergencyContactAddress = emergencyContactAddress;


			Age = age;
			MembershipDurationMonths = membershipDurationMonths;
			VisitsPerWeek = visitsPerWeek;
			TrainingSessionsPerMonth = trainingSessionsPerMonth;


			HeightCm = heightCm;
			WeightKg = weightKg;
			RegistrationFeePaid = registrationFeePaid;
			MonthlyFee = monthlyFee;
			BalanceDue = balanceDue;


			HasTrainer = hasTrainer;
			HasMedicalCondition = hasMedicalCondition;
			IsActive = isActive;
			IsStudent = isStudent;
			AutoPayEnabled = autoPayEnabled;


			MembershipTypeCode = membershipTypeCode;
			PaymentPlanCode = paymentPlanCode;


			JoinDate = joinDate;
			LastCheckInDate = lastCheckInDate;
		}
	}
}
