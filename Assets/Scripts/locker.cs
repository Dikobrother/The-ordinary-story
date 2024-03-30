using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locker : MonoBehaviour, IInteractable
{
    public Animator lo_anim;
    public bool is_open;
    void Start()
    {
        lo_anim.SetBool("isOpen", is_open);
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
        lo_anim.SetBool("isOpen", is_open);
    }
}
