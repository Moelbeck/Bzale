using depross.Repository.Abstract;
using depross.Repository.DatabaseContext;
using depross.Interfaces;
using depross.Model;
using System.Collections.Generic;
using System.Linq;

namespace depross.Repository
{
    public class ProductRepository : GenericRepository< ProductType>, IProductRepository
    {
        public ProductRepository(BzaleDatabaseContext context) : base(context)
        {

        }
        #region Product
        public ProductType AddProduct(ProductType newproduct)
        {
            ProductType product = null;
            //We need to check if the person have verified it somehow
            if (newproduct.Manufacturer != null && IsManufacturerInDatabase(newproduct.Manufacturer) && !IsProductInDatabase(newproduct))
            {
                Add(newproduct);
                Save();
                product =GetSingle(e => e.Name == newproduct.Name);
            }
            return product;
        }

        public void UpdateProduct(ProductType updatedProduct)
        {
            Edit(updatedProduct);
            Save();
        }

        private bool IsProductInDatabase(ProductType newproduct)
        {
            return GetSingle(e => e.Name.ToLower() == newproduct.Name.ToLower() && e.Manufacturer.ID == newproduct.Manufacturer.ID)!=null;
        }


        public ProductType GetProductByID(int productid)
        {
            return GetSingle(e => e.ID == productid);
        }
        

        public List<ProductType> GetAllProductsContainingString(string searchstring, int page, int size)
        {
            var Products = Get(e => e.Name.ToLower().Contains(searchstring)
                || e.Manufacturer.Name.ToLower().Contains(searchstring.ToLower())
            || e.Category.Name.ToLower().Contains(searchstring.ToLower())
            || e.Category.Description.ToLower().Contains(searchstring.ToLower()),page,size).ToList();
            return Products.GroupBy(x => x.ID).Select(y => y.First()).ToList();
        }


        public List<string> GetAllProductNames(int page,int size)
        {
            return Get(e => e.Deleted == null, page, size).Select(s => s.Name).ToList();
        }



        public List<ProductType> GetAllProductsForManufacturer(int manufacturer, int page, int size)
        {
            return Get(e => e.Deleted == null && e.Manufacturer.ID == manufacturer,page,size).ToList();
        }

        public List<ProductType> GetAllProducts(int page,int size)
        {
            return Get(e => e.Deleted == null,page,size).ToList();
        }

        public List<string> GetAllProductNamesForManufacturer(Manufacturer manufacturer,int page, int size)
        {
            return Get(e => e.Deleted == null && e.Manufacturer.ID == manufacturer.ID,page,size).Select(e => e.Name).ToList();
        }

        public List<ProductType> GetProductsForManufacturer(Manufacturer manufacturer,int page,int size)
        {
            return Get(e => e.ID == manufacturer.ID,page,size).ToList();
        }

        public bool IsManufacturerInDatabase(Manufacturer m)
        {
            return GetSingle(e => e.Manufacturer.Name.ToLower() == m.Name.ToLower())!=null;
        }
        #endregion

    }
}
