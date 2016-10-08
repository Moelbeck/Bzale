using depross.Repository.Abstract;
using depross.Repository.DatabaseContext;
using depross.Interfaces;
using depross.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace depross.Repository
{
    public class ProductTypeRepository : GenericRepository< ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(BzaleDatabaseContext context) : base(context)
        {

        }
        #region Product
        public ProductType AddProductType(ProductType newproduct)
        {
            ProductType product = null;
            //We need to check if the person have verified it somehow
            if (!IsProductInDatabase(newproduct))
            {
                product = Add(newproduct);
                Save();
            }
            return product;
        }

        public void UpdateProductType(ProductType updatedProduct)
        {
            Edit(updatedProduct);
            Save();
        }

        private bool IsProductInDatabase(ProductType newproduct)
        {
            return GetSingle(e => e.Name.ToLower() == newproduct.Name.ToLower())!=null;
        }


        public ProductType GetProductTypeByID(int productid)
        {
            return GetSingle(e => e.ID == productid);
        }
        

        public List<ProductType> GetAllProductsTypesByString(string searchstring, int page, int size)
        {
            var Products = Get(e => e.Name.ToLower().Contains(searchstring)
            || e.Category.Name.ToLower().Contains(searchstring.ToLower())
            || e.Category.Description.ToLower().Contains(searchstring.ToLower())).OrderBy(e => e.ID)
            //.Skip((page - 1) * size).Take(size)
            .ToList();
            return Products.GroupBy(x => x.ID).Select(y => y.First()).ToList();
        }

        public List<ProductType> GetAllProductTypesForCategory(int categoryid ,int page,int size)
        {
            return Get(e => e.Category.ID == categoryid && e.Deleted == null)
                //.OrderBy(e => e.ID).Skip((page - 1) * size).Take(size)
                .ToList();
        }

        public List<ProductType> GetProductsForManufacturer(Manufacturer manufacturer,int page,int size)
        {
            return Get(e => e.ID == manufacturer.ID)
                //.OrderBy(e => e.ID).Skip((page - 1) * size).Take(size)
                .ToList();
        }

        public List<ProductType> GetAllProductTypesForCategories(List<int> categoryids, int page, int size)
        {
            List<ProductType> producttypes = null;
            return producttypes;
        }
        #endregion

    }
}
