using System;
using System.Collections.Generic;
using System.Linq;
using Discord.Commands;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class RegisterHelpCommands
    {
        CommandService commands;
        public RegisterHelpCommands(CommandService commands)
        {
            this.commands = commands;
            registerHelpCommands();
        }

        public CommandService getCommands()
        {
            return commands;
        }

        private void registerHelpCommands()
        {
            commands.CreateCommand("listcommands")
                .Do(async (e) =>
                {
                    var user = e.User;
                    await e.Channel.SendMessage(string.Format("{0}, the list has been sent to you in a private message!", user.Mention));
                    await user.SendMessage(
                    "\nHere's a list of all the commands Lobby-Boy can do!\n"
                    + "```HTML\n"
                    + "<Basic Text Commands>"
                    + "```"
                    + "```css\n"
                    + ">!Hello - Says hi back!\n"
                    + ">!youPassButter - He has an existential crisis!\n"
                    + ">!cashMeOutside - How bout that?\n"
                    + ">!smooth - Posts a random pic when you're feelin smooth af!\n"
                    + ">!finnaBeLit - For those times when it's gunna finna be lit!\n"
                    + ">!freshMaker - For when you're looking for those mentos, so you can punch a bitch in the face!\n"
                    + ">!sendnudz - for when you want people to send nudz!\n"
                    + ">!waitAMinute - For when you need to take a minute!\n"
                    + ">!FUCKYOU - When you want to be rude as hell to LB\n"
                    + ">!FUCKYOUMOM - For when you really want to be an edgy teen!\n"
                    + ">!overCats - For when you need Overwatch, but like, as cats!\n"
                    + ">!capCanada - Brings forth Captain Canada!\n"
                    + ">!sodaNotPop - So us 'MURICAN'S can correct our 'friends' up north!\n"
                    + ">!showMeHasselHoff - The Hassel Hoff Comes!\n"
                    + ">!swanson - When you need some swanson in your life!\n"
                    + ">!cageMe - Gives you a random instance of the Cage!\n"
                    + ">!litNights - *WARNING* - only use when latenights got that dank shit!\n"
                    + "```\n");
                    await user.SendMessage(
                        "\n"
                        + "```HTML\n"
                        + "<Target Commands>"
                        + "```\n"
                        + "```css\n"
                        + ">!sendnudz <Target> - For when you NEED someone to send nudz!\n"
                        + ">!waitAMinute <Target> - For when you need someone else to take a minute!\n"
                        + ">!buttTouch <Target> - For when you wanna touch some buttz!\n"
                        + "```\n"
                        );
                    await user.SendMessage(
                        "\n"
                        + "```HTML\n"
                        + "<RNG Commands>"
                        + "```\n"
                        + "```css\n"
                        + ">!Flip - Flips a coin and gives you the outcome!\n"
                        + ">!Roll <dieType> <ammountOfDice> - Rolles die up to D24 and as many as 10 and shows you the results of each!\n"
                        + "```\n"
                        );
                    await user.SendMessage(
                        "\n"
                        + "```HTML\n"
                        + "<POTG Commands>"
                        + "```\n"
                        + "```css\n"
                        + ">!vurtua7POTG - A pic to commemorate a Vurtua7 POTG!\n"
                        + ">!lateNightsPOTG - A pic to commemorate a LateNights POTG!\n"
                        + ">!barbPOTG - A pic to commemorate a ModernBarbarian POTG!\n"
                        + ">!hinesPOTG - A pic to commemorate a Hines57 POTG!\n"
                        + "```\n"
                        );
                    await user.SendMessage(
                    "\n"
                    + "```HTML\n"
                    + "<Summon Commands>"
                    + "```\n"
                    + "```css\n"
                    + ">!Oversquad - Sends a message to all members of the OverSquad!\n"
                    + ">!Starvesquad - Sends a message to all memeber of the StarveSquad!\n"
                    + ">!NeedHealing - Notifies your local Kayzee that you need healing, you pleb.\n"
                    + ">!SummonCodemonkey - Summons the local code monkies to the channel!\n"
                    + ">!SummonGod - Summons the almighty one, Chrispy!"
                    + "```"
                    );
                });
        }
    }
}
