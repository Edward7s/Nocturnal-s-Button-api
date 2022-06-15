using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Nocturnal.Apis.qm
{
    internal static class Misc
    {
        internal static GameObject _ButtonPrefab { get; set; }
        internal static GameObject _TogglePrebab{ get; set; }
        internal static GameObject _Page { get; set; }
        internal static GameObject _Submenu { get; set; }
        internal static GameObject _QMexpand { get; set; }
        internal static GameObject _Scrollbar { get; set; }

        internal static void GetPrefabs()
        {
            _Page = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools").gameObject;

            _Submenu = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools").gameObject;

            _ButtonPrefab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_WarpAllToHub").gameObject;

            _TogglePrebab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_2/Button_ToggleFallbackIcon").gameObject;

            _QMexpand = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand").gameObject;

            _Scrollbar = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Scrollbar").gameObject;
        }

        internal static void Loadfrombytes(this GameObject gmj, string img, bool isimage = true) => Loadfrombytes(gmj, System.Convert.FromBase64String(img), isimage);
        internal static void Loadfrombytes(this GameObject gmj, byte[] img, bool isimage = true) => new ImageHandler(gmj, img, isimage);
        internal static GameObject Getmenu(this GameObject gameobj) { return gameobj.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject; }

    }

    internal class ImageHandler 
    {
        private Image _ImageComponent { get; set; }
        private Texture2D _Texture2d { get; set; }
        private ImageThreeSlice _ImageThreeSliceCompnent { get; set; }
        ~ImageHandler() {
            this._ImageComponent = null;
            this._Texture2d = null;
            this._ImageThreeSliceCompnent = null;
        }
  
        public ImageHandler(GameObject gmj, byte[] img, bool isimage = true)
        {
            if (isimage)
            {
                _ImageComponent = gmj.GetComponent<Image>();
                _Texture2d = new Texture2D(256, 256);
                ImageConversion.LoadImage(_Texture2d, img);
                _Texture2d.Apply();
                _ImageComponent.sprite = Sprite.CreateSprite(_Texture2d,
                new Rect(0f, 0f, _Texture2d.width, _Texture2d.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);
                return;
            }
            _ImageThreeSliceCompnent = gmj.GetComponent<ImageThreeSlice>();
            _Texture2d = new Texture2D(256, 256);
            ImageConversion.LoadImage(_Texture2d, img);
            _Texture2d.Apply();
            _ImageThreeSliceCompnent.prop_Sprite_0 = Sprite.CreateSprite(_Texture2d,
            new Rect(0f, 0f, _Texture2d.width, _Texture2d.height), new Vector2(0f, 0f), 100000f, 1000u,
            SpriteMeshType.FullRect, new Vector4(255, 0, 255, 0), false);
        }
    }
}
