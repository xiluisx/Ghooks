using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.Events
{
    public class OnDeath : IScript
    {
        [Target(GameSourceEvent.PlayerDeath, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, ShPlayer attacker)
        {
            if(!attacker || !attacker.isHuman || attacker==player)
            {
                return;
            }
            Core.Instance.DeathWebhook.Send(string.Format(Core.Instance.Settings.General.DeathLogFormat, player.username, attacker.username), player.username, 
                embeds: Core.Instance.Settings.General.DeathUseEmbed? EmbedCrafter.CreateAllEmbeds(Core.Instance.Settings.General.DeathEmbed,player) :null);
        }
    }
}
