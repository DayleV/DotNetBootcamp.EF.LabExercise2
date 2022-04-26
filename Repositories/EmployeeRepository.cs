using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IRepository<Employee>
    {
        public EmployeeRepository(RecruitmentContext context) : base(context)
        {
        }
    }
}
