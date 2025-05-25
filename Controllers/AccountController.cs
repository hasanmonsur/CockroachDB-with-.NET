using CockroachDBApi.Models;
using CockroachDBApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CockroachDBApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _accountService.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
                return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            var newAccount = await _accountService.CreateAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = newAccount.Id }, newAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _accountService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
