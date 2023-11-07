using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Model
{
    public class TimingEntity
    {
        public TimingEntity(int startTijd, int endTijd)
        {
            StartTijd = startTijd;
            EndTijd = endTijd;
        }

        public int Id { get; set; }
        public int StartTijd { get; set; }
        public int EndTijd { get; set; }
        public ProductEntity Product { get; set; }
    }
}
