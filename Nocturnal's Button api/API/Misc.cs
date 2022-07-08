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
        internal static GameObject s_buttonPrefab { get; set; }
        internal static GameObject s_togglePrebab{ get; set; }
        internal static GameObject s_page { get; set; }
        internal static GameObject s_submenu { get; set; }
        internal static GameObject s_qmExpand { get; set; }
        internal static GameObject s_scrollBar { get; set; }
        internal static GameObject s_qmCanvas { get; set; }

        internal static void GetPrefabs()
        {

            s_qmCanvas = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject;

            s_page = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools").gameObject;

            s_submenu = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools").gameObject;

            s_buttonPrefab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_WarpAllToHub").gameObject;

            s_togglePrebab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_2/Button_ToggleFallbackIcon").gameObject;

            s_qmExpand = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand").gameObject;

            s_scrollBar = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Scrollbar").gameObject;
        }

        internal static void Loadfrombytes(this GameObject gmj, string img, bool isimage = true) => Loadfrombytes(gmj, System.Convert.FromBase64String(img), isimage);
        internal static void Loadfrombytes(this GameObject gmj, byte[] img, bool isimage = true) => new ImageHandler(gmj, img, isimage);
        internal static GameObject GetMenu(this GameObject gameobj) { return gameobj.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject; }

    }

    internal class ImageHandler 
    {
        private Image _ImageComponent { get; set; }
        private Texture2D s_texture2d { get; set; }
        private ImageThreeSlice _ImageThreeSliceCompnent { get; set; }
        ~ImageHandler() {
            this._ImageComponent = null;
            this.s_texture2d = null;
            this._ImageThreeSliceCompnent = null;
        }
  
        public ImageHandler(GameObject gmj, byte[] img, bool isimage = true)
        {
            if (isimage)
            {
                _ImageComponent = gmj.GetComponent<Image>();
                s_texture2d = new Texture2D(256, 256);
                ImageConversion.LoadImage(s_texture2d, img);
                s_texture2d.Apply();
                _ImageComponent.sprite = Sprite.CreateSprite(s_texture2d,
                new Rect(0f, 0f, s_texture2d.width, s_texture2d.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);
                return;
            }
            _ImageThreeSliceCompnent = gmj.GetComponent<ImageThreeSlice>();
            s_texture2d = new Texture2D(256, 256);
            ImageConversion.LoadImage(s_texture2d, img);
            s_texture2d.Apply();
            _ImageThreeSliceCompnent.prop_Sprite_0 = Sprite.CreateSprite(s_texture2d,
            new Rect(0f, 0f, s_texture2d.width, s_texture2d.height), new Vector2(0f, 0f), 100000f, 1000u,
            SpriteMeshType.FullRect, new Vector4(255, 0, 255, 0), false);
        }
    }
}
