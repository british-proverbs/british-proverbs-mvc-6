using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BritishProverbs.Domain;
using BritishProverbs.Web.Models;
using Microsoft.AspNet.Mvc;

namespace BritishProverbs.Web.Controllers
{
    public class VisitsController : Controller
    {
        private readonly IBritishProverbsContext _context;

        public VisitsController(IBritishProverbsContext context)
        {
            _context = context;
        }

        [HttpGet("visits")]
        [Produces("application/json")]
        public async Task<VisitsModel> GetVisits()
        {
            var visitsCount = await _context.GetVisitsCountAsync();

            return new VisitsModel
            {
                Count = visitsCount
            };
        }
    }
}
