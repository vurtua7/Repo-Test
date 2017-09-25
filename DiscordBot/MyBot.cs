using Discord;
using Discord.Commands;
using Discord.Audio;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class MyBot
    {
        DiscordClient  discord;
        CommandService commands;
        //RegisterTextCommands reg;
        RegisterTextCommands regCommands;
        RegisterHelpCommands regHelp;
        Random random;



        string[] imageArray;
        string[] overCats;
        string[] cageArray;
        string[] communism;
        string[] ronSwanson;

        public MyBot()
        {
            imageArray = new string[]
            {
                "images/smooth1.jpg",
                "images/smooth2.jpg"
            };

            cageArray = new string[]
            {
                "memes/cageInACage.png",
                "memes/nickMorph.jpg",
                "memes/picolasCage.jpg"
            };

            overCats = new string[]
            {
                "images/overCats.jpg",
                "images/overCats2.jpg"
            };

            communism = new string[]
            {
                "<:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> \n",
                "<:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> \n",
                "<:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> \n",
                "<:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> \n",
                "<:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> \n",
                "<:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> \n",
                "<:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> \n",
                "<:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> <:communism:284030836989362176> \n"

            };
            ronSwanson = new string[]
            {
                "images/RonSwanson/allTheBacon.gif",
                "images/RonSwanson/america.gif",
                "images/RonSwanson/apology.gif",
                "images/RonSwanson/bacon.gif",
                "images/RonSwanson/bacon2.gif",
                "images/RonSwanson/bacon3.gif",
                "images/RonSwanson/bacon4.gif",
                "images/RonSwanson/dontCare.gif",
                "images/RonSwanson/fuckPhones.gif",
                "images/RonSwanson/iKnowWhatI'mAbout.gif",
                "images/RonSwanson/noVegetables.gif",
                "images/RonSwanson/ronFuckingSwanson.gif",
                "images/RonSwanson/sexualHistory.gif",
                "images/RonSwanson/swirling.gif",
                "images/RonSwanson/weapons.gif",
                "images/RonSwanson/what.gif",
                "images/RonSwanson/why.gif"

            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingAudio(x =>
            {
                x.Mode = AudioMode.Outgoing;
            });

            discord.UserJoined += async (s, e) =>
            {
                var user = e.User;
                var monkey = e.Server.FindUsers("vurtua7", false).FirstOrDefault();
                await user.SendMessage(string.Format(
                    "Hello! Welcome to the server!\n"
                    + "My name is **Lobby-Boy**, and I'll be your resident bot for your stay!\n"
                    + "To view a list of my commands, type __**!listCommands**__ in the general chat,\n"
                    + "and a list will be sent to you through DM's, like this one right now!\n"
                    + "If you want to suggest a command, do so in the botsuggestion channel.\n"
                    + "our resident code junky **Vurtua7** is always looking for new things to do,\n"
                    + "so even if it's crazy, ask! The worst that will happen is you'll get banned for your incompetence!\n"
                    + "No big deal! Anyway, have fun, play lots of games, and don't forget to smile, because I'm always watching!\n"
                    + ":eyes: :heart:\n\n __**Have a good day**__!"));
            };

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            random = new Random();
            commands = discord.GetService<CommandService>();
            regCommands = new RegisterTextCommands(commands,
               imageArray,
               overCats,
               cageArray,
               communism,
               ronSwanson);
            regHelp = new RegisterHelpCommands(commands);

            //Game game = new Game("kevin");

            commands = regCommands.getCommands();
            commands = regHelp.getCommands();

            registerPurgeCommands();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Mjg1NjM1MTczOTU1OTI4MDY1.C5ZDHQ.aEJXqErdHlb0WjwNYo1PQiSCTw0", TokenType.Bot);
            });

        }


        private void registerAudioCommands()
        {
            //var voiceChannel = discord.FindServers("Lobby Boy").FirstOrDefault().VoiceChannels.FirstOrDefault();
            //var voiceClient = discord.GetService<AudioService>().Join(voiceChannel);

            commands.CreateCommand("testMusic")
                .Do(async (e) =>
                {
                    var channelCount = discord.GetService<AudioService>().Config.Channels;
                    var OutFormat = new WaveFormat(48000, 16, channelCount);
                    using (var MP3Reader = new Mp3FileReader("sounds/switchClick.mp3"))
                    using (var resampler = new MediaFoundationResampler(MP3Reader, OutFormat))
                    {
                        resampler.ResamplerQuality = 60;
                        int blockSize = OutFormat.AverageBytesPerSecond / 50;
                        byte[] buffer = new byte[blockSize];
                        int byteCount;

                        while((byteCount = resampler.Read(buffer, 0, blockSize)) > 0)
                        {
                            if(byteCount < blockSize)
                            {
                                for (int i = byteCount; i < blockSize; i++)
                                    buffer[i] = 0;
                            }
                            //voiceClient.Send(buffer, 0, blockSize);
                        }
                    }
                        await e.Channel.SendMessage(string.Format("{0} is the target!"));
                });
        }

        private void registerPurgeCommands()
        {
            commands.CreateCommand("purge")
               .Do(async (e) =>
               {
                   var chanName = e.Channel.Name;
                   var user = e.User;
                   var role = user.Roles;
                   var monkey = e.Channel.FindUsers("vurtua7", false).FirstOrDefault();

                   if (role.Any(input => input.Name.ToUpper() == "CODE MONKEY") ||
                       role.Any(input => input.Name.ToUpper() == "ADMIN"))
                   {
                       await e.User.SendMessage(string.Format("deleting the last 100 of {0}'s messages.", chanName));
                       await monkey.SendMessage(string.Format("{0} purged {1}s messages", user.Name, chanName));
                       Message[] messagesToDelete;

                       messagesToDelete = await e.Channel.DownloadMessages(100);
                       await e.Channel.DeleteMessages(messagesToDelete);
                   }
                   else
                   {
                       await monkey.SendMessage(string.Format("{0} tried to purge {1}, but isn't an admin.", user.Name, chanName));
                       await e.User.SendMessage("you do not have permission to purge " + chanName + ". Please contact admin.");
                   }
                       
               });
        }
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
