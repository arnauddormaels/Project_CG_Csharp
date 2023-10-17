using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Application.Models
{
    /// <summary>
    /// Recepenten klas commentaar!!!!
    /// </summary>
    public class Recipe
    {
        private int _id;
        private string _name;
        private string _imgUrl;
        private string _videoUrl;
        private bool _isActive;

        public Recipe(int id, string name, string imgUrl, string videoUrl) : this(name,imgUrl,videoUrl)
        {
            Id = id;           
        }
         public Recipe(string name, string imgUrl, string videoUrl)
        {
            Name = name;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            _isActive = false;
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
        public int Id { get { return _id; } private set { _id = value; } }
        public string Name { get { return _name;} private set { _name = value; } }
        public string ImgUrl { get { return _imgUrl;} private set { _imgUrl = value; } }
        public string VideoUrl { get { return _videoUrl;} private set { _videoUrl = value; } }

        public bool IsActive { get => _isActive; private set => _isActive = value; }

        public override string? ToString()
        {
            return "Recipe : " + Name + $"\nimg url : {ImgUrl}";
        }
    }
}
