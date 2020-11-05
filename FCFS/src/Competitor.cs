using System.Threading;

namespace FCFS.src
{
    interface Competitor
    {
        string name    { get; set; }
        uint speed     { get; set; }
        uint priority  { get; set; }
        Thread process { get; set; }
    }
}
