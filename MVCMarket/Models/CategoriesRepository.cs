﻿namespace MVCMarket.Models
{
    public class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        { 
            new Category{ CategoryId=1, Name="Beverages", Description="Beverages"},
            new Category{ CategoryId=2, Name="Bakery", Description="Bakery"},
            new Category{ CategoryId=3, Name="Meat", Description="Meat"},
        };
        public static void AddCategory(Category category)
        {
            var maxId=_categories.Max(c => c.CategoryId);
            category.CategoryId = maxId+1;
            _categories.Add(category);            
        }
        public static List<Category> GetCategory()=>_categories;

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null) {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
                    }
               return null;
                }
    
        public static void UpdateCategory(int categoryId, Category category)
        {
            if(categoryId != category.CategoryId) return;
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if(categoryToUpdate != null)
            {
                categoryToUpdate.CategoryId = category.CategoryId;
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }
    }
}
