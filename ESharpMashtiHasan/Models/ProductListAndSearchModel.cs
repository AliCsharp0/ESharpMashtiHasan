using Shapping.DomainModel.BusinessModel.Product;

namespace ESharpMashtiHasan.Models
{
    public class ProductListAndSearchModel
    {
        public ProductSearchModel sm { get; set; }

        public List<ProductListItem> productListItems { get; set; }
    }
}
