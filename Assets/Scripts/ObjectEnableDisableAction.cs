using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnableDisableAction : ModTool.Interface.ModBehaviour, IEInvoke
{
    public GameObject[] EnabledObjects;
    public GameObject[] DisabledObjects;
    void IEInvoke.OnInvokeRecieved(){
        foreach (var eObj in EnabledObjects)
        {
            eObj.SetActive(true);
        }
        foreach (var dObj in DisabledObjects)
        {
            dObj.SetActive(false);
        }
    }
}
