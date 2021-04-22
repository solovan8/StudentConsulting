using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentConsulting.Data;
using StudentConsulting.Models;

namespace StudentConsulting.Business
{
    public class RequestFilter : IRequestFilter
    {
        IUnitOfWork unitOfWork;

        private int duration;

        public RequestFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<ConsultRequestViewModel> Prioritize(int consultId)
        {
            var consultingsRequest = unitOfWork.ConsultingRequests.GetItemsById(consultId);
            duration = unitOfWork.ConsultingArranges.GetItem(consultId).Duration;


            var consultingsViewModels = new List<ConsultRequestViewModel>();
            if (consultingsRequest.Any())
            {
                foreach (var item in consultingsRequest)
                {
                    var student = unitOfWork.Students.GetItemByStringId(item.StudentId);
                    consultingsViewModels.Add(new ConsultRequestViewModel
                    {
                        StudentName = student.Name,
                        ConsultType = item.ConsultType,
                        RequiredTime = item.RequiredTime,
                        IsBanned = student.IsBanned
                    });
                }

                consultingsViewModels = InnerFilter(consultingsViewModels);
            }

            return consultingsViewModels;
        }


        private List<ConsultRequestViewModel> InnerFilter(List<ConsultRequestViewModel> list)
        {
            var array = list.ToArray();

            var length = array.Length;

            if (length < 2)
                return list;

            for (int i = 0; i < length - 1; i++)
            {
                for (int m = 0; m < length - i - 1; m++) 
                {
                    (array[m], array[m + 1]) = BannedFilter(array[m], array[m + 1]);
                }
            }

            return MakeNumbers(array).ToList();
        }

        private (ConsultRequestViewModel, ConsultRequestViewModel) DurationFilter(ConsultRequestViewModel a, ConsultRequestViewModel b)
        {
            if (a.RequiredTime > b.RequiredTime)
                return (b, a);
            else if (a.RequiredTime == b.RequiredTime)
                return TypeFilter(a, b);
            else
                return (a, b);
        }

        private (ConsultRequestViewModel, ConsultRequestViewModel) BannedFilter(ConsultRequestViewModel a, ConsultRequestViewModel b)
        {
            if (a.IsBanned)
            {
                if (b.IsBanned)
                {
                    return DurationFilter(a, b);
                }

                return (b, a);
            }
            return DurationFilter(a, b);
        }

        private (ConsultRequestViewModel, ConsultRequestViewModel) TypeFilter(ConsultRequestViewModel a, ConsultRequestViewModel b)
        {
            if (a.ConsultType.CompareTo(b.ConsultType) < 0)
                return (b, a);
            return (a, b);
        }

        private ConsultRequestViewModel[] MakeNumbers(ConsultRequestViewModel[] array)
        {
            int number = 1;
            int time = 0;
            bool isOutRange = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (isOutRange)
                { 
                    array[i].QueueNumber = "-";
                    continue;
                }

                if (time + array[i].RequiredTime < duration)
                {
                    array[i].QueueNumber = number.ToString();
                    number++;
                    time += array[i].RequiredTime;
                }
                else
                { 
                    array[i].QueueNumber = "-";
                    isOutRange = true;
                }
            }

            return array;
        }
    }




}
