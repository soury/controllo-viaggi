using System;
using System.Collections.Generic;

namespace DevInterview.Providers.Common.Interfaces
{
    // Please create an in memory implementation of IRepository<T> 

    public interface IRepository<T, U>
        where T : IStoreable<U>
        where U : IComparable
    {
        IEnumerable<T> All();
        bool Delete(U id);
        bool Save(T item);
        T FindById(U id);
    }
}
