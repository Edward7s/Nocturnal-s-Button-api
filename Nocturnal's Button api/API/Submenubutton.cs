using System;
using UnityEngine;

using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal class Submenubutton
    {
        private GameObject sss_buttonGameObject { get; set; }
        private Button sss_buttonComponent { get; set; }
        private GameObject ss_buttonIcon { get; set; }
        private GameObject s_text { get; set; }
        private float? s_yValue { get; set; }

        ~Submenubutton()
        {
            this.sss_buttonGameObject = null;
            this.sss_buttonComponent = null;
            this.ss_buttonIcon = null;
            this.s_text = null;
            this.s_yValue = null;
        }
        public Submenubutton(GameObject menu, string text, GameObject menutoopen, byte[] img = null, bool half = false, float X = 628, float Y = 628)
        {
            s_yValue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;
            sss_buttonGameObject = GameObject.Instantiate(Misc.s_buttonPrefab, menu.transform).gameObject;
            Component.DestroyImmediate(sss_buttonGameObject.transform.Find("Icon").gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            sss_buttonGameObject.name = $"SubBtn_{text}";
            sss_buttonGameObject.transform.localEulerAngles = Vector3.zero;
            sss_buttonComponent = sss_buttonGameObject.GetComponent<Button>();
            sss_buttonComponent.onClick.RemoveAllListeners();
            sss_buttonComponent.onClick.AddListener(new Action(() =>
            {
                menu.transform.parent.parent.parent.parent.gameObject.SetActive(false);
                menutoopen.gameObject.SetActive(true);
            }
            ));
            sss_buttonGameObject.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            sss_buttonGameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            if (img != null)
            {
                sss_buttonGameObject.transform.Find("Icon").gameObject.Loadfrombytes(img);
                sss_buttonGameObject.transform.Find("Icon").gameObject.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }
            if (X != 628 && Y != 628)
                sss_buttonGameObject.transform.localPosition = new Vector3(-350 + X * 240, (float)s_yValue);   
            if (!half)
                return;
            sss_buttonGameObject.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            ss_buttonIcon = sss_buttonGameObject.transform.Find("Icon").gameObject;
            ss_buttonIcon.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            ss_buttonIcon.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
            s_text = sss_buttonGameObject.transform.Find("Text_H4").gameObject;
            s_text.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            s_text.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);
        }
        
       
    }
}
