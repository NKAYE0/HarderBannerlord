using HarderBannerlord.Settings;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace HarderBannerlord.GameModels
{
    /// <summary>
    /// Extends the base game's party size limit model to scale the maximum
    /// troop count AI lords/ladies can lead, based on the mod's MCM setting.
    /// The player's own party size limit is always left untouched.
    /// </summary>
    public class HarderBannerlordPartySizeLimitModel : DefaultPartySizeLimitModel
    {
        public override ExplainedNumber GetPartyMemberSizeLimit(PartyBase party, bool includeDescriptions = false)
        {
            ExplainedNumber result = base.GetPartyMemberSizeLimit(party, includeDescriptions);

            ModSettings settings = ModSettings.Instance;
            if (settings == null || !settings.ModEnabled || !settings.EnablePartySizeScaling)
            {
                return result;
            }

            // Only affects genuine mobile parties led by a hero (skips garrisons, patrols, etc.,
            // which are already handled separately by the base game before reaching this point).
            if (!party.IsMobile || party.MobileParty == null)
            {
                return result;
            }

            Hero leaderHero = party.MobileParty.LeaderHero;

            // Never affect the player's own party.
            if (leaderHero == null || leaderHero == Hero.MainHero)
            {
                return result;
            }

            if (settings.PartySizeScalePercent != 100)
            {
                float factor = settings.PartySizeScalePercent / 100f - 1f;
                result.AddFactor(factor);
            }

            return result;
        }
    }
}
