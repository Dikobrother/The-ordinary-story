using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_obj : MonoBehaviour, IInteractable
{
    public Notepad_mechanic player;
    public bool picked;
    public Vector3 offset_pos;
    public Vector3 offset_rot;
    public GameObject hand;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Notepad_mechanic>();
    }

    public string GetDescription()
    {
        return "Pick up";
    }

    public void Interact()
    {
        if (player.picked_obj == null)
        {
            player.picked_obj = this.gameObject;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent = hand.transform;
            picked = true;
            this.transform.localPosition = offset_pos;
            this.transform.localRotation = Quaternion.Euler(offset_rot);
            Debug.Log("null");
            player.actionsUI.SetActive(true);
        }
        else
        {
            player.picked_obj.GetComponent<Rigidbody>().isKinematic = false;
            player.picked_obj.GetComponent<Pickup_obj>().picked = false;
            player.picked_obj.transform.parent = null;

            player.picked_obj = this.gameObject;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent = hand.transform;
            picked = true;
            this.transform.localPosition = offset_pos;
            this.transform.localRotation = Quaternion.Euler(offset_rot);
            Debug.Log("non_null");
        }
    }

    public void Action()
    {
        Debug.Log("do_action");
    }
}
