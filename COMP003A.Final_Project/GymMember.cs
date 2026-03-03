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
	}
}
