using System;
using System.Collections.Generic;
using bzale.Model;
using bzale.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bzale.Common;

namespace Test
{
    /// <summary>
    /// Create categories, manufacturers and products
    /// </summary>
    [TestClass]
    public class DatabaseCallsTests
    {

        private readonly ManufacturerRepository _manufacturerRepository;
        private readonly ProductRepository _productRepository;
        private readonly AccountRepository _accountRepository;
        private readonly CategoryRepository _categoryRepository;
        public DatabaseCallsTests()
        {
            _accountRepository = new AccountRepository();
            _manufacturerRepository = new ManufacturerRepository();
            _categoryRepository = new CategoryRepository();
            _productRepository = new ProductRepository();
        }



        #region Categories
        //[TestMethod]
        //public void Add_Smed_JobCategory()
        //{
        //    var image = CreateImage("/JobCategories/blacksmith.png", eImageType.JobCategory);
        //    image = _imageRepository.AddNewImage(image);
        //    Assert.IsNotNull(image);
        //    var newmain = new JobCategory
        //    {
        //        Name = "Smed",
        //        Description = "Værktøj, jern, køretøj, og mere",
        //        Image = image,
        //    };
        //    _categoryRepository.AddNewJobCategory(newmain);
        //    var added = _categoryRepository.GetSpecificJobCategory("Smed");
        //    Assert.IsNotNull(added);
        //}
        //[TestMethod]
        //public void Add_Tømrer_JobCategory()
        //{
        //    var image = CreateImage("/JobCategories/toemrer.png", eImageType.JobCategory);
        //    image = _imageRepository.AddNewImage(image);
        //    Assert.IsNotNull(image);
        //    var newmain = new JobCategory
        //    {
        //        Name = "Tømrer",
        //        Description = "Værktøj, træ, køretøj, og mere",
        //        Image = image,
        //    };
        //    _categoryRepository.AddNewJobCategory(newmain);
        //    var added = _categoryRepository.GetSpecificJobCategory("Tømrer");
        //    Assert.IsNotNull(added);
        //}
        //[TestMethod]
        //public void Add_Murer_JobCategory()
        //{
        //    var image = CreateImage("/JobCategories/bricklayer-icon.png", eImageType.Category);
        //    image = _imageRepository.AddNewImage(image);
        //    Assert.IsNotNull(image);
        //    var newmain = new Category
        //    {
        //        Name = "Murer",
        //        Description = "Værktøj, mursten, køretøj, og mere",
        //        Image = image,
        //    };
        //    _categoryRepository.AddNewCategory(newmain);
        //    var added = _categoryRepository.GetSpecificJobCategory("Murer");
        //    Assert.IsNotNull(added);
        //}

        [TestMethod]
        public void Add_Varerbil_Category()
        {
            var image = CreateImage("/ProductCategories/van.png", eImageType.Category);
            Assert.IsNotNull(image);
            var Category = new Category
            {
                Types = new List<eJobType> { eJobType.Smed, eJobType.Murer, eJobType.Tømrer },
                Name = "Varebil",
                Description = "",
                Image = image,
            };
            _categoryRepository.AddNewCategory(Category);
            var added = _categoryRepository.GetSpecificCategory("Varebil");
            Assert.IsNotNull(added);

        }
        [TestMethod]
        public void Add_Trae_Category()
        {
            var image = CreateImage("/ProductCategories/wood.png", eImageType.Category);
            Assert.IsNotNull(image);
            var category = new Category
            {
                Types = new List<eJobType> { eJobType.Tømrer },
                Name = "Træ",
                Description = "Planker, tømmer, m.m.",
                Image = image,
            };
            _categoryRepository.AddNewCategory(category);
            var added = _categoryRepository.GetSpecificCategory("Træ");
            Assert.IsNotNull(added);

        }

        #endregion
        #region Manufacturer
        [TestMethod]
        public void Add_Vw_Manufacturer()
        {
            var Category = _categoryRepository.GetSpecificCategory("Varebil");
            Assert.IsNotNull(Category);
            Manufacturer manufacturer = new Manufacturer
            {
                Name = "VolksWagen",
                Created = DateTime.Now,
                CategoryID = Category.ID
            };
            var savedmanufacturer = _manufacturerRepository.AddNewManufacturer(manufacturer);
            Assert.IsNotNull(savedmanufacturer);

        }
        [TestMethod]
        public void Add_Trae_Manufacturer()
        {
            var Category = _categoryRepository.GetSpecificCategory("Træ");
            Assert.IsNotNull(Category);
            Manufacturer manufacturer = new Manufacturer
            {
                Name = "Trætype",
                Created = DateTime.Now,
                CategoryID = Category.ID
            };
            var savedmanufacturer = _manufacturerRepository.AddNewManufacturer(manufacturer);
            Assert.IsNotNull(savedmanufacturer);

        }
        [TestMethod]
        public void Add_BMW_Manufacturer()
        {
            var Category = _categoryRepository.GetSpecificCategory("Varebil");
            Assert.IsNotNull(Category);
            Manufacturer manufacturer = new Manufacturer
            {
                Name = "Mercedes Benz",
                Created = DateTime.Now,
                CategoryID = Category.ID
            };
            var savedmanufacturer = _manufacturerRepository.AddNewManufacturer(manufacturer);
            Assert.IsNotNull(savedmanufacturer);
        }

        [TestMethod]
        public void Add_Transporter_ProductType()
        {
            var Category = _categoryRepository.GetSpecificCategory("Varebil");
            var manufacturer = _manufacturerRepository.GetManufacturer("VolksWagen");
            Assert.IsNotNull(manufacturer);

            Product newProduct = new Product
            {
                Name = "Transporter",
                Created = DateTime.Now,
                Category = Category,
                Manufacturer = manufacturer
            };
            _productRepository.AddProduct(newProduct);
            var savedproducttype = _productRepository.GetProductsForManufacturer(manufacturer,1,1000);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_VW_EMPTY_ProductType()
        {
            var Category = _categoryRepository.GetSpecificCategory("Varebil");
            var manufacturer = _manufacturerRepository.GetManufacturer("VolksWagen");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Anden",
                Created = DateTime.Now,
                Category = Category,
                Manufacturer = manufacturer
            };

            _productRepository.AddProduct(newProduct);
            var savedproducttype = _productRepository.GetProductsForManufacturer(manufacturer,1,1000);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_Sprinter_ProductType()
        {
            var Category = _categoryRepository.GetSpecificCategory("Varebil");
            var manufacturer = _manufacturerRepository.GetManufacturer("Mercedes Benz");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Sprinter",
                Created = DateTime.Now,
                Category = Category,
                Manufacturer = manufacturer
            };

            _productRepository.AddProduct( newProduct);
            var savedproducttype = _productRepository.GetProductsForManufacturer(manufacturer, 1, 1000);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_MERCEDES_EMPTY_ProductType()
        {
            var Category = _categoryRepository.GetSpecificCategory("Varebil");
            var manufacturer = _manufacturerRepository.GetManufacturer("Mercedes Benz");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Anden",
                Created = DateTime.Now,
                Category = Category,
                Manufacturer = manufacturer
            };
            _productRepository.AddProduct(newProduct);
            var savedproducttype = _productRepository.GetProductsForManufacturer(manufacturer, 1, 1000);
            Assert.IsNotNull(savedproducttype);
        }

        [TestMethod]
        public void Add_Planker_ProductType()
        {
            var Category = _categoryRepository.GetSpecificCategory("Træ");
            var manufacturer = _manufacturerRepository.GetManufacturer("Trætype");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Planke",
                Created = DateTime.Now,
                Category = Category,
                Manufacturer = manufacturer
            };

            _productRepository.AddProduct(newProduct);
            var savedproducttype = _productRepository.GetProductsForManufacturer(manufacturer, 1, 1000);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_Paller_ProductType()
        {
            var Category = _categoryRepository.GetSpecificCategory("Træ");
            var manufacturer = _manufacturerRepository.GetManufacturer("Trætype");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Paller",
                Created = DateTime.Now,
                Category = Category,
                Manufacturer = manufacturer
            };

            _productRepository.AddProduct(newProduct);
            var savedproducttype = _productRepository.GetProductsForManufacturer(manufacturer, 1, 1000);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_TRAE_EMPTY_ProductType()
        {
            var Category = _categoryRepository.GetSpecificCategory("Træ");
            var manufacturer = _manufacturerRepository.GetManufacturer("Trætype");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Anden",
                Created = DateTime.Now,
                Category = Category,
                Manufacturer = manufacturer
            };

            _productRepository.AddProduct( newProduct);
            var savedproducttype = _productRepository.GetProductsForManufacturer(manufacturer, 1, 1000);
            Assert.IsNotNull(savedproducttype);
        }
        #endregion
        #region Private methods

        public Image CreateImage(string filename,eImageType type)
        {
            var image = new Image
            {
                Created = DateTime.Now,
                ImageURL = filename
            };
            return image;
        }
        #endregion
    }

}
