using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IRepository<Position>
    {
        public PositionRepository(RecruitmentContext context) : base(context)
        {
        }
    }
}
