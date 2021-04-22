using StudentConsulting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentConsulting.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        private StudentRepository _students;

        private LecturerRepository _lecturers;

        private ConsultArrangeRepository _consultingsArranges;

        private ConsultRequestRepository _consultingsRequests;


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IManyIdRepository<ConsultingArrange> ConsultingArranges
        {
            get
            {
                return _consultingsArranges ?? (_consultingsArranges = new ConsultArrangeRepository(_dbContext));
            }
        }

        public IManyIdRepository<ConsultingRequest> ConsultingRequests
        {
            get
            {
                return _consultingsRequests ?? (_consultingsRequests = new ConsultRequestRepository(_dbContext));
            }
        }

        public IOneEmailRepository<Lecturer> Lecturers
        {
            get
            {
                return _lecturers ?? (_lecturers = new LecturerRepository(_dbContext));
            }
        }

        public IStringIdRepository<StudentIdentityUser> Students
        {
            get
            {
                return _students ?? (_students = new StudentRepository(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
