using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devnot.AspnetCore.Sample.Domain
{
    public class OperationLifeTime : IOperationTransient, IOperationScoped, IOperationSingleton
    {

        public Guid _OperationId;

        public Guid OperationId { get; }= Guid.NewGuid();

        //public OperationLifeTime()

        //{

        //    _OperationId = Guid.NewGuid();
        //}



        //public OperationLifeTime(Guid operationId)

        //{
        //    _OperationId = operationId;

        //}
    }
}
