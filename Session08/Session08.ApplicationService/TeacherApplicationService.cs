using Session08.EfDal;
using System;

namespace Session08.ApplicationService
{
    
    public class TeacherApplicationService
    {
        TeacherRepository _teacherRepository;
        public TeacherApplicationService(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public int GetCountOfTeachers()
        {
            return _teacherRepository.GetCoutOfTeachers();
        }
    }
}
