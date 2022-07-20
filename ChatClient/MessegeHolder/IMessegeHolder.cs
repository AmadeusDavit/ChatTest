using ChatClient.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MessegeHolder
{
    interface IMessegeHolder
    {
        Task<List<Messege>> GetAllMessegesAsync();

        Task PostMessegeAsync(Messege messege);
    }
}
