using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperBestFriends.Business.DataTransfertObjects;
//using SuperBestFriends.DAL;
using SuperBestFriends.Web.DAL;
using SuperBestFriends.Web.DAL.Entities;
using SuperBestFriends.Web.Models.Profile;
using SuperBestFriends.Web.Models.User;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SuperBestFriends.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly FriendsDbContext _context;
        private readonly HttpClient httpClient;

        private readonly User? _connectedUser;
        public long connectedUserId = 3;
        public UserProfileDto connectedUser { get; set; }
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
            var httpResponse = await this.httpClient.GetAsync($"api/users/{connectedUserId}");

            if(!httpResponse.IsSuccessStatusCode)
                return NotFound();

            var userFromApi = await httpResponse.Content.ReadFromJsonAsync<UserProfileDto>();

            var userVm = ProfileViewModel.FromDto(userFromApi ?? new UserProfileDto());

            return View(userVm);
        }


        public async Task<IActionResult> People()
        {
            var httpResponse = await this.httpClient.GetAsync($"api/friends/{connectedUserId}");

            if (!httpResponse.IsSuccessStatusCode)
                return NotFound();

            var nonFriendsFromApi = await httpResponse.Content.ReadFromJsonAsync<List<UserDto>>();

            var nonFriendsVm = nonFriendsFromApi?.Select(ProfileViewModel.FriendFromDto).ToList() ?? new List<ProfileViewModel>();

            return View(nonFriendsVm);
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

        public async Task<IActionResult> AddFriend(long userId, long friendId)
        {
            userId = this.connectedUserId;

            var friendRequest = new FriendRequest
            {
                UserId = userId,
                FriendId = friendId
            };

            var httpResponse = await this.httpClient.PostAsJsonAsync("api/users/addFriend", friendRequest);

            if (!httpResponse.IsSuccessStatusCode)
            {
                var error = await httpResponse.Content.ReadAsStringAsync();
                return BadRequest(error);
            }

            return RedirectToAction(nameof(People));
        }

        public async Task<IActionResult> RemoveFriend(long userId, long friendId)
        {
            userId = this.connectedUserId;

            var friendRequest = new FriendRequest
            {
                UserId = userId,
                FriendId = friendId
            };

            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/users/removeFriend")
            {
                Content = JsonContent.Create(friendRequest)
            };

            var httpResponse = await this.httpClient.SendAsync(httpRequest);

            if (!httpResponse.IsSuccessStatusCode)
            {
                var error = await httpResponse.Content.ReadAsStringAsync();
                return BadRequest(error);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] ProfileViewModel user)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(user);

                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var httpResponse = await this.httpClient.PutAsync($"api/Users/{user.UserId}", httpContent);

                if (httpResponse.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }


    }
}
