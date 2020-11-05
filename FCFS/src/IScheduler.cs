using System.Collections.Generic;

namespace FCFS.src
{
    public interface IScheduler<T>
    {
        T Release();
        void BuildQueue();
        List<T> SortQueuePriority();
    }
}
