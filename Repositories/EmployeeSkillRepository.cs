using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    internal class EmployeeSkillRepository : GenericRepository<EmployeeSkill>, IRepository<EmployeeSkill>
    {
        public EmployeeSkillRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<dynamic> FindAll(string employeeCode)
        {
            var skills = this.Context.EmployeeSkills
                .Join(
                Context.Skills,
                es => es.CSkillCode,
                s => s.CSkillCode,
                (es,s) => new
                {
                    CEmployeeCode = es.CEmployeeCode,
                    CSkillCode = s.VSkill
                }
                )
                .Where(x => x.CEmployeeCode == employeeCode)
                .ToList();
            //foreach (var skill in skills)
            //{
            //    Console.WriteLine(skill.CSkillCode);
            //}
            return skills;
            
        }
    }
}

