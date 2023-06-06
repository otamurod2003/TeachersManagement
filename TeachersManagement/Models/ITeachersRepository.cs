namespace TeachersManagement.Models
{
    public interface ITeachersRepository
    {
        IEnumerable<Teacher> GetAll(); // all teachers
        Teacher Get(int id); //select  single teacher
        Teacher Create(Teacher teacher); //create new teacher
        Teacher Update(Teacher teacher);    // update exist teacher
        Teacher Delete(int id); //delete teacher by id
    }
}
