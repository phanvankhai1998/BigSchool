using BigSc.DTOs;
using BigSc.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSc.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbConText;
        public FollowingsController()
        {
            _dbConText = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbConText.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("The Attend already exists!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId

            };

            _dbConText.Followings.Add(following);
            _dbConText.SaveChanges();
            return Ok();
        }
    }
}
