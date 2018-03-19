using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public string Date { get; set; }
        public Message(string text, string sender)
        {
            Text = text;
            Sender = sender;
            Date = DateTime.Now.ToString();
        }
    }
}
