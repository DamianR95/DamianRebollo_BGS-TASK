using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
