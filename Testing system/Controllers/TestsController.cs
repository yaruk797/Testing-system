using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing_system.Models;
using Testing_system.Models.Entities;

namespace Testing_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private IConfiguration _config;
        private TestDbContext _db;

        public TestsController(IConfiguration config, TestDbContext db)
        {
            _config = config;
            _db = db;
        }

        [Authorize]
        [HttpGet("tests")]
        public async Task<IEnumerable<Test>> GetTests()
        {
            return await _db.Tests.ToListAsync();
        }

        [Authorize]
        [HttpGet("test/{id}")]
        public async Task<Test> GetTest(int id)
        {
            return await _db.Tests.Where(t => t.Id == id).Include(t => t.Questions).ThenInclude(t => t.Answers).FirstOrDefaultAsync();
        }
    }
}
