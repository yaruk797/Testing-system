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
using System.Security.Claims;

namespace Testing_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private TestDbContext _db;

        public TestsController(TestDbContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet("tests")]
        public async Task<IEnumerable<Test>> GetTests()
        {
            var userId = Int32.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return await _db.Tests.Where(t=>t.UserId == userId).ToListAsync();
        }

        [Authorize]
        [HttpGet("test/{id}")]
        public async Task<Test> GetTest(int id)
        {
            return await _db.Tests.Where(t => t.Id == id).Include(t => t.Questions).ThenInclude(t => t.Answers).FirstOrDefaultAsync();
        }

        [Authorize]
        [HttpPost("result")]
        public async Task<IActionResult> GetTestResult([FromBody] Question[] questionModels)
        {
            int result = 0;
            var test = await _db.Tests.Where(t => t.Id == questionModels.FirstOrDefault().TestId)
                .Include(t => t.Questions).ThenInclude(t => t.Answers).FirstOrDefaultAsync();

            for (var i = 0; i < test.Questions.Count; i++)
            {
                for (var j = 0; j < test.Questions[i].Answers.Count; j++)
                {
                    if (test.Questions[i].Answers[j].IsRight &&
                        test.Questions[i].Answers[j].Name == questionModels[i].UserAnswer)
                        result++;
                }
            }
            return Ok(result);
        }
    }
}
