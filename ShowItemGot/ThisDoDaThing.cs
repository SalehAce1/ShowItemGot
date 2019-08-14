using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker.Actions;
using Logger = Modding.Logger;
using UnityEngine.SceneManagement;
using UObject = UnityEngine.Object;
using ModCommon.Util;
using ModCommon;
using USceneManager = UnityEngine.SceneManagement.SceneManager;
using System.IO;
using System;

namespace ShowItemGot
{
    internal class ThisDoDaThing : MonoBehaviour
    {
        private const int CHARM_NUM = 1;

        private void Start()
        {
            StartCoroutine(Testing());
        }

        IEnumerator Testing()
        {
            yield return new WaitWhile(() => HeroController.instance == null);
            yield return new WaitForSeconds(10f); //For testing purposes
            /*
            If you want to stop the player from moving.
            HeroController.instance.RelinquishControl();
            HeroController.instance.StopAnimationControl();*/
            var fsm = ShowItemGot.preloadedGO["item"].LocateMyFSM("Shiny Control");
            yield return null;
            fsm.GetAction<SetFsmInt>("Normal Msg", 1).setValue.Value = CHARM_NUM;
            yield return null;
            fsm.enabled = true;
            fsm.SetState("Normal Msg");
            PlayerData.instance.gotCharm_1 = true;
            /*
            Gives Control back.
            HeroController.instance.StartAnimationControl();
            HeroController.instance.RegainControl();*/
        }

        private void Log(object o)
        {
            Logger.Log("[Show] " + o);
        }
    }
}
