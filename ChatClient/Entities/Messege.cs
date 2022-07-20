using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Entities
{
    public class Messege
    {
        private string Text { get; set; }
        private string Sender { get; set; }

        public override string ToString()
        {
            return $"{Sender}: {Text}";
        }

        public Messege(string text, string sender)
        {
            Text = text;
            Sender = sender;
        }
    }
}
