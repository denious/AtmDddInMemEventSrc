using System;
using System.Threading.Tasks;
using Domain.Shared;
using Infrastructure.EFCore;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication2.Controllers
{
    public class AtmsController : ODataController
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMailService _mailService;

        public AtmsController(IServiceProvider serviceProvider, IMailService mailService)
        {
            _serviceProvider = serviceProvider;
            _mailService = mailService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var uow = _serviceProvider.GetService<IUnitOfWork>();
            return Ok(uow.AtmRepository.Get());
        }

        [EnableQuery]
        public async Task<IActionResult> Get(int key)
        {
            using (var uow = new EFCoreUnitOfWork(_mailService))
            {
                return Ok(await uow.AtmRepository.GetByIdAsync(key));
            }
        }
    }
}
