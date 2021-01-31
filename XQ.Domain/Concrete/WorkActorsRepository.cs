using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Abstract;
using XQ.Domain.Entities;

namespace XQ.Domain.Concrete
{
    public class WorkActorsRepository : IWorkActorsRepository
    {
        public IEnumerable<WorkActors> WorkActors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Add(WorkActors workActorModel)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int workActorId)
        {
            throw new NotImplementedException();
        }

        public bool Update(WorkActors workActorModel)
        {
            throw new NotImplementedException();
        }

        public List<WorkActors> WorkActorInfo(int workActorId)
        {
            throw new NotImplementedException();
        }
    }
}
