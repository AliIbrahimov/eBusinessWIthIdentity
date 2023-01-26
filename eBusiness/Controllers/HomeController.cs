using eBusiness.DAL;
using eBusiness.Models;
using eBusiness.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace eBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM vm = new HomeVM()
            {
                Settings = _context.Settings.ToList(),
                Members = _context.Members.Include(c=>c.Icons).ToList(),
                Icons = _context.Icons.ToList()
            };
            return View(vm);
        }
    }
}