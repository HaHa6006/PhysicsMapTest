using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatChange : ModTool.Interface.ModBehaviour,IEInvoke
{
    public MeshRenderer Ground;
    public Material Mat;

    void IEInvoke.OnInvokeRecieved()
    {
        Ground.material = Mat;
    }
}
