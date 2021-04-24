using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IE_Button : ModTool.Interface.ModBehaviour
{
    [Header("Interactable Button")]
    [SerializeField] private GameObject ActionObject;
    [SerializeField] private string InteractableObjectTag;
    [SerializeField] private Renderer ButtonObject;
    [SerializeField] private Material Mat;
    public bool DeactiveOnInvoke =false;

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == InteractableObjectTag)
        {
            ActionObject.GetComponent<IEInvoke>().OnInvokeRecieved();
            ButtonObject.material = Mat;
            if (DeactiveOnInvoke)
            {
                Destroy(gameObject.GetComponent<BoxCollider>());
            }
            
        }
    }
}
