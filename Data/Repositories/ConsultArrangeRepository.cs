using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentConsulting.Models;

namespace StudentConsulting.Data
{
    public class ConsultArrangeRepository : IManyIdRepository<ConsultingArrange>
    {
        private ApplicationDbContext context;

        private bool disposed = false;

        
        public ConsultArrangeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<ConsultingArrange> GetItemsById(int id)
        {
            return context.ConsultingArranges.ToList().Where(u => u.LecturerId == id);
        }




        public void Create(ConsultingArrange item)
        {
            context.ConsultingArranges.Add(item);
        }

        public void Delete(int id)
        {
            var item = context.ConsultingArranges.Find(id);
            context.ConsultingArranges.Remove(item);
        }


        public ConsultingArrange GetItem(int id)
        {
            return context.ConsultingArranges.Find(id);
        }

        public IEnumerable<ConsultingArrange> GetItems()
        {
            return context.ConsultingArranges.ToList();
        }

        public void Update(ConsultingArrange item)
        {
            context.ConsultingArranges.Update(item);
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
