using ChatClient.Entities;
using ChatClient.MessegeHolder;

namespace ChatClient
{
    class MessegeConsole
    {
        public MessegeHolderRepository repo;
        private IList<Messege> messageList;
        static string localSender;

        public MessegeConsole()
        {
            repo = new MessegeHolderRepository();
            ListInit();
            localSender = Guid.NewGuid().ToString();
        }

        private async Task ListInit()
        {
            messageList = (await Task.Run(repo.GetAllMessegesAsync)).ToList();
        }

        private async Task<Task> SendMessege(string text, string sender)
        {
            await repo.PostMessegeAsync(new Messege(text, sender));
            await ListInit();
            return Task.CompletedTask;
        }

        public void Run()
        {
            PrintAsync();
            //repo.PostMessegeAsync(new Messege("asd","asdasd"));
            while (true)
            {
                var input = Console.ReadLine();

                if (input == null) continue;
                if (input == "0") break;

                SendMessege(input, localSender);
            }
        }

        public async void PrintAsync()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    ListInit().GetAwaiter().GetResult();
                    Console.Clear();
                    foreach (var item in messageList)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            });
        }
    }
}