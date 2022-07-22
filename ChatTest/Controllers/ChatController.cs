using ChatTest.Entities;
using ChatTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChatTest.Controllers
{
    [ApiController]
    [Route("chat")]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository repo;

        public ChatController(IChatRepository repository)
        {
            repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await repo.GetAllMessegesAsync());
        }

        [HttpPost("submitmessage")]
        public IActionResult PostMessege(MessegeEntity messege)
        {
            var messegeEntity = new MessegeEntity
            {
                Sender = messege.Sender,
                Text = messege.Text,
            };
            repo.PostMessegeAsync(messegeEntity);
            return Ok();
        }
    }
}