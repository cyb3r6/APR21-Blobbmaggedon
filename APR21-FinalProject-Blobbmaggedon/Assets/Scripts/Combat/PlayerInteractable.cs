using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerInteractable : MonoBehaviour
{
    private bool hasInteracted = false;

    private XRBaseInteractable baseInteracable;

    void Start()
    {
        baseInteracable = GetComponent<XRBaseInteractable>();
        if (baseInteracable)
        {
            baseInteracable.firstHoverEntered.AddListener(OnFocused);
            baseInteracable.lastHoverExited.AddListener(OnDefocused);
        }
    }

    public void OnFocused(HoverEnterEventArgs args)
    {
        hasInteracted = true;
    }

    public void OnDefocused(HoverExitEventArgs args)
    {
        hasInteracted = false;
    }

    /// <summary>
    /// Meant to be overwritten
    /// </summary>
    public virtual void Interact()
    {

    }
}
