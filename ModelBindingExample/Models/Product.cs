using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindingExample.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingExample.Models
{
    public class Product
    {
        public int Id { get; set; }

       // [ModelBinder(typeof(ToUpperModelBinder))]
        public string Name { get; set; }
        public string Title { get; set; }

        //[BindNever]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
