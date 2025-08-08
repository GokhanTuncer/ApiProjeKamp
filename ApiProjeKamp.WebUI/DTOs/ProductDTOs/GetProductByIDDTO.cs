namespace ApiProjeKamp.WebUI.DTOs.ProductDTOs
{
    public class GetProductByIDDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }
    }
}

