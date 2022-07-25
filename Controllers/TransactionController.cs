using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankingApp_PK.Models;
namespace BankingApp_PK.Controllers;

public class TransactionController : Controller {
    private readonly BankingContext _context;
    public TransactionController(BankingContext context) {
        _context = context;
    }

    // GET: Transaction
    public async Task<IActionResult> Index() {
        // var q = from t in _context.Transaction
        //     join s in _context.Account.AsEnumerable()
        //         on t.Source equals s.Id
        //     join d in _context.Account.AsEnumerable()
        //         on t.Destination equals d.Id
        //     select new TransactionViewModel()
        //     {
        //         Id = t.Id,
        //         Source = s.Name,
        //         Destination = d.Name,
        //         TransferTime = t.TransferTime,
        //         TransferAmount = t.TransferAmount,
        //         SourceBalance = t.SourceBalance,
        //         DestinationBalance = t.DestinationBalance
        //     };
        return View(await _context.Transaction
            .Join(_context.Account,
                t => t.Source,
                s => s.Id,
                (t, s) => new
                {
                    T = t,
                    S = s
                })
            .Join(_context.Account, t => t.T.Destination, d => d.Id, (t, d) => new TransactionViewModel()
            {
                Id = t.T.Id,
                Source = t.S.Name,
                Destination = d.Name,
                TransferTime = t.T.TransferTime,
                TransferAmount = t.T.TransferAmount,
                SourceBalance = t.T.SourceBalance,
                DestinationBalance = t.T.DestinationBalance
            }).ToListAsync());
    }
    // GET: Transaction/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id == null || _context.Transaction == null) {
            return NotFound();
        }

        var t = await _context.Transaction
            .FirstOrDefaultAsync(m => m.Id == id);
        if (t == null) {
            return NotFound();
        }

        var vm = new TransactionViewModel()
        {
            Id = t.Id,
            TransferTime = t.TransferTime,
            TransferAmount = t.TransferAmount,
            SourceBalance = t.SourceBalance,
            DestinationBalance = t.DestinationBalance
        };
        vm.Source = (await _context.Account.FindAsync(t.Source))?.Name ?? string.Empty;
        vm.Destination = (await _context.Account.FindAsync(t.Destination))?.Name ?? string.Empty;

        return View(vm);
    }

    // GET: Transaction/Create
    public IActionResult Create() {
        var vm = new TransferViewModel()
        {
            Accounts = _context.Account.ToList(),
        };
        return View(vm);
    }

    // POST: Transaction/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FromId,ToId,Amount")] TransferViewModel vm) {

        if (ModelState.IsValid) {
            var sourceAccount = _context.Account.FirstOrDefault(f => f.Id == vm.FromId);
            var destAccount = _context.Account.FirstOrDefault(f => f.Id == vm.ToId);
            var hasError = false;
            vm.Errors = new List<string>();
            if (vm.Amount < 1 || vm.Amount > 10000) {
                hasError = true;
                vm.Errors.Add("Amount must be greater than or equal to 1 and less than or equal to 10000");
            }
            if (vm.Amount > sourceAccount.Balance) {
                hasError = true;
                vm.Errors.Add("Cannot transfer more than available balance");
            }
            if (sourceAccount is null || destAccount is null) {
                hasError = true;
                vm.Errors.Add("Cannot find account with matching ID");
            }
            else if (sourceAccount.Id == destAccount.Id) {
                hasError = true;
                vm.Errors.Add("Cannot transfer between same account");
            }
            if (hasError) {
                vm.Accounts = _context.Account.AsEnumerable();
                return View(vm);
            }
            var t = new Transaction()
            {
                Source = sourceAccount.Id,
                Destination = destAccount.Id,
                TransferAmount = vm.Amount,
                TransferTime = DateTime.Now,
                SourceBalance = sourceAccount.Balance,
                DestinationBalance = destAccount.Balance
            };
            sourceAccount.Balance -= vm.Amount;
            destAccount.Balance += vm.Amount;

            _context.Add(t);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }

    private bool TransactionExists(int id) {
        return _context.Transaction.Any(e => e.Id == id);
    }
}