using Microsoft.AspNetCore.Mvc;
using TgChatbot.Models;
using TgChatbot.Services;

namespace TgChatbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
        {
            string response = await _chatService.GetResponseAsync(request.Message);

            return Ok(response);
        }

    }
}
