using System;

namespace DevInterview.Providers.Common.Interfaces
{
    public interface IStoreable<T> where T : IComparable
    {
        T Id { get; set; }
    }
}