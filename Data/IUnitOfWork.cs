using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentConsulting.Models;

namespace StudentConsulting.Data
{
    public interface IUnitOfWork
    {
        IManyIdRepository<ConsultingArrange> ConsultingArranges { get; }

        IManyIdRepository<ConsultingRequest> ConsultingRequests { get; }

        IOneEmailRepository<Lecturer> Lecturers { get; }

        IStringIdRepository<StudentIdentityUser> Students { get; }

        void Commit();
    }
}
