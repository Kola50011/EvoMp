using System.Linq;
using DSharpPlus.Entities;
using EvoMp.Module.DiscordHandler.Entity;
using EvoMp.Module.DiscordHandler.Server.Entity;

namespace EvoMp.Module.DiscordHandler.Server
{
    public class ServerMemberManagment
    {
        private static readonly DiscordRepository DiscordRepository = DiscordRepository.GetInstance();

        public static DiscordServerMember GetServerMember(DiscordUser discordUser)
        {
            DiscordServerMember returnMember;
            using (DiscordContext discordContext = DiscordRepository.GetDiscordContext())
            {
                // Channel search
                returnMember = discordContext.DiscordServerMembers.FirstOrDefault(member =>
                    member.DiscordId == discordUser.Id);

                // Can't found the channel in Database -> create
                if (returnMember == null)
                {
                    returnMember = discordContext.DiscordServerMembers.Add(new DiscordServerMember
                    {
                        DiscordId = discordUser.Id,
                        Username = discordUser.Username,
                        Nickalert = discordUser.Mention
                    });
                    discordContext.SaveChanges();
                }
            }
            return returnMember;
        }
    }
}