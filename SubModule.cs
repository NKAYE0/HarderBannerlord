using HarderBannerlord.Behaviors;
using HarderBannerlord.GameModels;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace HarderBannerlord
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            // MCM settings register themselves automatically via AttributeGlobalSettings
            // as long as the MCM module is loaded before this one (see SubModule.xml).
        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (game.GameType is Campaign)
            {
                CampaignGameStarter campaignStarter = (CampaignGameStarter)gameStarterObject;
                campaignStarter.AddBehavior(new DailyDifficultyBehavior());
                campaignStarter.AddModel(new HarderBannerlordPartySizeLimitModel());
            }
        }
    }
}
