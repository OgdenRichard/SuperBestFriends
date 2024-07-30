using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SuperBestFriends.Web.DAL;
using SuperBestFriends.Web.DAL.Entities;
using SuperBestFriends.Web.Models.Users;

namespace SuperBestFriends.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly FriendsDbContext _context;

        public UsersController(FriendsDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var usersVm = await _context.Users.Select(u => UserBaseViewModel.FromModel(u))
                                             .ToListAsync();

            return View(usersVm);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            UserInputViewModel userInputViewModel = new();
            //PopulateList(ref userInputViewModel);
            return View(userInputViewModel);
        }

        //private void PopulateList(ref UserInputViewModel userInputViewModel)
        //{
        //    userInputViewModel.
        //    throw new NotImplementedException();
        //}






        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,BirthDate,Email,PhoneNumber,Address,Interests,Image")] UserInputViewModel vm)
        {
            if (CheckEmail(vm.Email))
            {
                ModelState.AddModelError(nameof(UserInputViewModel.Email), "L'utilisateur déja existant ! ");
            }

            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    BirthDate = vm.BirthDate,
                    Email = vm.Email,
                    PhoneNumber = vm.PhoneNumber,
                    Address = vm.Address,
                    Interests = vm.Interests,
                    
 
                };
                _context.Add(user);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }







        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var matchingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (matchingUser == null)
            {
                return NotFound();
            }

            var userInputVm = new UserInputViewModel()
            {
                UserId = matchingUser.UserId,
                FirstName = matchingUser.FirstName,
                LastName = matchingUser.LastName,
                Email = matchingUser.Email,
                BirthDate = matchingUser.BirthDate,
                PhoneNumber = matchingUser.PhoneNumber,
                Address = matchingUser.Address,
                Interests = matchingUser.Interests

            };

            return View(userInputVm);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("FirstName,LastName,BirthDate,Email,PhoneNumber,Address,Interests")] UserInputViewModel vm)
        {
            var matchingUser = await this._context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (matchingUser is null)
            {
                return NotFound();
            }

            if (CheckEmail(vm.Email) && id != matchingUser.UserId)
            {
               ModelState.AddModelError(nameof(UserInputViewModel.Email), "L'utilisateur déja existant ! ");
              
            }

            if (ModelState.IsValid)
            {
                matchingUser.FirstName = vm.FirstName;
                matchingUser.LastName = vm.LastName;
                //matchingUser.Email = vm.Email;
                matchingUser.BirthDate = vm.BirthDate;
                matchingUser.PhoneNumber = vm.PhoneNumber;
                matchingUser.Address = vm.Address;
                matchingUser.Interests = vm.Interests;


                _context.Update(matchingUser);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        private bool CheckEmail(string Email)
        {
            return _context.Users.Any(e => e.Email == Email);
        }
    }
}
