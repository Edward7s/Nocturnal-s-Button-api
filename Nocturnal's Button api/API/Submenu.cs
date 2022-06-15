﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal class submenu
    {
        internal static List<GameObject> submenuslist = new List<GameObject>();

        internal static GameObject Create(string text, GameObject indexer = null,bool selfaling = false)
        {
            GameObject gam = new GameObject();
            gam.AddComponent<CanvasGroup>();
            gam.name = $"_Submenu_{text}";
            gam.transform.parent = Misc._Submenu.transform.parent.transform.Find(Page.MenuName).transform;
            gam.SetActive(false);
            var mask = new GameObject();
            mask.transform.parent = gam.transform;
            mask.AddComponent<UIInvisibleGraphic>();
            mask.AddComponent<UnityEngine.UI.RectMask2D>();
            mask.transform.localScale = new Vector3(10.5f, 9.2f, 1);
            mask.transform.localPosition = new Vector3(0f, -554.4909f, 0);
            mask.transform.localRotation = new Quaternion(0, 0, 0, 0);
            mask.name = "Masked";
            var instanciateds = GameObject.Instantiate(Misc._Submenu.transform.Find("Header_DevTools").gameObject, gam.transform);
            instanciateds.transform.Find("LeftItemContainer/Text_Title").GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciateds.transform.localPosition = new Vector3(-514, 0, 0);
            var instanciated = GameObject.Instantiate(Misc._Submenu.transform.Find("Scrollrect").gameObject, mask.transform);
            instanciated.transform.localPosition = new Vector3(0, 50, 0);
            instanciated.transform.localScale = new Vector3(0.095f, 0.11f, 1f);
            instanciated.gameObject.SetActive(true);
            instanciated.GetComponent<ScrollRect>().enabled = true;
            gam.transform.localScale = Vector3.one;
            gam.transform.rotation = new Quaternion(0, 0, 0, 0);
            gam.transform.localPosition = new Vector3(0, 512, 0);
            GameObject LayoutGrop = instanciated.transform.Find("Viewport/VerticalLayoutGroup").gameObject;
            GameObject.DestroyImmediate(LayoutGrop.transform.Find("Buttons").gameObject);
            submenuslist.Add(gam.gameObject);

            if (indexer != null)
            {
                var buttoni = instanciateds.transform.Find("LeftItemContainer/Button_Back").gameObject.GetComponent<UnityEngine.UI.Button>();

                buttoni.gameObject.SetActive(true);

                buttoni.onClick.RemoveAllListeners();
                buttoni.onClick.AddListener(new Action(() =>
                {
                    GameObject[] submenus = submenuslist.Where(x => x != indexer).ToArray();
                    for (int i = 0; i < submenus.Length; i++)
                        submenus[i].SetActive(false);
                    indexer.SetActive(true);
                }));
            }
            if (selfaling == true)
            {
                Component.DestroyImmediate(instanciated.GetComponent<ScrollRect>());
                Component.DestroyImmediate(LayoutGrop.GetComponent<VerticalLayoutGroup>());
                return gam;
            }
            Component.DestroyImmediate(LayoutGrop.GetComponent<VerticalLayoutGroup>());
            var grid = LayoutGrop.AddComponent<GridLayoutGroup>();
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.cellSize = new Vector2(200, 175);
            grid.spacing = new Vector2(30, 30);
            grid.constraintCount = 4;
            GameObject.Destroy(LayoutGrop.transform.Find("Spacer_8pt").gameObject);
            Component.DestroyImmediate(instanciated.GetComponent<ScrollRect>());
            instanciated.AddComponent<ScrollRect>();
            var scrollbar =  ScrollBar.Create(gam.transform.Find("Masked").gameObject, 4.6f, 0.0f, 0.1f, 0.98f);
            instanciated.GetComponent<ScrollRect>().verticalScrollbar = scrollbar;
            instanciated.GetComponent<ScrollRect>().content = LayoutGrop.gameObject.GetComponent<RectTransform>();
            instanciated.transform.localPosition = new Vector3(-38, 42.06f, 0);
            return gam;
        }
    }
}
