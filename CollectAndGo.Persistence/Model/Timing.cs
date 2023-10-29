using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Model
{
    public class Timing
    {
        public Timing(TimeSpan startTijd, TimeSpan endTijd)
        {
            StartTijd = startTijd;
            EndTijd = endTijd;
        }

        public int Id { get; set; }
        public TimeSpan StartTijd { get; set; }
        public TimeSpan EndTijd { get; set; }
        public Product Product { get; set; }
    }
}
