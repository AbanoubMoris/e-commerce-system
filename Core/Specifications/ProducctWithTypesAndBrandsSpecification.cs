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
        

        public ProducctWithTypesAndBrandsSpecification(int id) :base(x=>x.Id==id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }

}
