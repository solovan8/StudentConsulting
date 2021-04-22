using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentConsulting.Models;

namespace StudentConsulting.Data
{
    public class ConsultRequestRepository : IManyIdRepository<ConsultingRequest>
    {
        private ApplicationDbContext context;

        private bool disposed = false;


        public ConsultRequestRepository(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IEnumerable<ConsultingRequest> GetItemsById(int id)
        {
            return context.ConsultingRequests.ToList().Where(c => c.ConsultingArrangeId == id);
        }




        public void Create(ConsultingRequest item)
        {
            context.ConsultingRequests.Add(item);
        }

        public void Delete(int id)
        {
            var item = context.ConsultingRequests.Find(id);
            context.ConsultingRequests.Remove(item);
        }


        public ConsultingRequest GetItem(int id)
        {
            return context.ConsultingRequests.Find(id);
        }

        public IEnumerable<ConsultingRequest> GetItems()
        {
            return context.ConsultingRequests.ToList();
        }

        public void Update(ConsultingRequest item)
        {
            context.ConsultingRequests.Update(item);
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
