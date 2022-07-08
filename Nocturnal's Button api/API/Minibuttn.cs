using System;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal  class MiniButtn
    {
        private GameObject ss_buttonGameObject { get; set; }
        private Button ss_buttonComponent { get; set; }
        private GameObject s_buttonIcon { get; set; }

        ~MiniButtn()
        {
            this.ss_buttonGameObject = null;
            this.ss_buttonComponent = null;
            this.s_buttonIcon = null;
        }
        public MiniButtn(GameObject path, string text, Action action, byte[] icon)
        {
            ss_buttonGameObject = GameObject.Instantiate(Misc.s_qmExpand, path.transform);
            ss_buttonComponent = ss_buttonGameObject.gameObject.GetComponent<Button>();
            Component.DestroyImmediate(ss_buttonGameObject.GetComponent<VRC.DataModel.Core.BindingComponent>());
            ss_buttonComponent.onClick.RemoveAllListeners();
            ss_buttonComponent.onClick.AddListener(action);
            s_buttonIcon = ss_buttonGameObject.transform.Find("Icon").gameObject;
            Component.DestroyImmediate(s_buttonIcon.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            s_buttonIcon.Loadfrombytes(icon);
            ss_buttonGameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            s_buttonIcon.gameObject.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
        }
      
    }
}
