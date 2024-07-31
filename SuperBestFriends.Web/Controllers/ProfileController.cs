using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperBestFriends.Business.DataTransfertObjects;
using SuperBestFriends.Web.DAL;
using SuperBestFriends.Web.DAL.Entities;
using SuperBestFriends.Web.Models.Profile;
using SuperBestFriends.Web.Models.User;
using System.Net;

namespace SuperBestFriends.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly FriendsDbContext _context;
        private readonly HttpClient httpClient;

        private readonly User? _connectedUser;
        //public ProfileController(FriendsDbContext context)
        //{
        //    _context = context;
        //    _connectedUser = context.Users.Include(f => f.Friends).FirstOrDefault(m => m.UserId == 1);
        //}
        public ProfileController(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient("SuperBestFriendsAPI");
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            //var friendIds = _connectedUser.Friends.Select(f => f.UserId).ToList();

            //var users = _context.Users.Select(u => new ProfileViewModel
            //{
            //    UserId = u.UserId,
            //    FirstName = u.FirstName,
            //    LastName = u.LastName,
            //    BirthDate = u.BirthDate,
            //    IsFriend = friendIds.Contains(u.UserId)
            //});

            //var usersList = await users.ToListAsync();

            //var profileUser = new ProfileViewModel
            //{
            //    UserId = _connectedUser.UserId,
            //    FirstName = _connectedUser.FirstName,
            //    LastName = _connectedUser.LastName,
            //    BirthDate = _connectedUser.BirthDate,
            //    Email = _connectedUser.Email,
            //    PhoneNumber = _connectedUser.PhoneNumber,
            //    Interests = _connectedUser.Interests,
            //    People = usersList
            //};

            var httpResponse = await this.httpClient.GetAsync($"api/users/{1}");

            if(!httpResponse.IsSuccessStatusCode)
                return NotFound();

            var userFromApi = await httpResponse.Content.ReadFromJsonAsync<UserProfileDto>();

            var userVm = ProfileViewModel.FromDto(userFromApi ?? new UserProfileDto());

            return View(userVm);
        }


        public async Task<IActionResult> People()
        {
            var nonfriends = _context.Users
                .Where(u => u.UserId != _connectedUser.UserId)
                .Where(u => !u.FriendsOf.Any(f => f.UserId == _connectedUser.UserId))
                .Select(u => new ProfileViewModel
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    BirthDate = u.BirthDate,
                });
            var vm = await nonfriends.ToListAsync();
            return View(vm);
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

        public async Task<IActionResult> AddFriend(string userId)
        {
            long friendId = Convert.ToInt64(userId);
            if (friendId != 0 && UserExists(friendId))
            {
                User newFriend = _context.Users.FirstOrDefault(u => u.UserId == friendId);
                _connectedUser.Friends.Add(newFriend);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveFriend(string userId)
        {
            long friendId = Convert.ToInt64(userId);
            if (friendId != 0 && UserExists(friendId))
            {
                User newFriend = _context.Users.FirstOrDefault(u => u.UserId == friendId);
                _connectedUser.Friends.Remove(newFriend);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Edit/5
        /*public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }*/

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("UserId,FirstName,LastName,BirthDate,Email,PhoneNumber,Interests")] ProfileViewModel user)
        {

            if (ModelState.IsValid)
            {

                _connectedUser.FirstName = user.FirstName;
                _connectedUser.LastName = user.LastName;
                _connectedUser.BirthDate = user.BirthDate;
                _connectedUser.Email = user.Email;
                _connectedUser.PhoneNumber = user.PhoneNumber;
                _connectedUser.Interests = user.Interests;

                try
                {
                    _context.Update(_connectedUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(_connectedUser.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
            // return View(user);
        }


        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }


    }
}
