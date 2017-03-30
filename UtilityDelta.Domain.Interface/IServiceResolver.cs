using System;

namespace UtilityDelta.Domain.Interface
{
    public interface IServiceResolver : IDisposable
    {
        T GetService<T>();
    }
}