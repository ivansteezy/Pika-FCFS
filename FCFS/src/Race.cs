using System.Collections.Generic;
using System.Linq;

namespace FCFS.src
{
    class Race : IScheduler<Horse>
    {
        private Queue<Horse> m_ItemQueue = new Queue<Horse>();
        private List<Horse>  m_ItemList  = new List<Horse>();

        public Race(List<Horse> itemCollection)
        {
            this.m_ItemList = itemCollection;
            BuildQueue();
        }

        public Horse Release()
        {
            return this.m_ItemQueue.Dequeue();
        }

        public void BuildQueue()
        {
            var sortedList = this.SortQueuePriority();
            foreach (var competitor in sortedList)
            {
                this.m_ItemQueue.Enqueue(competitor);
            }
        }

        public List<Horse> SortQueuePriority()
        {
            return m_ItemList.OrderBy(p => p.priority).ToList();
        }

        public void BeginRace()
        {
            foreach (var competitor in m_ItemQueue)
            {
                competitor.process.Start(competitor);
            }
        }

        public Queue<Horse> ItemQueue { get { return m_ItemQueue; } set { m_ItemQueue = value; } }
        public List<Horse> ItemList   { get { return m_ItemList; }  set { m_ItemList  = value; } }
    }
}
