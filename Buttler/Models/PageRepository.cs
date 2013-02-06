using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Buttler.Models
{ 
    public class PageRepository : IPageRepository
    {
        ButtlerContext context = new ButtlerContext();

        public IQueryable<Page> All
        {
            get { return context.Pages; }
        }

        public IQueryable<Page> AllIncluding(params Expression<Func<Page, object>>[] includeProperties)
        {
            IQueryable<Page> query = context.Pages;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Page Find(int id)
        {
            return context.Pages.Find(id);
        }

        public void InsertOrUpdate(Page page)
        {
            if (page.ID == default(int)) {
                // New entity
                context.Pages.Add(page);
            } else {
                // Existing entity
                context.Entry(page).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var page = context.Pages.Find(id);
            context.Pages.Remove(page);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IPageRepository : IDisposable
    {
        IQueryable<Page> All { get; }
        IQueryable<Page> AllIncluding(params Expression<Func<Page, object>>[] includeProperties);
        Page Find(int id);
        void InsertOrUpdate(Page page);
        void Delete(int id);
        void Save();
    }
}