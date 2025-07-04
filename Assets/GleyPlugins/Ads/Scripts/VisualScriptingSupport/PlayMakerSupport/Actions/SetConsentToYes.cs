#if USE_PLAYMAKER_SUPPORT
namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Set consent to yes (use personalized ads)")]
    public class SetConsentToYes : FsmStateAction
    {
        public override void OnEnter()
        {
            Advertisements.Instance.SetUserConsent(true);
            Finish();
        }
    }
}
#endif
