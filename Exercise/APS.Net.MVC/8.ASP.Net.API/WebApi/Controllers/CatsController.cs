using System.Collections.Generic;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
	[RoutePrefix("api/cats")]
	public class CatsController : ApiController
	{
		private ApplicationDbContext _context;

		public CatsController()
		{
			this._context = new ApplicationDbContext();
		}
		// GET: api/Cats
		[HttpGet]
		[Route]
		public IEnumerable<Cat> Get()
		{
			return this._context.Cats;
		}

		// GET: api/Cats/5
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Cats
		public void Post([FromBody]string value)
		{
		}

		// PUT: api/Cats/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Cats/5
		public void Delete(int id)
		{
		}
	}
}
