using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_api.Data;
using Web_api.Models;

namespace Web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Loai = _context.Loais.SingleOrDefault(x=>x.MaLoai==id);
            if (Loai != null)
            {
                return Ok(Loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModels model)
        {
            try
            {
                var Loai = new Loai()
                {
                    TenLoai = model.TenLoai
                };

                _context.Add(Loai);
                _context.SaveChanges();
                return Ok(Loai);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateByid(int id, LoaiModels model)
        {
            var Loai = _context.Loais.SingleOrDefault(x => x.MaLoai == id);
            if (Loai != null)
            {
                Loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok(Loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteByid(int id)
        {
            var Loai = _context.Loais.SingleOrDefault(x => x.MaLoai == id);
            if (Loai != null)
            {
                _context.Remove(Loai);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
