using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace HarderBannerlord.Settings
{
    public class ModSettings : AttributeGlobalSettings<ModSettings>
    {
        public override string Id => "HarderBannerlordSettings_v1";
        public override string DisplayName => "Harder Bannerlord";
        public override string FolderName => "HarderBannerlord";
        public override string FormatType => "json";

        // ==================== GENERAL ====================

        [SettingPropertyBool("Enable Mod", Order = 0, RequireRestart = false,
            HintText = "Master on/off switch for all features in this mod.")]
        [SettingPropertyGroup("General")]
        public bool ModEnabled { get; set; } = true;

        // ==================== AI LORD GOLD ====================

        [SettingPropertyBool("Enable Daily Gold Bonus", Order = 0, RequireRestart = false,
            HintText = "If enabled, AI lords receive daily gold based on the size of their party. The player is never affected.")]
        [SettingPropertyGroup("AI Lord Gold")]
        public bool EnableLordGold { get; set; } = true;

        [SettingPropertyInteger("Gold Per Troop Per Day", 0, 10000, "0", Order = 1, RequireRestart = false,
            HintText = "Each AI lord receives this much gold, multiplied by the number of troops in their party, every day. Set to 0 to disable the effect while keeping the toggle on. Does not apply to the player.")]
        [SettingPropertyGroup("AI Lord Gold")]
        public int GoldPerTroopPerDay { get; set; } = 5;

        // ==================== AI LORD SKILLS ====================

        [SettingPropertyBool("Enable Daily Skill Growth", Order = 0, RequireRestart = false,
            HintText = "If enabled, AI lords gain bonus skill XP every day. The player is never affected.")]
        [SettingPropertyGroup("AI Lord Skills")]
        public bool EnableLordSkills { get; set; } = true;

        [SettingPropertyFloatingInteger("Base Skill XP Per Day", 0f, 1000f, "0", Order = 1, RequireRestart = false,
            HintText = "The base amount of XP granted per skill per day, before each skill's individual multiplier below is applied. A multiplier of 1.0x on a skill with this base value approximates a mild passive growth rate; 0x disables growth for that skill entirely.")]
        [SettingPropertyGroup("AI Lord Skills")]
        public float BaseSkillXpPerDay { get; set; } = 50f;

        [SettingPropertyFloatingInteger("One Handed", 0f, 20f, "0.0", Order = 2, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float OneHandedMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Two Handed", 0f, 20f, "0.0", Order = 3, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float TwoHandedMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Polearm", 0f, 20f, "0.0", Order = 4, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float PolearmMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Bow", 0f, 20f, "0.0", Order = 5, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float BowMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Crossbow", 0f, 20f, "0.0", Order = 6, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float CrossbowMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Throwing", 0f, 20f, "0.0", Order = 7, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float ThrowingMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Riding", 0f, 20f, "0.0", Order = 8, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float RidingMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Athletics", 0f, 20f, "0.0", Order = 9, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float AthleticsMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Smithing", 0f, 20f, "0.0", Order = 10, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float SmithingMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Scouting", 0f, 20f, "0.0", Order = 11, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float ScoutingMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Tactics", 0f, 20f, "0.0", Order = 12, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float TacticsMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Roguery", 0f, 20f, "0.0", Order = 13, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float RogueryMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Charm", 0f, 20f, "0.0", Order = 14, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float CharmMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Leadership", 0f, 20f, "0.0", Order = 15, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float LeadershipMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Trade", 0f, 20f, "0.0", Order = 16, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float TradeMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Steward", 0f, 20f, "0.0", Order = 17, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float StewardMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Medicine", 0f, 20f, "0.0", Order = 18, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float MedicineMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Engineering", 0f, 20f, "0.0", Order = 19, RequireRestart = false)]
        [SettingPropertyGroup("AI Lord Skills")]
        public float EngineeringMultiplier { get; set; } = 1f;

        // ==================== AI LORD RECRUITS ====================

        [SettingPropertyBool("Enable Daily Culture Recruits", Order = 0, RequireRestart = false,
            HintText = "If enabled, AI lords automatically receive troops of their own culture's basic recruit type every day, as long as their party is below the size threshold below. The player is never affected.")]
        [SettingPropertyGroup("AI Lord Recruits")]
        public bool EnableLordRecruits { get; set; } = true;

        [SettingPropertyInteger("Recruits Per Day", 0, 100, "0", Order = 1, RequireRestart = false,
            HintText = "How many basic troops of their own culture each eligible AI lord receives per day.")]
        [SettingPropertyGroup("AI Lord Recruits")]
        public int RecruitsPerDay { get; set; } = 5;

        [SettingPropertyInteger("Party Size Threshold (%)", 1, 100, "0", Order = 2, RequireRestart = false,
            HintText = "AI lords only receive free recruits while their party is below this percentage of its maximum troop capacity. For example, 75 means a lord stops receiving free recruits once their party is at 75% of max size.")]
        [SettingPropertyGroup("AI Lord Recruits")]
        public int RecruitThresholdPercent { get; set; } = 75;

        // ==================== AI LORD TROOP XP ====================

        [SettingPropertyBool("Enable Daily Troop XP", Order = 0, RequireRestart = false,
            HintText = "If enabled, all troops in an AI lord's party gain bonus XP every day, helping lords upgrade the recruits they receive from this mod faster. The player's party is never affected.")]
        [SettingPropertyGroup("AI Lord Troop XP")]
        public bool EnableLordTroopXp { get; set; } = true;

        [SettingPropertyInteger("Troop XP Per Day", 0, 50000, "0", Order = 1, RequireRestart = false,
            HintText = "The amount of XP granted to each troop type in an AI lord's party, every day. Higher values let lords upgrade their troops into higher tiers faster.")]
        [SettingPropertyGroup("AI Lord Troop XP")]
        public int TroopXpPerDay { get; set; } = 5000;

        // ==================== AI LORD GRAIN ====================

        [SettingPropertyBool("Enable Daily Grain For Lords", Order = 0, RequireRestart = false,
            HintText = "If enabled, AI lords receive grain directly into their party's inventory every day, helping sustain their army on campaign. The player is never affected.")]
        [SettingPropertyGroup("AI Lord Grain")]
        public bool EnableLordGrain { get; set; } = true;

        [SettingPropertyFloatingInteger("Grain Per Troop Per Day", 1f, 20f, "0.0", Order = 1, RequireRestart = false,
            HintText = "The amount of grain added to each AI lord's party inventory every day, multiplied by the number of troops in their party. For example, a value of 5 gives a 100-troop party 500 grain per day.")]
        [SettingPropertyGroup("AI Lord Grain")]
        public float GrainPerTroopPerDay { get; set; } = 5f;

        // ==================== AI LORD PARTY SIZE ====================

        [SettingPropertyBool("Enable Party Size Scaling", Order = 0, RequireRestart = false,
            HintText = "If enabled, scales the base party size limit (max troops) for all AI lords and ladies. The player's party size is never affected.")]
        [SettingPropertyGroup("AI Lord Party Size")]
        public bool EnablePartySizeScaling { get; set; } = true;

        [SettingPropertyInteger("Party Size Scale (%)", 50, 250, "0", Order = 1, RequireRestart = false,
            HintText = "Scales AI lords' base party size limit. 100% makes no change. Below 100% shrinks max party sizes, above 100% grows them. For example, 150% means an AI lord who could normally lead 100 troops can now lead 150.")]
        [SettingPropertyGroup("AI Lord Party Size")]
        public int PartySizeScalePercent { get; set; } = 100;

        // ==================== SETTLEMENT FOOD ====================

        [SettingPropertyBool("Enable Daily Settlement Food", Order = 0, RequireRestart = false,
            HintText = "If enabled, every town and castle (including the player's) gains bonus food stocks and grain every day.")]
        [SettingPropertyGroup("Settlement Food")]
        public bool EnableSettlementFood { get; set; } = true;

        [SettingPropertyInteger("Food Stocks Per Day", 0, 500, "0", Order = 1, RequireRestart = false,
            HintText = "The amount added to a settlement's food stock value every day, capped at that settlement's maximum food stock capacity.")]
        [SettingPropertyGroup("Settlement Food")]
        public int FoodStocksPerDay { get; set; } = 20;

        [SettingPropertyInteger("Grain Per Day", 0, 500, "0", Order = 2, RequireRestart = false,
            HintText = "The amount of grain added to a settlement's market stores every day.")]
        [SettingPropertyGroup("Settlement Food")]
        public int GrainPerDay { get; set; } = 10;
    }
}
