using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalkGaming.Models;
using AutoMapper;
using TalkGaming.Dtos;

namespace TalkGaming.Controllers.Api
{
    public class ForumsController : ApiController
    {
        private ApplicationDbContext _context;

        public ForumsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/forums
        public IHttpActionResult GetForums(string query = null)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var forumsQuery = _context.Forums.ToList();

            if (!String.IsNullOrWhiteSpace(query))
                forumsQuery = forumsQuery.Where(c => c.Title.Contains(query)).ToList();

            var forumsDto = forumsQuery.Select(Mapper.Map<Forum, ForumDto>);

            return Ok(forumsDto);
        }
    }
}
