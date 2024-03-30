using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_interactable : MonoBehaviour, IInteractable
{
    public Animator d_anim;
    public bool is_open;
    void Start()
    {
        d_anim.SetBool("isOpen", is_open);
    }

    public string GetDescription()
    {
        if (is_open)
        {
            return "Close";
        }
        else
        {
            return "Open";
        }
    }
    public void Interact()
    {
        is_open = !is_open;
        d_anim.SetBool("isOpen", is_open);
    }
}
