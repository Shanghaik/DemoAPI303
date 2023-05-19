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
    internal class AllRepositories<T> : IAllRepositories<T> where T : class
    {
        private readonly FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context context;
        private readonly DbSet<T> dbset;

        public AllRepositories()
        {
        }
        public AllRepositories(FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context context, DbSet<T> dbset)
        {
            this.context = context;
            this.dbset = dbset;
        }

        public bool AddItem(T item)
        {
            try
            {
                dbset.Add(item);   // Thêm vào Dbset
                context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
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
                dbset.Update(item);   // Sửa trong Dbset
                context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public bool RemoveItem(T item)
        {
            try
            {
                dbset.Remove(item);   // Sửa trong Dbset
                context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
