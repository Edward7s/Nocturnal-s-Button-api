using System;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal class NButton
    {
        private GameObject s_buttonGameObj { get; set; }
        private Button s_buttonComp { get; set; }
        private GameObject s_imageGameObj { get; set; }
        private GameObject s_textGameobj { get; set; }
        private float s_yValue { get; set; }
        ~NButton()
        {
            this.s_buttonGameObj = null;
            this.s_buttonComp = null;
            this.s_textGameobj = null;
            this.s_imageGameObj = null;
        }
      
        public NButton(out GameObject instance, GameObject path, string name, Action action, bool half = false, string img = null, float X = 628, float Y = 628)
        {
            s_yValue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;
            s_buttonGameObj = GameObject.Instantiate(Misc.s_buttonPrefab, path.transform);
            s_buttonGameObj.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
            s_buttonGameObj.name = "_Button_" + name;
            s_buttonComp = s_buttonGameObj.gameObject.GetComponent<Button>();
            s_buttonComp.onClick.RemoveAllListeners();
            s_buttonComp.onClick.AddListener(action);
            s_buttonGameObj.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = name;
            if (X != 628 && Y != 628)
                s_buttonGameObj.transform.localPosition = new Vector3(-350 + X * 240, s_yValue);
            if (img != null)
            {
                s_imageGameObj = s_buttonGameObj.transform.Find("Icon").gameObject;
                Component.DestroyImmediate(s_imageGameObj.GetComponent<VRC.UI.Core.Styles.StyleElement>());
                s_imageGameObj.Loadfrombytes(img);
                s_imageGameObj.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }
            instance = s_buttonGameObj;
            if (!half)
                return;
            s_buttonGameObj.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            s_imageGameObj = s_buttonGameObj.transform.Find("Icon").gameObject;
            s_imageGameObj.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            s_imageGameObj.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
            s_textGameobj = s_buttonGameObj.transform.Find("Text_H4").gameObject;
            s_textGameobj.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            s_textGameobj.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);
        }
        public NButton(GameObject path, string name, Action action, bool half = false, string img = null, float X = 628, float Y = 628)
        {
            s_yValue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;
            s_buttonGameObj = GameObject.Instantiate(Misc.s_buttonPrefab, path.transform);
            s_buttonGameObj.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
            s_buttonGameObj.name = "_Button_" + name;
            s_buttonComp = s_buttonGameObj.GetComponent<Button>();
            s_buttonComp.onClick.RemoveAllListeners();
            s_buttonComp.onClick.AddListener(action);
            s_buttonGameObj.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = name;
            if (X != 628 && Y != 628)
                s_buttonGameObj.transform.localPosition = new Vector3(-350 + X * 240, s_yValue);
            if (img != null)
            {
                s_imageGameObj = s_buttonGameObj.transform.Find("Icon").gameObject;
                s_imageGameObj.GetComponent<VRC.UI.Core.Styles.StyleElement>();
                s_imageGameObj.Loadfrombytes(img);
                s_imageGameObj.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }
            if (!half)
                return;
            s_buttonGameObj.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            s_imageGameObj = s_buttonGameObj.transform.Find("Icon").gameObject;
            s_imageGameObj.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            s_imageGameObj.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
            s_textGameobj = s_buttonGameObj.transform.Find("Text_H4").gameObject;
            s_textGameobj.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            s_textGameobj.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);

        }
       
          
        
    }



}
