using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Entities
{
    public class TimingEntity
    {
        public TimingEntity(int startTijd, int endTijd)
        {
            StartTijd = startTijd;
            EndTijd = endTijd;
        }

        public TimingEntity(int startTijd, int endTijd, int recipeId, int productId) : this(startTijd, endTijd)
        {
            RecipeId = recipeId;
            ProductId = productId;
        }

        public int Id { get; set; }
        public int StartTijd { get; set; }
        public int EndTijd { get; set; }
        public int RecipeId {  get; set; }
        public int ProductId {  get; set; }
        public ProductEntity Product { get; set; }
        public DateTime? TimeLog { get; set; }

        
    }
}
