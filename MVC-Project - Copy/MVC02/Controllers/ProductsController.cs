﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC02.Data;
using MVC02.Models;
using MVC02.Models.ViewModels;
using MVC02.Services;

namespace MVC02.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _auth;

        public ProductsController(ApplicationDbContext context, AuthService auth)
        {
            _context = context;
            _auth = auth;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {

            bool userBelongToRole = await _auth.DoesUserBelongToRole("Admin", User);

            if (userBelongToRole == true)
            {
                return View("Index", await _context.Product.Include(x => x.Category).ToListAsync());
            }
            else //Om användaren ej är inloggad eller bara en vanlig användare returneras denna vy
            {
                return View("Index", await _context.Product.Include(x => x.Category).Where(p => p.ForSale == true).ToListAsync());
            }
        }

        public async Task<IActionResult> ShowByCategory(int? id) {
            return View("Index", await _context.Product.Include(x => x.Category).Where(x=> x.Category.Id == id).ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.Include(x => x.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            var viewModel = new CreateProductVm();
            viewModel.AllCategories = _context.Category.Select(category => new SelectListItem() { Text = category.Name, Value = category.Id.ToString() });

            return View(viewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId,ForSale,Stock")] Product product)
        {
            

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new CreateProductVm();
            viewModel.AllCategories = _context.Category.Select(category => new SelectListItem() { Text = category.Name, Value = category.Id.ToString() });
            viewModel.Product = product;

            return View(viewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId,ForSale,Stock")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.Include(x => x.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
