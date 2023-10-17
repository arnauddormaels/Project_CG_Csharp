using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Application.Models
{
    public class Recipe
    {
        private int _id;
        private string _name;
        private string _imgUrl;
        private string _videoUrl;
        //private List<object> _ingredients= new List<object>();              //object aanpassen naar (ingredient?)

        public Recipe(int id, string name, string imgUrl, string videoUrl, List<object> ingredients)
        {
            Id = id;
            Name = name;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            //_ingredients = ingredients;                                     //Ingredients (property?)
        }

        public void AddIngredient(/*Ingredient ingedient*/)
        {
            //Eventuele validatie moet nog gebeuren.
            if (true)
            {
            //    _ingredients.Add( new /*ingredient*/() );
            }
            else
            {
                throw new Exception();
            }
            
        }
        public int Id { get;private set; }
        public string Name { get { return _name;} private set { _name = value; } }
        public string ImgUrl { get { return _imgUrl;} private set { _imgUrl = value; } }
        public string VideoUrl { get { return _videoUrl;} private set { _videoUrl = value; } }

        public override string? ToString()
        {
            return "Recipe : " + Name + $"\nimg url : {ImgUrl}";
        }
    }
}
