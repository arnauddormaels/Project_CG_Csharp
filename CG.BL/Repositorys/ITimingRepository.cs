using CG.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.Repositorys
{
    public interface ITimingRepository
    {
        public List<Timing> GetTiming(int recipeId);
        public void AddTiming(Timing timing);
        public void RemoveTiming(string timing);
    }
}
