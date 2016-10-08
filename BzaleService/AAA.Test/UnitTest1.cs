using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using depross.WebService;
using System.Collections.Generic;
using depross.ViewModel;
using depross.Repository;
using depross.Repository.DatabaseContext;
using depross.Model;

namespace AAA.Test
{
    [TestClass]
    public class UnitTest1
    {
        private MainCategoryRepository _mainrepo;
        private SubCategoryRepository _subrepo;

        

        [TestMethod]
        public void TestMainCategoryConnection()
        {
            _mainrepo = new MainCategoryRepository(new BzaleDatabaseContext());

            List<MainCategory> categories = _mainrepo.GetMainCategories(1,int.MaxValue);

            var category = _mainrepo.GetMainCategory(30);

            Assert.IsNotNull(categories);
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void TestSubCategoryConnection()
        {
            _subrepo = new SubCategoryRepository(new BzaleDatabaseContext());

            var category = _subrepo.GetSubCategoriesByMainID(30,1,int.MaxValue);


            Assert.IsNotNull(category);
        }
    }
}
