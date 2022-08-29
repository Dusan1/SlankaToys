using SlankaToys.Domain.Product;

namespace SlankaToys.UnitTests.Builders
{
    public class ProductBuilder
    {
        private string _name;
        private string _description;
        private string _imageFileName;
        private decimal _price;
        private int _productTypeId;

        public ProductBuilder(string name, string description, string imageFileName, decimal price, int productTypeId)
        {
            _name = name;
            _description = description;
            _imageFileName = imageFileName;
            _price = price;
            _productTypeId = productTypeId;
        }

        public Product Build()
        {
            return new Product(_name, _description, _imageFileName, _price, _productTypeId);
        }
    }
}

