#if USE_PLAYMAKER_SUPPORT
namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Set consent to no (use random ads)")]
    public class SetConsentToNo : FsmStateAction
    {
        public override void OnEnter()
        {
            Advertisements.Instance.SetUserConsent(false);
            Finish();
        }
    }
}
#endif
