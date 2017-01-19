using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XYZCorp.API.Data;
using XYZCorp.API.Exceptions;
using XYZCorp.API.Models;

namespace XYZCorp.API.Controllers
{
    public class UsersController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(UsersDB.GetAllUsers());
        }

        public IHttpActionResult Get(int id)
        {
            User user = null;
            try
            {
                user = UsersDB.Get(id);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }

            return Ok(user);
        }


        public IHttpActionResult Post([FromBody]User user)
        {
            int newUserId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                newUserId = UsersDB.Set(user);
            }
            catch (DuplicateNameException)
            {
                return BadRequest($"User with name - {user.Name} already exists");
            }

            return Ok(new { ID = newUserId });
        }

        [Route("~/api/setPoints")]
        public IHttpActionResult SetPoints(UpdateUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UsersDB.SetPoints(user.Id, user.Points);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
