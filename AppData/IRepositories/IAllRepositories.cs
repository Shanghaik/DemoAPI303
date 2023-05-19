using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepositories
{
    public interface IAllRepositories<T>
    {
        public IEnumerable<T> GetAll(); // Lấy ra
        public bool AddItem(T item); // Thêm mới
        public bool RemoveItem(T item); // Xóa
        public bool EditItem(T item); // Sửa

    }
}
