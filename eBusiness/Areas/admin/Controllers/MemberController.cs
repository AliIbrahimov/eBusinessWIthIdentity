using eBusiness.DAL;
using eBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.admin.Controllers
{
    [Area("admin")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MemberController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var members = _context.Members.ToList();
            return View(members);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            if (!ModelState.IsValid) return View();
            if (member.FormFile is not null)
            {
                string imageName = Guid.NewGuid() + member.FormFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/img/team", imageName);
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    member.FormFile.CopyTo(fileStream);
                }
                member.Image = imageName;
                _context.Members.Add(member);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var member = _context.Members.Find(id);
            return View(member);
        }
        [HttpPost]
        public IActionResult Edit(Member member)
        {
            var existMember = _context.Members.FirstOrDefault(x => x.Id == member.Id);
            if (member.FormFile is not null)
            {
                string imageName = Guid.NewGuid() + member.FormFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/img/team", imageName);
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    member.FormFile.CopyTo(fileStream);
                }
                existMember.Image = imageName;
                existMember.Name = member.Name;
                existMember.Position = member.Position;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var existMember = _context.Members.Find(id);
            if (existMember is not null)
            {
                _context.Remove(existMember);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
