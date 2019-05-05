using Session08.EfDal;
using Session08.StateManagement;
using System;
using Xunit;

namespace Session08.Tests
{
    public class TeacherTests
    {
        private readonly TeacherRepository _teacherRepository;
        private readonly TeacherContext _dbContext;

        public TeacherTests(TeacherRepository teacherRepository,TeacherContext teacherContext)
        {
            _teacherRepository = teacherRepository;
            _dbContext = teacherContext;
        }
        [Fact]
        public void When_DeleteAll_Should_TableCountBeZero()
        {
            _teacherRepository.InsertSumRandomTeacher();

            int countBeforeDeleteAll = _teacherRepository.GetCoutOfTeachers();
            _dbContext.Teachers.DeleteAllAsync();
            int countAfterDeleteAll = _teacherRepository.GetCoutOfTeachers();

            Assert.Equal(0, countAfterDeleteAll);
        }
    }
}
