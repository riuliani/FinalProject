using System.Linq;
using System.Threading.Tasks;
using Brdy.Data;
using Brdy.Data.Models;
using Brdy.Models;
using Brdy.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Brdy.Controllers
{
    public class SeenBirdController : Controller
    {
        private readonly ILogger<SeenBirdController> _logger;
        private readonly IBirdyServices _service;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeenBirdController(ILogger<SeenBirdController> logger, IBirdyServices service, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _service = service;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Seen(BirdsSeenViewModel model)
        {            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddToSeenList(BirdsSeenViewModel model)
        {
            var bird = new SeenBirds();
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                bird.CommonName = model.CommonName;
                bird.ScientificName = model.ScientificName;
                bird.Lattatude = model.Latitude;
                bird.Longitude = model.Longitude;
                bird.User = user;
                
            }

            _context.Add(bird);
            await _context.SaveChangesAsync();

            return RedirectToAction("SeenList");
        }

        public async Task<IActionResult> SeenList()
        {
            var userId = _userManager.GetUserId(User);
            return View(await _context.SeenBirds.Where(X => X.User.Id == userId).ToListAsync());
        }

        public async Task<IActionResult> AllSeenList()
        {
            return View(await _context.SeenBirds.ToListAsync());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seenList = await _context.SeenBirds.FirstOrDefaultAsync(x => x.BirdId == id);

            if (seenList == null)
            {
                return NotFound();
            }
            return View(seenList);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bird = await _context.SeenBirds.FindAsync(id);
            _context.SeenBirds.Remove(bird);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SeenList));
        }
    }
}