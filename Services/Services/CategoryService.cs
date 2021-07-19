using Data;
using Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private ReadLaterDataContext _ReadLaterDataContext;
        private IHttpContextAccessor _HttpContextAccessor;
        public CategoryService(ReadLaterDataContext readLaterDataContext, IHttpContextAccessor httpContextAccessor) 
        {
            _ReadLaterDataContext = readLaterDataContext;
            _HttpContextAccessor = httpContextAccessor;
        }

        public Category CreateCategory(Category category)
        {
            category.UserName = GetCurrentUserName();
            _ReadLaterDataContext.Add(category);
            _ReadLaterDataContext.SaveChanges();
            return category;
        }

        public void UpdateCategory(Category category)
        {
            category.UserName = GetCurrentUserName();
            _ReadLaterDataContext.Update(category);
            _ReadLaterDataContext.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _ReadLaterDataContext.Categories.Where(c => c.UserName == GetCurrentUserName()).ToList();
        }

        public Category GetCategory(int Id)
        {
            return _ReadLaterDataContext.Categories.Where(c => c.ID == Id && c.UserName == GetCurrentUserName()).FirstOrDefault();
        }

        public Category GetCategory(string Name)
        {
            return _ReadLaterDataContext.Categories.Where(c => c.Name == Name && c.UserName == GetCurrentUserName()).FirstOrDefault();
        }

        public void DeleteCategory(Category category)
        {
            if(category.UserName == GetCurrentUserName())
            {
                _ReadLaterDataContext.Categories.Remove(category);
                _ReadLaterDataContext.SaveChanges();
            }
        }

        private string GetCurrentUserName()
        {
            return _HttpContextAccessor.HttpContext.User.Identity.Name;
        }
    }
}
