using System;
using UnityEngine;
using UnityEngine.UI;

namespace Nocturnal.Apis.qm
{
    internal class SmallButton
    {
        private GameObject sss_buttonGameObject { get; set; }
        private Button sss_buttonComponent { get; set; }
        private Transform ss_buttonIcon { get; set; }
        ~SmallButton()
        {
            this.sss_buttonGameObject = null;
            this.sss_buttonComponent = null;
            this.ss_buttonIcon = null;
        }
        public SmallButton(out GameObject instance,GameObject path, Action action, string img = null)
        {
            sss_buttonGameObject = GameObject.Instantiate(Misc.s_buttonPrefab, path.transform);
            sss_buttonGameObject.transform.Find("Text_H4").gameObject.SetActive(false);
            sss_buttonGameObject.name = "_Button_Small";
            sss_buttonComponent = sss_buttonGameObject.gameObject.GetComponent<UnityEngine.UI.Button>();
            sss_buttonComponent.onClick.RemoveAllListeners();
            sss_buttonComponent.onClick.AddListener(action);
            sss_buttonGameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().enabled = false;
            sss_buttonGameObject.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(-98, -76);
            ss_buttonIcon = sss_buttonGameObject.transform.Find("Icon");
            ss_buttonIcon.localScale = new Vector3(0.9f, 0.9f, 1);
            ss_buttonIcon.localPosition = new Vector3(0, 35, 0);
            instance = sss_buttonGameObject;
            if (img == null) return;
            Component.DestroyImmediate(sss_buttonGameObject.transform.Find("Icon").GetComponent<VRC.UI.Core.Styles.StyleElement>());
            ss_buttonIcon.gameObject.Loadfrombytes(img);
            ss_buttonIcon.gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
        }


    }
}
