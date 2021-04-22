using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentConsulting.Models;

namespace StudentConsulting.Data
{
    public class StudentRepository : IStringIdRepository<StudentIdentityUser>
    {
        private ApplicationDbContext context;

        private bool disposed = false;


        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public StudentIdentityUser GetItemByEmail(string email)
        {
            return context.Students.ToList().FirstOrDefault(s => s.Email == email);
        }

        public StudentIdentityUser GetItemByStringId(string id)
        {
            return context.Students.ToList().FirstOrDefault(s => s.Id == id);
        }



        public void Create(StudentIdentityUser item)
        {
            context.Students.Add(item);
        }

        public void Delete(int id)
        {
            var item = context.Students.Find(id);
            context.Students.Remove(item);
        }


        public StudentIdentityUser GetItem(int id)
        {
            return context.Students.Find(id);
        }

        public IEnumerable<StudentIdentityUser> GetItems()
        {
            return context.Students.ToList();
        }

        public void Update(StudentIdentityUser item)
        {
            context.Students.Update(item);
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
