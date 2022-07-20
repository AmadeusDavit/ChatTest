using ChatTest.Entities;

namespace ChatTest.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<MessegeEntity>> GetAllMessegesAsync();
        Task<MessegeEntity> PostMessegeAsync(MessegeEntity messege);
    }
}
