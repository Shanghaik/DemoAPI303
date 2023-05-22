using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamController : ControllerBase
    {
        private readonly IAllRepositories<SanPham> repos;
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context context = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context();
        DbSet<SanPham> sanpham;// = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context().SanPhams;
        public SanphamController()
        {
            sanpham = context.SanPhams;
            AllRepositories<SanPham> all = new AllRepositories<SanPham>(context, sanpham);
            repos = all;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<SanPham> Get()
        {
            return repos.GetAll();  
        }

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public IEnumerable<SanPham> Get(string name) // Tìm theo tên
        {
            return repos.GetAll().Where(p => p.Ten.Contains(name));
        }

        // POST api/<ValuesController>
        [HttpPost("create-sanpham")]
        public bool CreateSanpham(string ma, string ten)
        {
            SanPham sp = new SanPham();
            sp.Ma = ma; sp.Ten = ten; 
            sp.Id = Guid.NewGuid();
            return repos.AddItem(sp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string ma, string ten)
        {
            var sp = repos.GetAll().First(p => p.Id == id); 
            sp.Ten = ten; sp.Ma = ma;
            return repos.EditItem(sp);  
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sp = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(sp);
        }
    }
}
