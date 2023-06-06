using TeachersManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TeachersManagement.Models
{
    public class PupilsRepository : IPupilsRepository
    {
        private readonly AppDbContext _context;

        public PupilsRepository(AppDbContext context) => _context = context;    
       
    	        
		public Pupil Create(Pupil pupil)
        {
            _context.Pupils.Add(pupil);
            _context.SaveChanges();
            return pupil;
        }

 
        
        public Pupil Delete(int id)
        {
            Pupil? pupil = _context.Pupils.Find(id);
            
                _context.Pupils.Remove(pupil);
                _context.SaveChanges();
                return pupil;
        }

        public IEnumerable<Pupil> GetAllPupils()
        {
           return _context.Pupils;
        }

        public Pupil GetPupil(int id)
        {
            return  _context.Pupils.Find(id);
             
        }

        public Pupil Update(Pupil updatedPupil)
        {
            var pupil = _context.Pupils.Attach(updatedPupil);
            pupil.State = EntityState.Modified;
            _context.SaveChanges();
            return updatedPupil;

        }
    }
}
