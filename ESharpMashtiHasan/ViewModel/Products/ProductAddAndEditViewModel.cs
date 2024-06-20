using System.ComponentModel.DataAnnotations;

namespace ESharpMashtiHasan.ViewModel.Products
{
	public class ProductAddAndEditViewModel
	{
		public int ProductID { get; set; }

		public int CategoryID { get; set; }

		[Required(ErrorMessage = "Please Enter ProductName")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "ProductName Must be between 3 and 100")]
		public string ProductName { get; set; }

		[Range(1000, 10000000000, ErrorMessage = "UnitPrice Must be between 1000 and 10000000000")]
		public long UnitPrice { get; set; }

		public string Description { get; set; }

		[Required(ErrorMessage = "Please Enter the Slup")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Slut Must be between 3 and 100")]
		public string Slup { get; set; }

		public string PageTitle { get; set; }

		public string MetaKeyWord { get; set; }

		public string MataDescription { get; set; }

		public string JSONLDInformation { get; set; }

		public string ImagUrl { get; set; }

        public IFormFile Image { get; set; }

        public int SupplierID { get; set; }
	}
}
