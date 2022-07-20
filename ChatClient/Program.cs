using ChatClient.MessegeHolder;

namespace ChatClient
{
    class Program
    {
       
        static void Main(string[] args)
        {
            MessegeConsole messenger = new MessegeConsole();
            messenger.Run();
        }
    }
    class MessegeConsole
    {
        public MessegeHolderRepository repo = new MessegeHolderRepository();
        string localSender;

        public MessegeConsole()
        {
            localSender = Guid.NewGuid().ToString();
        }
        public void Run()
        {
            while (true)
            {
                //var p = repo.GetAllMessegesAsync().Result;
                string input = Console.ReadLine();

                /*
                if (input == null) continue;
                if (input == "0") break;

                foreach (var item in p)
                {
                    Console.WriteLine(item.ToString());
                }*/

                repo.PostMessegeAsync(new Entities.Messege("input", localSender));
            }
        }
    }
}