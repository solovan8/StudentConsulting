using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentConsulting.Models;

namespace StudentConsulting.Data
{
    public class LecturerRepository : IOneEmailRepository<Lecturer>
    {
        private ApplicationDbContext context;

        private bool disposed = false;

        public LecturerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Lecturer GetItemByEmail(string email) 
        {
            return context.Lecturers.ToList().FirstOrDefault(u => u.Email == email);
        }



        public void Create(Lecturer item)
        {
            context.Lecturers.Add(item);
        }

        public void Delete(int id)
        {
            var item = context.Lecturers.Find(id);
            context.Lecturers.Remove(item);
        }

        public Lecturer GetItem(int id)
        {
            return context.Lecturers.Find(id);
        }

        public IEnumerable<Lecturer> GetItems()
        {
            return context.Lecturers.ToList();
        }

        public void Update(Lecturer item)
        {
            context.Lecturers.Update(item);
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
