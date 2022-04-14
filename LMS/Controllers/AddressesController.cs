using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using LMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseController<Address, AddressRepository, int>
    {
        private readonly AddressRepository addressRepo;
        private IConfiguration configuration;

        //Constructor
        public AddressesController(AddressRepository addressRepo, IConfiguration configuration) : base(addressRepo)
        {
            this.addressRepo = addressRepo;
            this.configuration = configuration;
        }
    }
}
