using Microsoft.EntityFrameworkCore;
using TeachersManagement.Data;

namespace TeachersManagement.Models
{
    public class TeachersRepository : ITeachersRepository 
    {
        private readonly AppDbContext _context;

        public TeachersRepository(AppDbContext context) =>_context = context;

        public Teacher Create(Teacher teacher)
        {
             _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return teacher;
          
        }

        public Teacher Get(int id)
        {
            return _context.Teachers.Find(id);

        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers;
        }

        public Teacher Update(Teacher updateTeacher)
        {
            var teacher = _context.Teachers.Attach(updateTeacher);
            teacher.State = EntityState.Modified;
            _context.SaveChanges();
            return updateTeacher;
        }
    }
}
