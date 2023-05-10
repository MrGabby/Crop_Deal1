
using Crop_Deal1.Data;
using Crop_Deal1.Dtos;
using Crop_Deal1.Interface;
using Crop_Deal1.Models;
using Crop_Deal1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Crop_Deal1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly ApiDbContext context;
        private readonly IUser repo;
        public UserController(ApiDbContext context,IUser repo)
        {
            this.context = context;
            this.repo= repo;    
        }

        //  Repo DTO --------------------------------------------
        [HttpPost]
        public async Task<ActionResult<User>>PostUser(Userdto userd)
        {
            
            if (userd == null)
            {
                return BadRequest();
            }
            var user = new User()
            {
                Name = userd.Name,
                Password = userd.Password,
                Email_id = userd.Email_id,
                Contact = userd.Contact,
                Address = userd.Address,
                Roles = userd.Roles,
                Is_subscribe = userd.Is_subscribe
            };

            user = await repo.CreateUser(user);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUsers()
        {
            var user= await repo.GetUsers();
            if (user == null)
            {
                return BadRequest();
            }

            var userlist = new List<Userdto>();

            foreach (var i in user)
            {
                userlist.Add(new Userdto()
                {
                    Name=i.Name,
                    Password=i.Password,
                    Email_id=i.Email_id,
                    Contact = i.Contact,
                    Address = i.Address,
                    Roles = i.Roles,
                    Is_subscribe = i.Is_subscribe
                });
            }


            return Ok(userlist);
        }





        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (user == null)
            {
                return NotFound();
            }

            var database_user = repo.UpdateUser(id, user);
            if (database_user == null)
            {
                NotFound();
            }
            return Ok();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {

            var user = await repo.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // -----------------------------------------------------------


        /*        [HttpPost]
                public async Task<ActionResult<User>> PostUser(User b)
                {
                    context.Users.Add(b);
                    await context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetUser), new { id = b.Userid }, User);
                }*/

        /*        [HttpGet("{id}")]
                public async Task<ActionResult<User>> GetUser(int id)
                {
                    if (context.Users == null)
                    {
                        return NotFound();
                    }
                    var b = await context.Users.FindAsync(id);
                    if (b == null)
                    {
                        return NotFound();
                    }
                    return b;
                }*/
        /*        [HttpGet]
                public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
                {
                    if (context.Users == null)
                    {
                        return NotFound();
                    }
                    return await context.Users.ToListAsync();

                }*/

        /*        [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteUser(int id)
                {
                    if (context.Users == null)
                    {
                        return NotFound();
                    }
                    var user = await context.Users.FindAsync(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    context.Users.Remove(user);
                    await context.SaveChangesAsync();

                    return NoContent();
                }*/
        /*     
         *     
         *     {
        "user_id": 0,
        "user_name": "aman",
        "user_contact": "1234567890",
        "user_roles": "admin",
        "email_id": "aman@gmail.com",
        "password": 0,
        "dbo": "2023-05-01T20:17:07.400Z",
        "address": "Pune",
        "bank_name": "SBI",
        "bank_account_no": "12345678",
        "ifsc": "123",
        "is_subscribe": true,
        "is_Active": true
      }
         *     
         *     [HttpGet("{id}")]
              public async Task<IActionResult> GetUserById(int id)
              {
                  var user = await context.Users.FindAsync(id);

                  if (user == null)
                  {
                      return NotFound();
                  }

                  return Ok(user);
              }*/

        /*   [HttpPost]
           public async Task<ActionResult<User>> CreateUser(User u)
           { 

          *//*     var user = new User
               {
                   User_name = name,
                   Email_id = email,
                   Is_Active = is_active
               };*//*

               context.Users.Add(u);
               await context.SaveChangesAsync();

               return CreatedAtAction(nameof(GetUserById), new { id = u.User_id }, u);
           }*/
    }
}