﻿#if USE_PLAYMAKER_SUPPORT
namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Displays a banner")]
    public class HideBanner : FsmStateAction
    {
        public override void OnEnter()
        {
            Advertisements.Instance.HideBanner();
            Finish();
        }
    }
}
#endif
