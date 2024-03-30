using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : MonoBehaviour, IInteractable
{
    public Vector3 spawnPositionOffset;
    public Vector3 spawnRotationOffset;
    public Vector2 minMaxZoom = new Vector2(0.5f, 2);
    public float defaultZoomValue = 1f;
    public GameObject inspectionCanvas;
    public GameObject defaultCanvas;

    public InspectionCamera inspectionCamera;
    public Notepad_mechanic player;
    private GameObject inst_obj;

    public bool in_interact;
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Notepad_mechanic>();
    }
    public string GetDescription()
    {
        return "View";
    }
    public void Interact()
    {
        if(!in_interact)
        {
            inst_obj = Instantiate(this.gameObject, inspectionCamera.transform.GetChild(0));
            //inst_obj.GetComponent<Rigidbody>().isKinematic = true;
            InspectableObject inst_obj_scr = inst_obj.GetComponent<InspectableObject>();

            inst_obj_scr.transform.localPosition = Vector3.zero + inst_obj_scr.spawnPositionOffset;
            inst_obj_scr.transform.localRotation = Quaternion.Euler(Vector3.zero + inst_obj_scr.spawnRotationOffset);

            inspectionCanvas.SetActive(true);
            defaultCanvas.SetActive(false);

            inspectionCamera.inspectableObject = inst_obj_scr;
            inspectionCamera.gameObject.SetActive(true);

            player.lock_permission();
            in_interact = true;
        }
        else
        {
            player.GetComponent<Rigidbody>().isKinematic = false;
            in_interact = false;
            player.allow_permission();
            Destroy(inst_obj);
            inspectionCanvas.SetActive(false);
            defaultCanvas.SetActive(true);
            inspectionCamera.gameObject.SetActive(false);
        }
    }
}
