using System.Collections;
using MelonLoader;
using UnityEngine;

namespace Nocturnal.Apis.qm.Example
{
    internal class Create : MelonMod
    {
        public override void OnApplicationStart()
        {
            //First thing we can do its download the images and save them into the memory.
            new Download_Images();

            //Going to start a IEnumerator to wait for the ui, there is no point for a patch or anything like that.
            MelonCoroutines.Start(WaitForUi());
        }

        private static IEnumerator WaitForUi()
        {
            /*We want to wait till it finds an object with the componenet: VRC.UI.Elements.MenuStateController.
            After that we can look for the objects that we want to instanciate and then we can start creating the ui.
             Misc.GetPrefabs() is getting all the objects we need to create our own menu.*/

            while (GameObject.FindObjectOfType<VRC.UI.Elements.MenuStateController>() == null)
                yield return new WaitForEndOfFrame();
            MelonLogger.Msg("Generating Menu");

            Misc.GetPrefabs();
            Apis.qm.API.XRefs.SetMethods();
            //After we got the Objects we can create the buttons.
            new GenerateButtons();
            yield break;
        }

    }
}
