using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student.DAL;
using Student.Models.DBEntities;
using Microsoft.Data.SqlClient;
namespace Student.Controllers
{
    public class ItemController : Controller
    {
        
        private readonly StudentsDbContext _context;

        public ItemController(StudentsDbContext context)
        {
            _context = context;
        }
       

        


        // GET: Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StuId,FirstName,LastName,Locker,Bed,Table,Chair,Mirror,Foam,Mop")] Items items)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(items);
                await _context.SaveChangesAsync();
                return View("Success", "Item");
            }
            return View(items);
        }

        // GET: Item/Edit/5
       

        // GET: Item/Delete/5
       
       
    }
}
