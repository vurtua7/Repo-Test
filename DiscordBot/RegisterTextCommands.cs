using System;
using System.Collections.Generic;
using System.Linq;
using Discord.Commands;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class RegisterTextCommands
    {
        //private string message;
        //private int id;
        Random random;

        string[] imageArray;
        string[] overCats;
        string[] cageArray;
        string[] communism;
        string[] ronSwanson;

        private CommandService commands;

        public RegisterTextCommands(CommandService commands, 
            string[] imageArray,
            string[] overCats,
            string[] cageArray,
            string[] communism,
            string[] ronSwanson)
        {
            this.commands = commands;
            this.imageArray = imageArray;
            this.overCats = overCats;
            this.cageArray = cageArray;
            this.communism = communism;
            this.ronSwanson = ronSwanson;

            random = new Random();

            registerCommands();
            registerSummonCommands();
            registerPOTGCommands();
            registerRngCommands();
            registerDnDCommands();
            registerMemeCommands();
        }

        public CommandService getCommands()
        {
            return commands;
        }

        public void registerCommands()
        {
            commands.CreateCommand("Hello")
                .Do(async (e) =>
                {
                    string user = e.User.NicknameMention;
                    if(e.User.ServerPermissions.Administrator)
                        await e.Channel.SendMessage("yousabitch! " + user);

                    //Console.WriteLine(e.User.CurrentGame.Value.Name);

                    await e.Channel.SendMessage("Hi! " + user);

                });

            commands.CreateCommand("FuckYou")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("*Bends Over*");
                });

            commands.CreateCommand("freshmaker")
                .Do(async (e) =>
                {
                    var user = e.User;
                    await e.Channel.SendMessage(string.Format("{0}'s looking for some mentos!\n", user.Mention));
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=sdnJxDmJNmA");
                });

            commands.CreateCommand("Youpassbutter")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=wqzLoXjFT34");
                });

            commands.CreateCommand("WaitAMinute")
                .Parameter("target", ParameterType.Optional)
                .Do(async (e) =>
                {
                    string targetString = e.GetArg("target");
                    var user = e.User;
                    var target = e.Server.FindUsers(targetString, false).FirstOrDefault();

                    if (String.IsNullOrEmpty(targetString))
                        await e.Channel.SendMessage(string.Format("{0} wants to wait a minute \n https://youtu.be/w_Fk0i9Vq_o?t=10s", user.Mention));
                    else
                        await e.Channel.SendMessage(string.Format("{0} needs {1} to wait a minute \n https://youtu.be/w_Fk0i9Vq_o?t=10s", user.Mention, target.Mention));
                });

            commands.CreateCommand("ButtTouch")
                .Parameter("target", ParameterType.Optional)
                .Do(async (e) =>
                {
                    string targetString = e.GetArg("target");

                    if (String.IsNullOrEmpty(targetString))
                        await e.Channel.SendMessage(string.Format("{0}, you're gunna need to target someone for this!", e.User.Mention));
                    else
                    {
                        var target = e.Server.FindUsers(targetString, false).FirstOrDefault();

                        var user = e.User;

                        await e.Channel.SendMessage(string.Format("{0} touches {1}'s butt!\n", user.Mention, target.Mention));
                        await e.Channel.SendFile("images/buttTouch.jpg");
                    }
                });

            commands.CreateCommand("FUCKYOUMOM")
                .Do(async (e) =>
                {
                    string user = e.User.NicknameMention;
                    await e.Channel.SendMessage(user + " is being an edgy teen!\n");
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=IQeV-27jMHQ");
                });

            commands.CreateCommand("ShowMeHasselHoff")
                .Do(async (e) =>
                {
                    string user = e.User.NicknameMention;
                    await e.Channel.SendMessage(user + " THE HOFF COMITH!\n ");
                    await e.Channel.SendFile("images/theHoff.gif");
                });

            commands.CreateCommand("finnaBeLit")
                .Do(async (e) =>
                {
                    string user = e.User.NicknameMention;
                    await e.Channel.SendMessage(user + "'s GONNA FINNA BE LIT MY FRIENDS!\n ");
                    await e.Channel.SendFile("images/finnaBeLit.jpg");
                });

            commands.CreateCommand("Smooth")
                .Do(async (e) =>
                {
                    int rand = random.Next(0, imageArray.Length);

                    string user = e.User.NicknameMention;
                    await e.Channel.SendMessage(user + " DAMN THAT'S SMOOTH AF!\n ");
                    await e.Channel.SendFile(imageArray[rand]);
                });

            commands.CreateCommand("litNights")
                .Do(async (e) =>
                {
                    var permission = e.User.Roles;
                    var user = e.Channel.FindUsers("latenights", false).FirstOrDefault();
                    var mention = user.Mention;

                    await e.Channel.SendMessage(mention + " GETTIN LIT!\n ");
                    await e.Channel.SendFile("images/litNights.jpg");
                });

            commands.CreateCommand("communism")
                .Parameter("target", ParameterType.Optional)
                .Do(async (e) =>
                {
                    if (e.User.GetPermissions(e.Channel).ManageChannel == true)
                    {
                        string uiTarget = e.GetArg("target");

                        if (String.IsNullOrEmpty(uiTarget))
                        {
                            await e.Channel.SendMessage("COMMUNISM FOR ALL!!!\n");
                            for (int i = 0; i < communism.Length; i++)
                                await e.Channel.SendMessage(communism[i]);
                        }
                        else
                        {
                            var target = e.Channel.FindUsers(uiTarget, false).FirstOrDefault();

                            await e.Channel.SendMessage(string.Format("{0} WISHES FOR {1} TO EXPERIANCE COMMUNISM!\n", e.User.Mention, target.Mention));
                            for (int i = 0; i < communism.Length; i++)
                                await e.Channel.SendMessage(communism[i]);
                        }
                    }
                    else
                        await e.Channel.SendMessage(string.Format("{0}, you don't have suitable permissions to use this command.", e.User.Mention));

                });

            commands.CreateCommand("Kayzee")
                .Do(async (e) =>
                {
                    var user = e.Channel.FindUsers("kayzee", false).FirstOrDefault();
                    var mention = user.Mention;
                    await e.Channel.SendMessage("Shit " + mention + "says\n");
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=m0EsYiNA76Q");
                });

            commands.CreateCommand("sodaNotPop")
                .Do(async (e) =>
                {
                    var mention = e.User.Mention;
                    await e.Channel.SendMessage(mention + "YA DAMN RIGHT! IN 'MURICA!\n");
                    await e.Channel.SendFile("images/notPop.png");
                });

            commands.CreateCommand("overCats")
                .Do(async (e) =>
                {
                    var mention = e.User.Mention;
                    int rand = random.Next(0, overCats.Length);
                    switch (rand)
                    {
                        case 0:
                            await e.Channel.SendMessage(mention + " WANTS TO PET THE OVERCATS!!\n");
                            await e.Channel.SendFile(overCats[0]);
                            break;
                        case 1:
                            await e.Channel.SendMessage(mention + " WANTS TO PET THE OVERCATS!!\n");
                            await e.Channel.SendFile(overCats[1]);
                            break;
                        default:
                            await e.Channel.SendMessage(mention + " WANTS TO PET THE OVERCATS!!\n");
                            await e.Channel.SendFile(overCats[1]);
                            break;
                    }
                });

            commands.CreateCommand("swanson")
                .Do(async (e) =>
                {
                    var mention = e.User.Mention;
                    int rand = random.Next(0, ronSwanson.Length + 1);
                    switch (rand)
                    {
                        case 0:
                            await e.Channel.SendMessage(mention + " wants all the bacon!!\n");
                            await e.Channel.SendFile(ronSwanson[0]);
                            break;
                        case 1:
                            await e.Channel.SendMessage(mention + " knows what's really american!!\n");
                            await e.Channel.SendFile(ronSwanson[1]);
                            break;
                        case 2:
                            await e.Channel.SendMessage(mention + " does not accept your apology!!\n");
                            await e.Channel.SendFile(ronSwanson[2]);
                            break;
                        case 3:
                            await e.Channel.SendMessage(mention + " knows where there's bacon\n");
                            await e.Channel.SendFile(ronSwanson[3]);
                            break;
                        case 4:
                            await e.Channel.SendMessage(mention + " knows where there's bacon\n");
                            await e.Channel.SendFile(ronSwanson[4]);
                            break;
                        case 5:
                            await e.Channel.SendMessage(mention + " knows where there's bacon\n");
                            await e.Channel.SendFile(ronSwanson[5]);
                            break;
                        case 6:
                            await e.Channel.SendMessage(mention + " knows where there's bacon\n");
                            await e.Channel.SendFile(ronSwanson[6]);
                            break;
                        case 7:
                            await e.Channel.SendMessage(mention + " doesn't care!!\n");
                            await e.Channel.SendFile(ronSwanson[7]);
                            break;
                        case 8:
                            await e.Channel.SendMessage(mention + " hates phones\n");
                            await e.Channel.SendFile(ronSwanson[8]);
                            break;
                        case 9:
                            await e.Channel.SendMessage(mention + " knows what their about\n");
                            await e.Channel.SendFile(ronSwanson[9]);
                            break;
                        case 10:
                            await e.Channel.SendMessage(mention + " doesn't want vegetables\n");
                            await e.Channel.SendFile(ronSwanson[10]);
                            break;
                        case 11:
                            await e.Channel.SendMessage(mention + " Was born ready!!\n");
                            await e.Channel.SendFile(ronSwanson[11]);
                            break;
                        case 12:
                            await e.Channel.SendMessage(mention + " keeps it private!!\n");
                            await e.Channel.SendFile(ronSwanson[12]);
                            break;
                        case 13:
                            await e.Channel.SendMessage(mention + " doesn't fucking care, go away.\n");
                            await e.Channel.SendFile(ronSwanson[13]);
                            break;
                        case 14:
                            await e.Channel.SendMessage(mention + " knows where to get a weapon\n");
                            await e.Channel.SendFile(ronSwanson[14]);
                            break;
                        case 15:
                            await e.Channel.SendMessage(mention + " is asking what you're doing.\n");
                            await e.Channel.SendFile(ronSwanson[15]);
                            break;
                        case 16:
                            await e.Channel.SendMessage(mention + " is wondering why you're here....\n");
                            await e.Channel.SendFile(ronSwanson[16]);
                            break;
                        default:
                            await e.Channel.SendMessage(mention + " know's what's american.\n");
                            await e.Channel.SendFile(ronSwanson[1]);
                            break;
                    }
                });

            commands.CreateCommand("capCanada")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("CAPTAIN CANADA'S ON HIS WAY!\n ");
                    await e.Channel.SendFile("images/capCanada.jpg");
                });

            commands.CreateCommand("CashMeOutside")
                .Parameter("target", ParameterType.Optional)
                .Do(async (e) =>
                {
                    string targetString = e.GetArg("target");
                    string user = e.User.NicknameMention;

                    if (!String.IsNullOrEmpty(targetString))
                    {
                        var target = e.Server.FindUsers(targetString, false).FirstOrDefault();
                        await e.Channel.SendMessage(target.Mention + " How Bout Dash?\n ");
                        await e.Channel.SendFile("images/cashMeOutside.gif");
                    }
                    else
                    {
                        await e.Channel.SendMessage(user + " How Bout Dash?\n ");
                        await e.Channel.SendFile("images/cashMeOutside.gif");
                    }
                });

            commands.CreateCommand("SendNudz")
                .Parameter("target", ParameterType.Optional)
                .Do(async (e) =>
                {
                    string userInput = e.GetArg("target");
                    var target = e.Channel.FindUsers(userInput, false).FirstOrDefault();
                    if (String.IsNullOrEmpty(userInput))
                    {
                        await e.Channel.SendMessage("How about some nudes?\n ");
                        await e.Channel.SendFile("images/sendNudz.png");
                    }
                    else
                    {
                        await e.Channel.SendMessage(target.Mention + " How about some nudes?\n ");
                        await e.Channel.SendFile("images/sendNudz.png");
                    }
                });

            //commands.CreateCommand("911")
            //    .Parameter("target", ParameterType.Optional)
            //    .Do(async (e) =>
            //    {
            //        string userInput = e.GetArg("target");
            //        var target = e.Channel.FindUsers(userInput, false).FirstOrDefault();
            //        var user = e.User;
            //        if(user.ServerPermissions.SendMessages) //BanMambers
            //        {
            //            if (String.IsNullOrEmpty(userInput))
            //            {
            //                await e.Channel.SendMessage("Police: Hello, this is the police, what's your emergency?");
            //                System.Threading.Thread.Sleep(1500);
            //                await e.Channel.SendMessage(user.Mention + ": Hello, yes, the people in " + e.Server.Name + " are being racist!");
            //                System.Threading.Thread.Sleep(1500);
            //                await e.Channel.SendMessage("Police: Understood, a swat team has been dispatched and are on the way! Sit tight " + user.Mention);
            //                System.Threading.Thread.Sleep(1500);
            //                await e.Channel.SendMessage(user.Mention + ": Thank god, I can finally feel safe! Thank you very much!");
            //            }
            //            else
            //            {
            //                await e.Channel.SendMessage("Police: This is the police, what's your emergency?");
            //                System.Threading.Thread.Sleep(1500);
            //                await e.Channel.SendMessage(user.Mention + ": Hello, yes," + target.Mention + " is being racists!");
            //                System.Threading.Thread.Sleep(1500);
            //                await e.Channel.SendMessage("Police: Understood, a swat team has been dispatched and are on the way! Sit tight " + user.Mention);
            //                System.Threading.Thread.Sleep(1500);
            //                await e.Channel.SendMessage(user.Mention + ": Thank god, I can finally feel safe! Thank you very much!");
            //            }
            //        }
            //        else
            //        {
            //            await e.Channel.SendMessage(user.Mention + ", you're not old enough to call the cops. (you don't have permission to use this command) ");
            //        }
            //    });

            commands.CreateCommand("paramTest")
                .Parameter("justANumber", ParameterType.Required)
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage(e.GetArg("justANumber"));
                });

            commands.CreateCommand("userInfoTest")
                .Do(async (e) =>
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
                });

            //commands.CreateCommand("ttsTest")
            //.Parameter("test", ParameterType.Multiple)
            //.Do(async (e) =>
            //{
            //    var channel = e.Server.FindChannels("devtestchannel", ChannelType.Text).FirstOrDefault();

            //    var userRoles = e.User.Roles;

            //    if (userRoles.Any(input => input.Name.ToUpper() == "CODE MONKEY") ||
            //       userRoles.Any(input => input.Name.ToUpper() == "ADMIN"))
            //    {
            //        string message = e.GetArg("test");

            //        var user = e.User;
            //        await channel.SendTTSMessage(string.Format("{0} says, " + message, user.Name));
            //    }

            //    else
            //    {
            //        await e.User.SendMessage("You don't have permission to use this command m8!");
            //    }
            //});

            commands.CreateCommand("userTargetTest")
                .Parameter("target", ParameterType.Required)
                .Do(async (e) =>
                {
                    var user = e.Server.FindUsers(e.GetArg("target"), false).FirstOrDefault();
                    string target = e.GetArg("target");
                    await e.Channel.SendMessage(string.Format("{0} is the target!", user.Name));
                });
        }
        //public async void SetMessage(Discord.Channel e)
        //{
        //    var user = e;

        //    await e.SendMessage(message);
        //}

        private void registerSummonCommands()
        {
            commands.CreateCommand("Oversquad")
                .Do(async (e) =>
                {
                    var overSquad = e.Server.FindRoles("Oversquad", false).FirstOrDefault();
                    await e.Channel.SendMessage(string.Format("Hey {0}, game for some Overwatch?", overSquad.Mention));
                });

            commands.CreateCommand("Starvesquad")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("<@&289629983004033024>, time to survive.");
                });

            commands.CreateCommand("SummonCodemonkey")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("<@87082858342002688> has been summoned!!");
                });

            commands.CreateCommand("NeedHealing")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("<@263790086812991490>, THEY NEED YOUR HELP!!");
                    await e.Channel.SendFile("images/kayzee.png");
                });

            commands.CreateCommand("SummonGod")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("<@201186457082134528> has been summoned!!");
                    await e.Channel.SendFile("images/chrisKun.jpg");
                });

            commands.CreateCommand("gator")
                .Do(async (e) =>
                {
                    var target = e.Server.FindUsers("GatorX", false).FirstOrDefault();

                    var userRoles = e.User.Roles;

                    if (userRoles.Any(input => input.Name.ToUpper() == "CODE MONKEY") ||
                       userRoles.Any(input => input.Name.ToUpper() == "ADMIN"))
                    {
                        for (int i = 0; i < 10;)
                        {
                            await target.SendMessage("you have been summoned to the lobby!!");
                            i++;
                        }
                    }
                });

            //commands.CreateCommand("yogi")
            //    .Do(async (e) =>
            //    {
            //        var target = e.Server.FindUsers("yogithepanda", false).FirstOrDefault();

            //        var userRoles = e.User.Roles;

            //        if (userRoles.Any(input => input.Name.ToUpper() == "CODE MONKEY") ||
            //           userRoles.Any(input => input.Name.ToUpper() == "ADMIN"))
            //        {
            //            for (int i = 0; i < 10;)
            //            {
            //                await target.SendMessage("youzaho!!");
            //                i++;
            //            }
            //        }
            //    });

            //commands.CreateCommand("chris")
            //    .Do(async (e) =>
            //    {
            //        var target = e.Server.FindUsers("Chrispy", false).FirstOrDefault();

            //        var userRoles = e.User.Roles;

            //        if (userRoles.Any(input => input.Name.ToUpper() == "CODE MONKEY") ||
            //           userRoles.Any(input => input.Name.ToUpper() == "ADMIN"))
            //        {
            //            for (int i = 0; i < 10;)
            //            {
            //                await target.SendMessage("you have been summoned to the lobby!!");
            //                i++;
            //            }
            //        }

            //    });
            //commands.CreateCommand("pleaseno")
            //    .Do(async (e) =>
            //    {
            //        var target = e.Server.FindUsers("Chrispy", false).FirstOrDefault();

            //        var userRoles = e.User.Roles;

            //        if (userRoles.Any(input => input.Name.ToUpper() == "CODE MONKEY") ||
            //           userRoles.Any(input => input.Name.ToUpper() == "ADMIN"))
            //        {
            //            for (int i = 0; i < 10;)
            //            {
            //                await target.SendMessage("please don't, I'm just a child!");
            //                i++;
            //            }
            //        }

            //    });
        }

        private void registerPOTGCommands()
        {
            commands.CreateCommand("kayzeePOTG")
                .Do(async (e) =>
                {
                    var user = e.Server.FindUsers("kayzee", false).FirstOrDefault();

                    await e.Channel.SendMessage(string.Format("{0}'s POTG!\n", user.Mention));
                    await e.Channel.SendFile("images/POTG/kayzeePOTG.png");
                });

            commands.CreateCommand("vurtua7POTG")
                .Do(async (e) =>
                {
                    var user1 = e.Server.FindUsers("kayzee", false).FirstOrDefault();
                    var user2 = e.Server.FindUsers("vurtua7", false).FirstOrDefault();

                    await e.Channel.SendMessage(string.Format("{1}'s POTG, with the help of {0}\n", user1.Mention, user2.Mention));
                    await e.Channel.SendFile("images/POTG/vurtua7POTG.jpg");
                });

            commands.CreateCommand("latenightsPOTG")
                .Do(async (e) =>
                {
                    var user = e.Server.FindUsers("latenights", false).FirstOrDefault();

                    await e.Channel.SendMessage(string.Format("{0}'s POTG!\n", user.Mention));
                    await e.Channel.SendFile("images/POTG/latenightsPOTG.jpg");
                });

            commands.CreateCommand("barbPOTG")
                .Do(async (e) =>
                {
                    var user = e.Server.FindUsers("modernbarbarian", false).FirstOrDefault();

                    await e.Channel.SendMessage(string.Format("{0}'s POTG!\n", user.Mention));
                    await e.Channel.SendFile("images/POTG/barbPOTG.png");
                });

            commands.CreateCommand("hinesPOTG")
                .Do(async (e) =>
                {
                    var user = e.Server.FindUsers("hines57", false).FirstOrDefault();

                    await e.Channel.SendMessage(string.Format("{0}'s POTG!\n", user.Mention));
                    await e.Channel.SendFile("images/POTG/hinesPOTG.jpg");
                });
        }

        private void registerRngCommands()
        {
            commands.CreateCommand("Flip")
                .Do(async (e) =>
                {
                    double flip = random.NextDouble() * 2;
                    if (flip >= 1)
                        await e.Channel.SendMessage("*Heads*");
                    else
                        await e.Channel.SendMessage("*Tails*");
                });

            commands.CreateCommand("Roll")
                .Parameter("diceSize", ParameterType.Required)
                .Parameter("diceAmmount", ParameterType.Optional)
                .Do(async (e) =>
                {
                    int diceSize = Convert.ToInt16(e.GetArg("diceSize"));
                    int diceAmmount = 0;
                    if (e.GetArg("diceAmmount") != null)
                        diceAmmount = Convert.ToInt16(e.GetArg("diceAmmount"));

                    int roll = 0;

                    if (diceAmmount > 1 && diceAmmount <= 10)
                    {
                        int[] rollAmmount;
                        rollAmmount = new int[diceAmmount];

                        switch (diceSize)
                        {
                            case 4:
                                for (int i = 0; i < rollAmmount.Length; i++)
                                {
                                    rollAmmount[i] = random.Next(0, 3) + 1;
                                    await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll on dice " + (i + 1) + ": " + rollAmmount[i]);
                                }

                                break;
                            case 6:
                                for (int i = 0; i < rollAmmount.Length; i++)
                                {
                                    rollAmmount[i] = random.Next(0, 3) + 1;
                                    await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll on dice " + (i + 1) + ": " + rollAmmount[i]);
                                }
                                break;
                            case 12:
                                for (int i = 0; i < rollAmmount.Length; i++)
                                {
                                    rollAmmount[i] = random.Next(0, 3) + 1;
                                    await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll on dice " + (i + 1) + ": " + rollAmmount[i]);
                                }
                                break;
                            case 20:
                                for (int i = 0; i < rollAmmount.Length; i++)
                                {
                                    rollAmmount[i] = random.Next(0, 3) + 1;
                                    await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll on dice " + (i + 1) + ": " + rollAmmount[i]);
                                }
                                break;
                            case 24:
                                for (int i = 0; i < rollAmmount.Length; i++)
                                {
                                    rollAmmount[i] = random.Next(0, 3) + 1;
                                    await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll on dice " + (i + 1) + ": " + rollAmmount[i]);
                                }
                                break;
                            default:
                                await e.Channel.SendMessage("Your Entry was invalid! Sorry :heart:");
                                break;
                        }
                    }
                    else if (diceAmmount == 1)
                    {
                        switch (diceSize)
                        {
                            case 4:
                                roll = random.Next(0, 3) + 1;
                                await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll: " + roll);
                                break;
                            case 6:
                                roll = random.Next(0, 5) + 1;
                                await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll: " + roll);
                                break;
                            case 12:
                                roll = random.Next(0, 11) + 1;
                                await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll: " + roll);
                                break;
                            case 20:
                                roll = random.Next(0, 19) + 1;
                                await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll: " + roll);
                                break;
                            case 24:
                                roll = random.Next(0, 23) + 1;
                                await e.Channel.SendMessage("Dice Size: " + diceSize + "\nYour roll: " + roll);
                                break;
                            default:
                                await e.Channel.SendMessage("Your Entry was invalid! Sorry :heart:");
                                break;
                        }
                    }
                    else if (diceAmmount > 10)
                    {
                        await e.Channel.SendMessage("That's too many dice! Sorry :heart:");
                    }

                    //await e.Channel.SendMessage("Kevin");
                });

        }

        private void registerMemeCommands()
        {
            commands.CreateCommand("cageMe")
               .Do(async (e) =>
               {
                   int rand = random.Next(0, cageArray.Length);
                   var user = e.User;

                   switch (rand)
                   {
                       case 0:
                           await e.Channel.SendMessage(string.Format("{0} has just been caged in a Nicolas Cage cage!\n", user.Mention));
                           await e.Channel.SendFile(cageArray[0]);
                           break;
                       case 1:
                           await e.Channel.SendMessage(string.Format("{0} wants to see Nick transform into the cage!\n", user.Mention));
                           await e.Channel.SendFile(cageArray[1]);
                           break;
                       case 2:
                           await e.Channel.SendMessage(string.Format("{0} is craving a nice picolas cage!\n", user.Mention));
                           await e.Channel.SendFile(cageArray[2]);
                           break;
                       default:
                           break;
                   }

               });
        }

        private void registerDnDCommands()
        {
            commands.CreateCommand("Roll20")
                .Do(async (e) =>
                {

                    await e.Channel.SendMessage("Roll20 is our website of choice for online DnD!\nHere's a link: https://roll20.net/");
                });
        }

        //private void registerPurgeCommands()
        //{
        //    commands.CreateCommand("purge")
        //       .Do(async (e) =>
        //       {
        //           var chanName = e.Channel.Name;
        //           var user = e.User;
        //           var role = user.Roles;
        //           var monkey = e.Channel.FindUsers("vurtua7", false).FirstOrDefault();

        //           if (role.Any(input => input.Name.ToUpper() == "CODE MONKEY") ||
        //               role.Any(input => input.Name.ToUpper() == "ADMIN"))
        //           {
        //               await e.User.SendMessage(string.Format("deleting the last 100 of {0}'s messages.", chanName));
        //               await monkey.SendMessage(string.Format("{0} purged {1}s messages", user.Name, chanName));
        //               Message[] messagesToDelete;

        //               messagesToDelete = await e.Channel.DownloadMessages(100);
        //               await e.Channel.DeleteMessages(messagesToDelete);
        //           }
        //           else
        //           {
        //               await monkey.SendMessage(string.Format("{0} tried to purge {1}, but isn't an admin.", user.Name, chanName));
        //               await e.User.SendMessage("you do not have permission to purge " + chanName + ". Please contact admin.");
        //           }
        //       });
        //}
    }

}
