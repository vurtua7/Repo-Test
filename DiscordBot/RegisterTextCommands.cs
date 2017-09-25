using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class RegisterTextCommands : MyBot
    {
        private string message;
        private int id;
        
        public void main()
        {

        }
        public async void SetMessage(string s, Discord.Channel e)
        {
            message = s;
            var user = e;

            await e.SendMessage(message);
        }


    }
}
