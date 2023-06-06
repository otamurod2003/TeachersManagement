namespace TeachersManagement.Models
{
    public interface IPupilsRepository
    {
        Pupil GetPupil(int id);
        IEnumerable<Pupil> GetAllPupils();
        Pupil Create(Pupil pupil); 
        Pupil Update(Pupil pupil);
        Pupil Delete(int id);
    }
}
