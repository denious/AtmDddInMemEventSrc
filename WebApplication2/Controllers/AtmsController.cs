using System;
using System.Threading.Tasks;
using Domain.Shared;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class BanksController : ODataController
    {
        public BanksController()
        {
        }

        [EnableQuery]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(IIdentity key)
        {
            throw new NotImplementedException();
        }
    }
}
