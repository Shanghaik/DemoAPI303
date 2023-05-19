using AppData.IRepositories;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositories
{
    public class AllRepositories<T> : IAllRepositories<T> where T : class
    {
        private FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context context;
        private DbSet<T> dbset;

        public AllRepositories()
        {
        }
        public AllRepositories(FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context context, DbSet<T> dbset)
        {
            this.context = context;
            this.dbset = dbset;
        }

        public FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context Context => context;

        public DbSet<T> Dbset => dbset;

        public bool AddItem(T item)
        {
            try
            {
                Dbset.Add(item);   // Thêm vào Dbset
                Context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditItem(T item)
        {
            try
            {         
                Dbset.Update(item);   // Sửa trong Dbset
                Context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset.ToList();
        }

        public bool RemoveItem(T item)
        {
            try
            {
                Dbset.Remove(item);   // Sửa trong Dbset
                Context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
