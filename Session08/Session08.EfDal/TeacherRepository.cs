using Session08.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session08.EfDal
{
    public class TeacherRepository
    {
        private readonly TeacherContext _dbContext;

        public TeacherRepository(TeacherContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetCoutOfTeachers()
        {
            return _dbContext.Teachers.Count();
        }

        public void InsertSumRandomTeacher()
        {
            Teacher[] teachers = new[]
            {
                new Teacher
                {
                    FirstName = "Hamid",LastName = "Karimi",
                    InsertBy= 1,UpdateBy=1,
                    InsertDate = DateTime.Now
                },
                new Teacher
                {
                    FirstName = "Amin",LastName = "Sedaghati",
                    InsertBy= 1,UpdateBy=1,
                    InsertDate = DateTime.Now
                },
                new Teacher
                {
                    FirstName = "Basir",LastName = "Jafarzadeh",
                    InsertBy= 1,UpdateBy=1,
                    InsertDate = DateTime.Now
                },
            };
            _dbContext.Teachers.AddRange(teachers);
        }
    }
  
}
