using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using Baseline.ImTools;
using java.util.stream;

using LamarCodeGeneration.Util;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;
        

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _context.Users.FindAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            user.Id = id;
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        private bool EmailExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
       /* public List<User> findByEmail(String email)
        {
            List<User> usersByEmail = getAll().stream()
                    .filter(U ->u.getEmail().trim().equals(email.Trim()))
                    .collect(Collectors.toList());
            return usersByEmail;
        }
        public virtual System.Threading.Tasks.Task<TUser> FindByEmailAsync(string email);
        public List<User> findByGrade(String role)
        {
            List<User> usersByGrade = getAll().stream()
                    .filter(U ->u.getGrade().equals(role))
                    .collect(Collectors.toList());

            return usersByGrade;
        }
        //verifier si le mot de passe crypter(celle enregistrer dans la BD) et celle saisie sont identique w non
        public bool matches(String email, String LogInPassword)
        {
            User u = null;
            List<User> users = this.findByEmail(email);
            foreach (User user in users)
            { u = user; }

            if (u == null)
            {
                throw new Exception("email introuvabre");
            }
            else
            {
                bool isMatchPassword = passwordEncoder.matches(LogInPassword, u.getPassword());

                return isMatchPassword;
            }*/


        }
    }

