using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.netCoreMVCCRUD.Models;

namespace FinalProject.Controllers
{
    public class GameController : Controller
    {
        private readonly GameContext _context;

        public GameController(GameContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Games.ToListAsync());
        }


     
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Games());
            else
                return View(_context.Games.Find(id));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("GameId,GameName,GameCode,Genre,Publisher")] Games Game)
        {
            if (ModelState.IsValid)
            {
                if (Game.GameId == 0)
                    _context.Add(Game);
                else
                    _context.Update(Game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Game);
        }


        
        public async Task<IActionResult> Delete(int? id)
        {
            var Game =await _context.Games.FindAsync(id);
            _context.Games.Remove(Game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
