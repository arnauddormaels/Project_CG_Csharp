﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Model
{
    public class Product
    {
        public Product(string name, string category, string imgUrl)
        {
            Name = name;
            Category = category;
            ImgUrl = imgUrl;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
        public Brand Brand { get; set; }
    }
}
