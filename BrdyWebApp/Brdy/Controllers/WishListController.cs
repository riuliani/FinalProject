using System.Linq;
using System.Threading.Tasks;
using Brdy.Data;
using Brdy.Models;
using Brdy.Data.Models;
using Brdy.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Brdy.Controllers
{
    public class WishListController : Controller
    {
        private readonly ILogger<WishListController> _logger;
        private readonly IBirdyServices _service;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public WishListController(ILogger<WishListController> logger, IBirdyServices service, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _service = service;
            _context = context;
            _userManager = userManager;

        }
        public IActionResult Wish(WishListBirds model)
        {            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWishList(WishList model)
        {
            var bird = new WishList();
            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                bird.CommonName = model.CommonName;
                bird.User = user;
            }

            _context.WishList.Add(bird);
            await _context.SaveChangesAsync();

            return RedirectToAction("DisplayWishList");
        }

        public async Task<IActionResult> DisplayWishList()
        {
            var userId = _userManager.GetUserId(User);
            return View(await _context.WishList.Where(X => X.User.Id == userId).ToListAsync());            
        }

        public async Task<IActionResult> AllWishList()
        {
            return View(await _context.WishList.ToListAsync());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishList.FirstOrDefaultAsync(x => x.Id == id);

            if(wishList == null)
            {
                return NotFound();
            }
            return View(wishList);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bird = await _context.WishList.FindAsync(id);
            _context.WishList.Remove(bird);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DisplayWishList));
        }
    }
}