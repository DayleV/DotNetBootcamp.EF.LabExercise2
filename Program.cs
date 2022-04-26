using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using EntityFramework.LabExercise2.Repositories;
using System;
using System.Collections.Generic;

namespace EntityFramework.LabExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");
            using (RecruitmentContext context = new RecruitmentContext(dbConnectionString))
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(context);
                PositionRepository positionRepository = new PositionRepository(context);
                AnnualSalaryRepository annualSalaryRepository = new AnnualSalaryRepository(context);
                MonthlySalaryRepository monthlySalaryRepository = new MonthlySalaryRepository(context);
                EmployeeSkillRepository employeeSkillRepository = new EmployeeSkillRepository(context);
                Console.Write("Enter Employee Code: ");
                string id = Console.ReadLine();
                Employee e = employeeRepository.FindById(id);
                if (e is Employee)
                {
                    Position p = positionRepository.FindById(e.CCurrentPosition);
                    IEnumerable<AnnualSalary> annualSalary = annualSalaryRepository.FindAll(e.CEmployeeCode);
                    IEnumerable<MonthlySalary> monthSalaries = monthlySalaryRepository.FindAll(e.CEmployeeCode);
                    IEnumerable<dynamic> skills = employeeSkillRepository.FindAll(e.CEmployeeCode);

                    Console.WriteLine($"\nEmployee Code: { e.CEmployeeCode}");
                    Console.WriteLine($"\nEmployee First Name: { e.VFirstName}");
                    Console.WriteLine($"\nEmployee Last Name: { e.VLastName}");
                    Console.WriteLine($"\nEmployee Postion: { p.VDescription}");

                    Console.WriteLine("\nEmployee Annual Salaries: ");
                    foreach (var salary in annualSalary)
                    {
                        Console.WriteLine($"Year: { salary.SiYear}, Salary: { salary.MAnnualSalary}");
                    }

                    Console.WriteLine("\nEmployee Monthly Salaries: ");
                    foreach (var salary in monthSalaries)
                    {
                        Console.WriteLine($"Salary: { salary.MMonthlySalary}, Pay Date: {salary.DPayDate}, Referral Bonus: {salary.MReferralBonus}");
                    }

                    Console.WriteLine("\nEmployee Skills: ");
                    foreach(var skill in skills)
                    {
                        Console.WriteLine($"~~> {skill.CSkillCode}");
                    }
                }
                else
                {
                    Console.WriteLine($"Employee Code \"{id}\" doesn't exist");
                }
            }
        }
    }
}
