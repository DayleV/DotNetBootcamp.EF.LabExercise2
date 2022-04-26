using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public class AnnualSalaryRepository : GenericRepository<AnnualSalary>, IRepository<AnnualSalary>
    {
        public AnnualSalaryRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<AnnualSalary> FindAll(string employeeCode)
        {
            return this.Context.AnnualSalaries.Where(x => x.CEmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}
