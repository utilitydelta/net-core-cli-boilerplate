using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityDelta.Domain.Interface
{
    public interface IServiceResolver : IDisposable
    {
        T GetService<T>();
    }
}
