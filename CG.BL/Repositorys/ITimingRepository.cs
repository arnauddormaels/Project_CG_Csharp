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
        public List<Timing> GetAllTimingsFromRecipe(int recipeId);
        public void AddTimingToRecipe(int recipeId, Timing timing);
        public void RemoveTimingFromRecipe(int timingId);
        public void UpdateTimingWithId(int timingId, Timing timing);
    }
}
