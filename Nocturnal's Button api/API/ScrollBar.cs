using UnityEngine;
using UnityEngine.UI;

namespace Nocturnal.Apis.qm
{
    internal class ScrollBar
    {
        internal static Scrollbar Create(GameObject path, float x, float y, float sizeX, float sizeY)
        {
            var scrollbar = GameObject.Instantiate(Misc.s_scrollBar, path.transform).gameObject;
            scrollbar.transform.localScale = new Vector3(sizeX, sizeY, 1);
            scrollbar.transform.rotation = new Quaternion(0, 0, 0, 0);
            scrollbar.transform.localPosition = new Vector3(x * 10, y * 10, 1);
            return scrollbar.GetComponent<Scrollbar>();
        }
    }
}
