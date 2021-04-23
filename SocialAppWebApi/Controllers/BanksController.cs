using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        IBankService _bankService;

        public BanksController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet("getall")]
        async public Task<IActionResult> GetAll()
        {
            var data = await _bankService.GetAllAsync();
            if (data.Success)
            {
              return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getcoinsbyuserid/{id}")]
        public IActionResult GetCoinsByUserId(int id)
        {
            var data =  _bankService.GetCoinsByUserId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getcoopercoinbyuserid/{id}")]
        public IActionResult GetCooperCoinByUserId(int id)
        {
            var data = _bankService.GetCooperCoinByUserId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getgoldcoinbyuserid/{id}")]
        public IActionResult GetGoldCoinByUserId(int id)
        {
            var data = _bankService.GetGoldCoinByUserId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getsilvercoinbyuserid/{id}")]
        public IActionResult GetSilverCoinByUserId(int id)
        {
            var data = _bankService.GetSilverCoinByUserId(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getcoppercoinwallets")]
        public IActionResult GetCopperCoinWallets()
        {
            var data = _bankService.GetCopperCoinWallets();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getsilvercoinwallets")]
        public IActionResult GetSilverCoinWallets()
        {
            var data = _bankService.GetSilverCoinWallets();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpGet("getgoldcoinwallets")]
        public IActionResult GetGoldCoinWallets()
        {
            var data = _bankService.GetGoldCoinWallets();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }


    }
}
