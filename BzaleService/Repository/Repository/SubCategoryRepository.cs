﻿using depross.Interfaces;
using depross.Model;
using depross.Repository.Abstract;
using depross.Repository.DatabaseContext;
using System.Collections.Generic;
using System.Linq;

namespace depross.WebService
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {

        public SubCategoryRepository(BzaleDatabaseContext context) : base(context)
        {

        }
        public List<SubCategory> GetSubCategoriesByMainID(int maincategory,int page, int size)
        {
            return Get(e => e.MainCategory.ID == maincategory && e.Deleted == null)
                //.Skip((page - 1) * size).Take(size)
                .ToList();
        }

        public SubCategory GetSubCategory(int categoryid)
        {
            return GetSingle(e => e.ID == categoryid && e.Deleted == null);
        }
        public void AddNewSubCategory(SubCategory newCategory)
        {
            Add(newCategory);
            Save();
        }

        public void UpdateSubCategory(SubCategory category)
        {
            Edit(category);
            Save();
        }
    }

}
