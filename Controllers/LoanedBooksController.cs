using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Collection.Data;
using Collection.Models;

namespace Collection.Controllers
{
    public class LoanedBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoanedBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LoanedBooks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LoanedBooks.Include(l => l.Book).Include(l => l.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LoanedBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanedBooks = await _context.LoanedBooks
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loanedBooks == null)
            {
                return NotFound();
            }

            return View(loanedBooks);
        }

        // GET: LoanedBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "ID", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "ID", "Name");
            return View();
        }

        // POST: LoanedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("ID,LoanDate,ReturnDate,BookID,UserID")] LoanedBooks loanedBooks)
{
    if (ModelState.IsValid)
    {
        var book = await _context.Books.FindAsync(loanedBooks.BookID);
        if (book != null)
        {
            // Uppdatera status till "utlånad"
            book.Status = "utlånad";
            _context.Update(book);
        }
        _context.Add(loanedBooks);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(loanedBooks);

    
}


        // GET: LoanedBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanedBooks = await _context.LoanedBooks.FindAsync(id);
            if (loanedBooks == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "ID", "ID", loanedBooks.BookID);
            ViewData["UserId"] = new SelectList(_context.Users, "ID", "ID", loanedBooks.UserID);
            return View(loanedBooks);
        }

        // POST: LoanedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserId,BookId,LoanDate,ReturnDate,UserID,BookID")] LoanedBooks loanedBooks)
        {
            if (id != loanedBooks.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanedBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanedBooksExists(loanedBooks.ID))
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
            ViewData["BookId"] = new SelectList(_context.Books, "ID", "ID", loanedBooks.BookID);
            ViewData["UserId"] = new SelectList(_context.Users, "ID", "ID", loanedBooks.UserID);
            return View(loanedBooks);
        }

        // GET: LoanedBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanedBooks = await _context.LoanedBooks
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loanedBooks == null)
            {
                return NotFound();
            }

            return View(loanedBooks);
        }

// POST: LoanedBooks/Delete/5
[HttpDelete, ActionName("Delete")]
[ValidateAntiForgeryToken]

private bool LoanedBooksExists(int id)
{
    return _context.LoanedBooks.Any(e => e.ID == id);
}
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var loanedBooks = await _context.LoanedBooks.FindAsync(id);
    if (loanedBooks != null)
    {
        var book = await _context.Books.FindAsync(loanedBooks.BookID);
        if (book != null)
        {
            book.Status = "i lager";
            _context.Update(book);
        }

        _context.LoanedBooks.Remove(loanedBooks);
        await _context.SaveChangesAsync(); 
    }

    return RedirectToAction(nameof(Index));
}

    }
}
