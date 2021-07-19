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
    public class BookmarkService : IBookmarkService
    {
        private ReadLaterDataContext _ReadLaterDataContext;
        private IHttpContextAccessor _HttpContextAccessor;
        public BookmarkService(ReadLaterDataContext readLaterDataContext, IHttpContextAccessor httpContextAccessor)
        {
            _ReadLaterDataContext = readLaterDataContext;
            _HttpContextAccessor = httpContextAccessor;
        }
        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            bookmark.CreateDate = DateTime.UtcNow;
            bookmark.UserName = GetCurrentUserName();
            _ReadLaterDataContext.Add(bookmark);
            _ReadLaterDataContext.SaveChanges();
            return bookmark;
        }

        public void DeleteBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Bookmark.Remove(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        public Bookmark GetBookmark(int Id)
        {
            var bookmark = _ReadLaterDataContext.Bookmark.FirstOrDefault(c => c.ID == Id);
            _ReadLaterDataContext.Entry(bookmark).Reference(s => s.Category).Load();
            return bookmark;
        }

        public List<Bookmark> GetBookmarks(int categoryId)
        {
            return _ReadLaterDataContext.Bookmark.Where(c => c.CategoryId == categoryId && c.UserName == GetCurrentUserName()).ToList();
        }

        public List<Bookmark> GetBookmarks()
        {
            return _ReadLaterDataContext.Bookmark.Where(b => b.UserName == GetCurrentUserName()).ToList();
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            bookmark.UserName = GetCurrentUserName();
            _ReadLaterDataContext.Update(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        private string GetCurrentUserName()
        {
            return _HttpContextAccessor.HttpContext.User.Identity.Name;
        }
    }
}
