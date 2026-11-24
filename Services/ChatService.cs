using OpenAI.Chat;

namespace TgChatbot.Services
{
    public class ChatService
    {
        private readonly ChatClient _chatClient;

        public ChatService(IConfiguration configuration)
        {
            string apiKey = configuration["OpenAI:ApiKey"]
                ?? throw new Exception("OpenAI API key nije pronađen.");

            _chatClient = new ChatClient("gpt-5.1", apiKey);
        }
        public async Task<string> GetResponseAsync(string message)
        {
            ChatCompletion completion =
                await _chatClient.CompleteChatAsync(message);

            return completion.Content[0].Text;
        }
    }
}
