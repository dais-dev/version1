using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAssetAppASP.Data;
using MyAssetAppASP.Models;

namespace MyAssetAppASP.Controllers
{
    public class AssetController : Controller
    {
        private readonly MyAssetAppASPContext _context;

        public AssetController(MyAssetAppASPContext context)
        {
            _context = context;
        }

        // GET: Asset
        public async Task<IActionResult> Index(string AssetPlantName, string searchString)
        {
            if (_context.Asset == null)
            {
                return Problem("Entity set 'MyAssetAppASPContext.Asset'  is null.");
            }
        // Use LINQ to get list of genres.
            IQueryable<string> PlantNameQuery = from m in _context.Asset
                                    orderby m.PlantName
                                    select m.PlantName;

            var assets = from m in _context.Asset
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                assets = assets.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(AssetPlantName))
            {
                assets = assets.Where(x => x.PlantName == AssetPlantName);
             }

            var AssetPlantNameVM = new AssetPlantNameViewModel
             {
                PlantNames = new SelectList(await PlantNameQuery.Distinct().ToListAsync()),
                Assets = await assets.ToListAsync()
            };


            return View(AssetPlantNameVM);
        }
        public IActionResult AdminActions()
        {
            return View();
        }

        public IActionResult ViewAssets()
        {
            return View();
        }

        public IActionResult Maintenance()
        {
            return View();
        }
        public IActionResult Onboard()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }


        // GET: Asset/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .FirstOrDefaultAsync(m => m.TagId == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Asset/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asset/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,SerialNumber,Name,Location, PlantName,EquipmentType,MaterialType,PurchaseDate,RenewalDate,ManufacturerName,Price")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asset);
        }

        // GET: Asset/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            return View(asset);
        }

        // POST: Asset/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TagId,SerialNumber,Name,Location,PlantName,EquipmentType,MaterialType,PurchaseDate,RenewalDate,ManufacturerName,Price")] Asset asset)
        {
            if (id != asset.TagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.TagId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(asset);
        }

        // GET: Asset/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .FirstOrDefaultAsync(m => m.TagId == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Asset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asset = await _context.Asset.FindAsync(id);
            if (asset != null)
            {
                _context.Asset.Remove(asset);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.TagId == id);
        }
    }
}
