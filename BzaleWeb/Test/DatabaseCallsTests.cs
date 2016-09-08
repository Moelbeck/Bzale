using System;
using System.Collections.Generic;
using biz2biz.Enums;
using biz2biz.Model;
using biz2biz.Repository;
using biz2biz.Repository.context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    /// <summary>
    /// Create categories, manufacturers and products
    /// </summary>
    [TestClass]
    public class DatabaseCallsTests
    {

        private readonly ManufacturerRepository _manufacturerRepository;
        private readonly AccountRepository _accountRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ImageRepository _imageRepository;
        public DatabaseCallsTests()
        {
            Context cs = new Context();
            _accountRepository = new AccountRepository(cs);
            _manufacturerRepository = new ManufacturerRepository(cs);
            _categoryRepository = new CategoryRepository(cs);

            _imageRepository = new ImageRepository(cs);
        }



        #region Categories
        [TestMethod]
        public void Add_Smed_JobCategory()
        {
            var image = CreateImage("/JobCategories/blacksmith.png", eImageType.JobCategory);
            image = _imageRepository.AddNewImage(image);
            Assert.IsNotNull(image);
            var newmain = new JobCategory
            {
                Name = "Smed",
                Description = "Værktøj, jern, køretøj, og mere",
                Image = image,
            };
            _categoryRepository.AddNewJobCategory(newmain);
            var added = _categoryRepository.GetSpecificJobCategory("Smed");
            Assert.IsNotNull(added);
        }
        [TestMethod]
        public void Add_Tømrer_JobCategory()
        {
            var image = CreateImage("/JobCategories/toemrer.png", eImageType.JobCategory);
            image = _imageRepository.AddNewImage(image);
            Assert.IsNotNull(image);
            var newmain = new JobCategory
            {
                Name = "Tømrer",
                Description = "Værktøj, træ, køretøj, og mere",
                Image = image,
            };
            _categoryRepository.AddNewJobCategory(newmain);
            var added = _categoryRepository.GetSpecificJobCategory("Tømrer");
            Assert.IsNotNull(added);
        }
        [TestMethod]
        public void Add_Murer_JobCategory()
        {
            var image = CreateImage("/JobCategories/bricklayer-icon.png", eImageType.JobCategory);
            image = _imageRepository.AddNewImage(image);
            Assert.IsNotNull(image);
            var newmain = new JobCategory
            {
                Name = "Murer",
                Description = "Værktøj, mursten, køretøj, og mere",
                Image = image,
            };
            _categoryRepository.AddNewJobCategory(newmain);
            var added = _categoryRepository.GetSpecificJobCategory("Murer");
            Assert.IsNotNull(added);
        }

        [TestMethod]
        public void Add_Vareril_ProductCategory()
        {
            var image = CreateImage("/ProductCategories/van.png", eImageType.ProductCategory);
            image = _imageRepository.AddNewImage(image);
            Assert.IsNotNull(image);
            var smed = _categoryRepository.GetSpecificJobCategory("Smed");
            Assert.IsNotNull(smed);
            var murer = _categoryRepository.GetSpecificJobCategory("Murer");
            Assert.IsNotNull(murer);
            var tomrer = _categoryRepository.GetSpecificJobCategory("Tømrer");
            Assert.IsNotNull(tomrer);
            var productCategory = new ProductCategory
            {
                JobCategories = new List<JobCategory> { smed, murer, tomrer },
                Name = "Varebil",
                Description = "",
                Image = image,
            };
            _categoryRepository.AddNewProductCategory(productCategory);
            var added = _categoryRepository.GetSpecificProductCategory("Varebil");
            Assert.IsNotNull(added);

        }
        [TestMethod]
        public void Add_Trae_ProductCategory()
        {
            var image = CreateImage("/ProductCategories/wood.png", eImageType.ProductCategory);
            image = _imageRepository.AddNewImage(image);
            Assert.IsNotNull(image);
            var tomrer = _categoryRepository.GetSpecificJobCategory("Tømrer");
            Assert.IsNotNull(tomrer);
            var productCategory = new ProductCategory
            {
                JobCategories = new List<JobCategory> { tomrer },
                Name = "Træ",
                Description = "Planker, tømmer, m.m.",
                Image = image,
            };
            _categoryRepository.AddNewProductCategory(productCategory);
            var added = _categoryRepository.GetSpecificProductCategory("Træ");
            Assert.IsNotNull(added);

        }

        #endregion
        #region Manufacturer
        [TestMethod]
        public void Add_Vw_Manufacturer()
        {
            var productCategory = _categoryRepository.GetSpecificProductCategory("Varebil");
            Assert.IsNotNull(productCategory);
            Manufacturer manufacturer = new Manufacturer
            {
                Name = "VolksWagen",
                Created = DateTime.Now,
                CategoryID = productCategory.ID
            };
            var savedmanufacturer = _manufacturerRepository.AddNewManufacturer(manufacturer);
            Assert.IsNotNull(savedmanufacturer);

        }
        [TestMethod]
        public void Add_Trae_Manufacturer()
        {
            var productCategory = _categoryRepository.GetSpecificProductCategory("Træ");
            Assert.IsNotNull(productCategory);
            Manufacturer manufacturer = new Manufacturer
            {
                Name = "Trætype",
                Created = DateTime.Now,
                CategoryID = productCategory.ID
            };
            var savedmanufacturer = _manufacturerRepository.AddNewManufacturer(manufacturer);
            Assert.IsNotNull(savedmanufacturer);

        }
        [TestMethod]
        public void Add_BMW_Manufacturer()
        {
            var productCategory = _categoryRepository.GetSpecificProductCategory("Varebil");
            Assert.IsNotNull(productCategory);
            Manufacturer manufacturer = new Manufacturer
            {
                Name = "Mercedes Benz",
                Created = DateTime.Now,
                CategoryID = productCategory.ID
            };
            var savedmanufacturer = _manufacturerRepository.AddNewManufacturer(manufacturer);
            Assert.IsNotNull(savedmanufacturer);
        }

        [TestMethod]
        public void Add_Transporter_ProductType()
        {
            var productcategory = _categoryRepository.GetSpecificProductCategory("Varebil");
            var manufacturer = _manufacturerRepository.GetManufacturer("VolksWagen");
            Assert.IsNotNull(manufacturer);

            Product newProduct = new Product
            {
                Name = "Transporter",
                Created = DateTime.Now,
                ProductCategory = productcategory,
                Manufacturer = manufacturer
            };
            _manufacturerRepository.AddProductForManufacturer(newProduct);
            var savedproducttype = _manufacturerRepository.GetProductsForManufacturer(manufacturer);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_VW_EMPTY_ProductType()
        {
            var productcategory = _categoryRepository.GetSpecificProductCategory("Varebil");
            var manufacturer = _manufacturerRepository.GetManufacturer("VolksWagen");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Anden",
                Created = DateTime.Now,
                ProductCategory = productcategory,
                Manufacturer = manufacturer
            };

            _manufacturerRepository.AddProductForManufacturer(newProduct);
            var savedproducttype = _manufacturerRepository.GetProductsForManufacturer(manufacturer);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_Sprinter_ProductType()
        {
            var productcategory = _categoryRepository.GetSpecificProductCategory("Varebil");
            var manufacturer = _manufacturerRepository.GetManufacturer("Mercedes Benz");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Sprinter",
                Created = DateTime.Now,
                ProductCategory = productcategory,
                Manufacturer = manufacturer
            };

            _manufacturerRepository.AddProductForManufacturer( newProduct);
            var savedproducttype = _manufacturerRepository.GetProductsForManufacturer(manufacturer);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_MERCEDES_EMPTY_ProductType()
        {
            var productcategory = _categoryRepository.GetSpecificProductCategory("Varebil");
            var manufacturer = _manufacturerRepository.GetManufacturer("Mercedes Benz");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Anden",
                Created = DateTime.Now,
                ProductCategory = productcategory,
                Manufacturer = manufacturer
            };
            _manufacturerRepository.AddProductForManufacturer(newProduct);
            var savedproducttype = _manufacturerRepository.GetProductsForManufacturer(manufacturer);
            Assert.IsNotNull(savedproducttype);
        }

        [TestMethod]
        public void Add_Planker_ProductType()
        {
            var productcategory = _categoryRepository.GetSpecificProductCategory("Træ");
            var manufacturer = _manufacturerRepository.GetManufacturer("Trætype");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Planke",
                Created = DateTime.Now,
                ProductCategory = productcategory,
                Manufacturer = manufacturer
            };

            _manufacturerRepository.AddProductForManufacturer(newProduct);
            var savedproducttype = _manufacturerRepository.GetProductsForManufacturer(manufacturer);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_Paller_ProductType()
        {
            var productcategory = _categoryRepository.GetSpecificProductCategory("Træ");
            var manufacturer = _manufacturerRepository.GetManufacturer("Trætype");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Paller",
                Created = DateTime.Now,
                ProductCategory = productcategory,
                Manufacturer = manufacturer
            };

            _manufacturerRepository.AddProductForManufacturer(newProduct);
            var savedproducttype = _manufacturerRepository.GetProductsForManufacturer(manufacturer);
            Assert.IsNotNull(savedproducttype);
        }
        [TestMethod]
        public void Add_TRAE_EMPTY_ProductType()
        {
            var productcategory = _categoryRepository.GetSpecificProductCategory("Træ");
            var manufacturer = _manufacturerRepository.GetManufacturer("Trætype");
            Assert.IsNotNull(manufacturer);
            Product newProduct = new Product
            {
                Name = "Anden",
                Created = DateTime.Now,
                ProductCategory = productcategory,
                Manufacturer = manufacturer
            };

            _manufacturerRepository.AddProductForManufacturer( newProduct);
            var savedproducttype = _manufacturerRepository.GetProductsForManufacturer(manufacturer);
            Assert.IsNotNull(savedproducttype);
        }
        #endregion
        #region Private methods

        public Image CreateImage(string filename,eImageType type)
        {
            var image = new Image
            {
                Created = DateTime.Now,
                Type = type,
                ImageURL = filename
            };
            return image;
        }
        #endregion
    }

}
