using HarderBannerlord.Settings;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace HarderBannerlord.Behaviors
{
    /// <summary>
    /// Runs once per hero per day and applies the mod's difficulty effects
    /// (gold, skill XP, and recruits) to AI-controlled lords only.
    /// The player and player's companions/clan are never touched.
    /// </summary>
    public class DailyDifficultyBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.DailyTickHeroEvent.AddNonSerializedListener(this, OnDailyTickHero);
        }

        public override void SyncData(IDataStore dataStore)
        {
            // No persistent state needed - settings are stored by MCM,
            // and effects are re-applied fresh each day.
        }

        private void OnDailyTickHero(Hero hero)
        {
            ModSettings settings = ModSettings.Instance;
            if (settings == null || !settings.ModEnabled)
            {
                return;
            }

            if (!IsEligibleAiLord(hero))
            {
                return;
            }

            MobileParty party = hero.PartyBelongedTo;
            int troopCount = party?.MemberRoster?.TotalManCount ?? 0;

            if (settings.EnableLordGold)
            {
                ApplyDailyGold(hero, troopCount, settings);
            }

            if (settings.EnableLordSkills)
            {
                ApplyDailySkillGains(hero, settings);
            }

            if (settings.EnableLordRecruits && party != null)
            {
                ApplyDailyRecruits(hero, party, settings);
            }

            if (settings.EnableLordTroopXp && party != null)
            {
                ApplyDailyTroopXp(party, settings);
            }
        }

        /// <summary>
        /// Only apply effects to AI lords who actively lead their own party.
        /// Explicitly excludes the player and the player's clan.
        /// </summary>
        private bool IsEligibleAiLord(Hero hero)
        {
            if (hero == null || hero.IsDead || hero.IsDisabled)
            {
                return false;
            }

            if (hero == Hero.MainHero)
            {
                return false;
            }

            if (hero.Clan == null || hero.Clan == Clan.PlayerClan)
            {
                return false;
            }

            MobileParty party = hero.PartyBelongedTo;
            if (party == null || party.IsDisbanding)
            {
                return false;
            }

            // Only the party leader accrues these bonuses, not every hero riding along.
            if (party.LeaderHero != hero)
            {
                return false;
            }

            // Restrict to actual lord parties (excludes caravans, villagers, bandits, etc.)
            if (!party.IsLordParty)
            {
                return false;
            }

            return true;
        }

        private void ApplyDailyGold(Hero hero, int troopCount, ModSettings settings)
        {
            if (troopCount <= 0 || settings.GoldPerTroopPerDay <= 0)
            {
                return;
            }

            int goldAmount = troopCount * settings.GoldPerTroopPerDay;
            GiveGoldAction.ApplyBetweenCharacters(null, hero, goldAmount, true);
        }

        private void ApplyDailySkillGains(Hero hero, ModSettings settings)
        {
            float baseXp = settings.BaseSkillXpPerDay;
            if (baseXp <= 0f)
            {
                return;
            }

            AddSkillXp(hero, DefaultSkills.OneHanded, baseXp * settings.OneHandedMultiplier);
            AddSkillXp(hero, DefaultSkills.TwoHanded, baseXp * settings.TwoHandedMultiplier);
            AddSkillXp(hero, DefaultSkills.Polearm, baseXp * settings.PolearmMultiplier);
            AddSkillXp(hero, DefaultSkills.Bow, baseXp * settings.BowMultiplier);
            AddSkillXp(hero, DefaultSkills.Crossbow, baseXp * settings.CrossbowMultiplier);
            AddSkillXp(hero, DefaultSkills.Throwing, baseXp * settings.ThrowingMultiplier);
            AddSkillXp(hero, DefaultSkills.Riding, baseXp * settings.RidingMultiplier);
            AddSkillXp(hero, DefaultSkills.Athletics, baseXp * settings.AthleticsMultiplier);
            AddSkillXp(hero, DefaultSkills.Crafting, baseXp * settings.SmithingMultiplier);
            AddSkillXp(hero, DefaultSkills.Scouting, baseXp * settings.ScoutingMultiplier);
            AddSkillXp(hero, DefaultSkills.Tactics, baseXp * settings.TacticsMultiplier);
            AddSkillXp(hero, DefaultSkills.Roguery, baseXp * settings.RogueryMultiplier);
            AddSkillXp(hero, DefaultSkills.Charm, baseXp * settings.CharmMultiplier);
            AddSkillXp(hero, DefaultSkills.Leadership, baseXp * settings.LeadershipMultiplier);
            AddSkillXp(hero, DefaultSkills.Trade, baseXp * settings.TradeMultiplier);
            AddSkillXp(hero, DefaultSkills.Steward, baseXp * settings.StewardMultiplier);
            AddSkillXp(hero, DefaultSkills.Medicine, baseXp * settings.MedicineMultiplier);
            AddSkillXp(hero, DefaultSkills.Engineering, baseXp * settings.EngineeringMultiplier);
        }

        private void AddSkillXp(Hero hero, SkillObject skill, float amount)
        {
            if (amount <= 0f || hero.HeroDeveloper == null)
            {
                return;
            }

            hero.HeroDeveloper.AddSkillXp(skill, amount, false, true);
        }

        private void ApplyDailyRecruits(Hero hero, MobileParty party, ModSettings settings)
        {
            if (settings.RecruitsPerDay <= 0)
            {
                return;
            }

            int maxCapacity = party.Party.PartySizeLimit;
            if (maxCapacity <= 0)
            {
                return;
            }

            int currentCount = party.MemberRoster.TotalManCount;
            float thresholdRatio = settings.RecruitThresholdPercent / 100f;

            if (currentCount >= maxCapacity * thresholdRatio)
            {
                return;
            }

            CultureObject culture = hero.Culture;
            CharacterObject basicTroop = culture?.BasicTroop;
            if (basicTroop == null)
            {
                return;
            }

            // Don't overshoot capacity by more than the configured batch size.
            int spaceLeft = maxCapacity - currentCount;
            int amountToAdd = System.Math.Min(settings.RecruitsPerDay, System.Math.Max(spaceLeft, 0));
            if (amountToAdd <= 0)
            {
                return;
            }

            party.MemberRoster.AddToCounts(basicTroop, amountToAdd);
        }

        private void ApplyDailyTroopXp(MobileParty party, ModSettings settings)
        {
            if (settings.TroopXpPerDay <= 0 || party.MemberRoster == null)
            {
                return;
            }

            TroopRoster roster = party.MemberRoster;
            for (int i = 0; i < roster.Count; i++)
            {
                TroopRosterElement element = roster.GetElementCopyAtIndex(i);
                CharacterObject troop = element.Character;

                // Skip hero characters riding in the party - only regular troops gain XP here.
                if (troop == null || troop.IsHero)
                {
                    continue;
                }

                roster.AddXpToTroop(troop, settings.TroopXpPerDay);
            }
        }
    }
}
