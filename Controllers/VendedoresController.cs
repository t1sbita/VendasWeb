using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendasWeb.Data;
using VendasWeb.Models;
using VendasWeb.Models.ViewModel;
using VendasWeb.Services;

namespace VendasWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendasWebContext _context;
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoFilial _servicoFilial;

        public VendedoresController(VendasWebContext context, ServicoVendedor servicoVendedor, ServicoFilial servicoFilial)
        {
            _context = context;
            _servicoVendedor = servicoVendedor;
            _servicoFilial = servicoFilial;
        }


        // GET: Vendedors
        public async Task<IActionResult> Index()
        {
            var vendedores = _servicoVendedor.EncontreTodos();
            var filiais = _servicoFilial.EncontreTodos();
            var viewModel = new VendedorFormViewModel { Filiais = filiais, Vendedores = vendedores };
            
            return View(viewModel);
            //return View(await _context.Vendedor.ToListAsync());
        }

        // GET: Vendedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor
                .FirstOrDefaultAsync(m => m.VendedorId == id);
            
            if (vendedor == null)
            {
                return NotFound();
            }

            var filial = _servicoVendedor.IdentificaFilial(vendedor);
            var viewModel = new VendedorFormViewModel { Filial = filial, Vendedor = vendedor };
            return View(viewModel);
        }

        // GET: Vendedors/Create
        public IActionResult Create()
        {
            var filiais = _servicoFilial.EncontreTodos();
            var viewModel = new VendedorFormViewModel { Filiais = filiais };
            return View(viewModel);
        }

        // POST: Vendedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Vendedor vendedor) //[Bind("VendedorId,VendedorNome,VendedorEmail,VendedorAniversario,VendedorSalario")]
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }

        // GET: Vendedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            var filiais = _servicoFilial.EncontreTodos();
            var viewModel = new VendedorFormViewModel { Filiais = filiais , Vendedor = vendedor};
            return View(viewModel);
        }

        // POST: Vendedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendedorId,VendedorNome,VendedorEmail,VendedorAniversario,VendedorSalario,FilialId")] Vendedor vendedor)
        {
            if (id != vendedor.VendedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.VendedorId))
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
            return View(vendedor);
        }

        // GET: Vendedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor
                .FirstOrDefaultAsync(m => m.VendedorId == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // POST: Vendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int id)
        {
            return _context.Vendedor.Any(e => e.VendedorId == id);
        }
    }
}
