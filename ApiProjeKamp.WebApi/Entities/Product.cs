﻿namespace ApiProjeKamp.WebApi.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
