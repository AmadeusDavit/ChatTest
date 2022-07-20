using ChatTest.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatTest.Repositories
{
    public class InMemoryRepository : IChatRepository
    {
        private readonly string path = "C:/Users/dkazaryan/Desktop/VsGarbage/ChatTest/Messeges.txt";
        private List<MessegeEntity> _messeges = new List<MessegeEntity>();

        public Task<IEnumerable<MessegeEntity>> GetAllMessegesAsync()
        {
            string jsonMessegesFromTxt = File.ReadAllText(path);
            _messeges = JsonSerializer.Deserialize<IEnumerable<MessegeEntity>>(jsonMessegesFromTxt).ToList();

            return Task.FromResult<IEnumerable<MessegeEntity>>(_messeges);
        }

        public Task<MessegeEntity> PostMessegeAsync(MessegeEntity messege)
        {
            _messeges.Add(messege);

            string jsonMesseges = JsonSerializer.Serialize(_messeges);
            File.WriteAllText(path, jsonMesseges);

            return Task.FromResult(messege);
        }
    }
}
