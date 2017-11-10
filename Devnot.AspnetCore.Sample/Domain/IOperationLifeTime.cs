using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devnot.AspnetCore.Sample.Domain
{

    public interface IOperationLifeTime
    {
        Guid OperationId { get; }
    }

    public interface IOperationTransient : IOperationLifeTime
    {
    }
    public interface IOperationScoped : IOperationLifeTime
    {
    }
    public interface IOperationSingleton : IOperationLifeTime
    {
    }
 

}
