using System;

using UnityEngine.UI;
using UnityEngine;
namespace Nocturnal.Apis.qm
{
    internal class Slider
    {
        private GameObject _SliderGameobject { get; set; }
        private UnityEngine.UI.Slider _SliderComponent { get; set; }
        private Text s_textGameobj { get; set; }
        private Text s_textGameobj2 { get; set; }

        private Transform Path { get; set; }

        ~Slider()
        {
            this._SliderGameobject = null;
            this._SliderComponent = null;
            this.s_textGameobj2 = null;
        }

        public Slider(out GameObject instance, GameObject parent, Action<float> setOutput, float prevolume = 876.412f, Action todo = null, string title = "")
        {
            var slider = new GameObject("Slider");
            slider.transform.parent = parent.transform;
            slider.AddComponent<LayoutElement>();
            slider.transform.localPosition = Vector3.zero;
            slider.transform.localScale = Vector3.one;
            slider.transform.localEulerAngles = Vector3.zero;
            new GameObject("Blank").AddComponent<LayoutElement>().transform.parent = parent.transform;
            Path = slider.transform;
            _SliderGameobject = GameObject.Instantiate(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeGameAvatars").gameObject, Path);
            Component.DestroyImmediate(_SliderGameobject.GetComponent<UiSettingConfig>());
            GameObject.DestroyImmediate(_SliderGameobject.transform.Find("Label").gameObject);
            _SliderGameobject.transform.rotation = new Quaternion(0, 0, 0, 0);
            _SliderGameobject.transform.localScale = new Vector3(1, 1, 1);
            _SliderComponent = _SliderGameobject.GetComponent<UnityEngine.UI.Slider>();
            if (prevolume != 876.412f)
                _SliderComponent.value = (float)prevolume;
            _SliderComponent.onValueChanged.RemoveAllListeners();
            _SliderComponent.m_OnValueChanged.RemoveAllListeners();
            s_textGameobj = _SliderGameobject.transform.Find("SliderLabel").GetComponent<Text>();
            s_textGameobj.text = $"{prevolume * 100}%";
            _SliderComponent.onValueChanged.AddListener((UnityEngine.Events.UnityAction<float>)sliderstuff);
            void sliderstuff(float values)
            {
                s_textGameobj.text = $"{values * 100}%";
                setOutput(values);
                if (todo != null)
                    todo.Invoke();
            }
            instance = _SliderGameobject;
            _SliderGameobject.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(440, 70);
            _SliderGameobject.transform.Find("SliderLabel").transform.localScale = new Vector3(1.1f, 1.1f, 1);
            s_textGameobj2 = GameObject.Instantiate(s_textGameobj.gameObject, s_textGameobj.transform.parent).gameObject.GetComponent<Text>();
            s_textGameobj2.text = title;
            s_textGameobj2.horizontalOverflow = HorizontalWrapMode.Overflow;
            s_textGameobj2.transform.localPosition = new Vector3(225, -15, 1);
            _SliderGameobject.transform.localPosition = new Vector3(-110, -18, 1);
        }



        public Slider(GameObject parent, Action<float> setOutput, float prevolume = 876.412f, Action todo = null, string title = "")
        {
            var slider = new GameObject("Slider");
            slider.transform.parent = parent.transform;
            slider.AddComponent<LayoutElement>();
            slider.transform.localPosition = Vector3.zero;
            slider.transform.localScale = Vector3.one;
            slider.transform.localEulerAngles = Vector3.zero;
            new GameObject("Blank").AddComponent<LayoutElement>().transform.parent = parent.transform;
            Path = slider.transform;
            _SliderGameobject = GameObject.Instantiate(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeGameAvatars").gameObject, Path);
            Component.DestroyImmediate(_SliderGameobject.GetComponent<UiSettingConfig>());
            GameObject.DestroyImmediate(_SliderGameobject.transform.Find("Label").gameObject);
            _SliderGameobject.transform.rotation = new Quaternion(0, 0, 0, 0);
            _SliderGameobject.transform.localScale = new Vector3(1, 1, 1);
            _SliderComponent = _SliderGameobject.GetComponent<UnityEngine.UI.Slider>();
            if (prevolume != 876.412f)
                _SliderComponent.value = (float)prevolume;
            _SliderComponent.onValueChanged.RemoveAllListeners();
            _SliderComponent.m_OnValueChanged.RemoveAllListeners();
            s_textGameobj = _SliderGameobject.transform.Find("SliderLabel").GetComponent<Text>();
            s_textGameobj.text = $"{prevolume * 100}%";
            _SliderComponent.onValueChanged.AddListener((UnityEngine.Events.UnityAction<float>)sliderstuff);
            void sliderstuff(float values)
            {
                s_textGameobj.text = $"{values * 100}%";
                setOutput(values);
                if (todo != null)
                    todo.Invoke();
            }
            _SliderGameobject.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(440, 70);
            _SliderGameobject.transform.Find("SliderLabel").transform.localScale = new Vector3(1.1f, 1.1f, 1);
            s_textGameobj2 = GameObject.Instantiate(s_textGameobj.gameObject, s_textGameobj.transform.parent).gameObject.GetComponent<Text>();
            s_textGameobj2.text = title;
            s_textGameobj2.horizontalOverflow = HorizontalWrapMode.Overflow;
            s_textGameobj2.transform.localPosition = new Vector3(225, -15, 1);
            _SliderGameobject.transform.localPosition = new Vector3(-110, -18, 1);
        }




    }
}

