#if USE_PLAYMAKER_SUPPORT
namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Disable Banner and interstitial ads")]
    public class RemoveAds : FsmStateAction
    {
        public override void OnEnter()
        {
            Advertisements.Instance.RemoveAds(true);
            Finish();
        }
    }
}
#endif
