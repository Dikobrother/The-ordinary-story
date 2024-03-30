using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    public Camera mainCam;
    public float InteractionDistance = 10f;

    public GameObject InteractionUI;
    public TextMeshProUGUI InteractionText;
    void Update()
    {
        InteractionRay();
    }
    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if(Physics.Raycast(ray, out hit, InteractionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                hitSomething = true;
                InteractionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }

        InteractionUI.SetActive(hitSomething);
    }
}
