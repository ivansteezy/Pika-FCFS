using System.Threading;
using System.Windows.Controls;

namespace FCFS.src
{
    interface Competitor
    {
        string name    { get; set; }
        uint speed     { get; set; }
        uint priority  { get; set; }
        Thread process { get; set; }
        Image sprite   { get; set; }
    }
}
