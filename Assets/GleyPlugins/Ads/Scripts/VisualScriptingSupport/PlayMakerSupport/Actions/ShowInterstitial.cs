#if USE_PLAYMAKER_SUPPORT
namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Displays an interstitial")]
    public class ShowInterstitial : FsmStateAction
    {
        public override void OnEnter()
        {
            Advertisements.Instance.ShowInterstitial();
            Finish();
        }
    }
}
#endif
