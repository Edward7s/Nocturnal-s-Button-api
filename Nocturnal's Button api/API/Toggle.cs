using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using MelonLoader;

namespace Nocturnal.Apis.qm
{
    internal class NToggle
    {
        private GameObject s_toggleGameobject { get; set; }
        private Toggle s_toggleComponent { get; set; }
        private Transform s_iconOn { get; set; }
        private Transform s_iconOff { get; set; }
        private TMPro.TextMeshProUGUI s_text { get; set; }
        private float? s_yValue { get; set; }

        ~NToggle()
        {
            this.s_toggleGameobject = null;
            this.s_text = null;
            this.s_yValue = null;
            this.s_text = null;
        }
        public NToggle(string text, GameObject menu, Action vtrue, Action vfalse, bool prevalue = false, bool half = false, float X = 628, float Y = 628)
        {
            s_yValue = half ? -329 - (Y * (200 / 2) - 45) : -140 - Y * 188;
            s_toggleGameobject = GameObject.Instantiate(Misc.s_togglePrebab, menu.transform).gameObject;
            Component.DestroyImmediate(s_toggleGameobject.GetComponent<VRC.DataModel.Core.BindingComponent>());
            s_toggleGameobject.name = $"Toggle_{text}";
            s_toggleComponent = s_toggleGameobject.GetComponent<Toggle>();
            s_toggleComponent.onValueChanged.RemoveAllListeners();
            s_toggleComponent.onValueChanged.AddListener((UnityEngine.Events.UnityAction<bool>)Gettoggle);
            s_iconOff = s_toggleGameobject.transform.Find("Icon_Off");
            s_iconOn = s_toggleGameobject.transform.Find("Icon_On");
            s_text = s_toggleGameobject.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            s_text.text = text;
            var tooltip = s_toggleGameobject.GetComponent<VRC.UI.Elements.Tooltips.UiToggleTooltip>();
            tooltip.field_Public_String_0 = "Toggle Off " + text;
            tooltip.field_Public_String_1 = "Toggle On " + text;
            Component.Destroy(s_iconOff.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            Component.Destroy(s_iconOn.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            if (prevalue)
            {
                s_toggleComponent.isOn = true;
                s_iconOff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                s_iconOn.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
            }
            else
            {
                s_toggleComponent.isOn = false;
                s_iconOff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                s_iconOn.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
            }
            void Gettoggle(bool value)
            {
           
                if (value)
                {
                    s_iconOn.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                    s_iconOff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);

                    vtrue.Invoke();
                }
                else
                {
                    s_iconOn.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                    s_iconOff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                    vfalse.Invoke();

                }

            }
            if (X != 628 && Y != 628)
                s_toggleGameobject.transform.localPosition = new Vector3(-350 + X * 240,(float)s_yValue);
            
            if (!half)
                return;
            s_toggleGameobject.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            s_iconOff.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            s_iconOff.transform.localPosition = new Vector3(-77, -0.7f, 0);
            s_iconOn.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            s_iconOn.transform.localPosition = new Vector3(-77, 35f, 0);
            s_text.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            s_text.transform.localPosition = new Vector3(20.7601f, -20.4598f, 0);
        }
       
    }
}
