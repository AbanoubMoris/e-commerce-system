using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProducctWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        

        public ProducctWithTypesAndBrandsSpecification(ProductSpecParams ProductParams)
        :base(
             x=>
             (string.IsNullOrEmpty(ProductParams.Search) || x.Name.ToLower().Contains(ProductParams.Search))&&
             (!ProductParams.BrandId.HasValue || x.ProductBrandId== ProductParams.BrandId) && 
             (!ProductParams.TypeId.HasValue || x.ProductTypeId== ProductParams.TypeId)
        )
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(ProductParams.PageSize * (ProductParams.PageIndex - 1), ProductParams.PageSize);

            if (!string.IsNullOrEmpty(ProductParams.Sort))
            {
                switch (ProductParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }

        }
        public ProducctWithTypesAndBrandsSpecification()
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }

}
