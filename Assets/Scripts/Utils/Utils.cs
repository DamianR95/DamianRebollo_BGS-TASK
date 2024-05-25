using BGS.ProgrammerTask.Inventory;
using BGS.ProgrammerTask.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.ProgrammerTask.Utilities
{
    public class Utils : MonoBehaviour
    {
        static public void CallAction(System.Delegate[] subscriptors, params object[] args)
        {
            if (subscriptors == null)
                return;

            for (int i = 0; i < subscriptors.Length; i++)
            {
                try
                {
                    subscriptors[i].DynamicInvoke(args);
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
            }
        }

        static public Draggable InstanceUI_Element(GameObject prefab, DropZone area, Item item)
        {
            var uiDraggeable = Instantiate(prefab, area.myTransform).GetComponent<Item_UI>();
            uiDraggeable.Setup(area, item);
            return uiDraggeable;
        }
    }
}