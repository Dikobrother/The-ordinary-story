using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notepad_mechanic : MonoBehaviour
{
    public KeyCode notepad_key = KeyCode.Tab;
    public FirstPersonController player;

    public bool have_key;
    public bool[] quests;
    public GameObject[] quest_texts;
    public GameObject Notepad;
   
    public GameObject wall;
    public GameObject small_note;
    public bool in_dialogue;
    public GameObject dialogue_text;

    public Camera mainCam;
    public float InteractionDistance = 10f;

    public GameObject InteractionUI;
    public TextMeshProUGUI InteractionText;

    public int current_day;

    private Vector3 prev_transform;

    public GameObject picked_obj;
    public GameObject actionsUI;

    public GameObject EscUI;
    public GameObject normalUI;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        Action_obj();
        drop_obj();
        if (Input.GetKeyDown(notepad_key))
        {
            Debug.Log("pressed");
            Notepad_main();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.lockCursor = !player.lockCursor;
            EscUI.SetActive(!EscUI.active);
            normalUI.SetActive(!normalUI.active);
            change_permission();
        }
        InteractionRay();
    }
    void Notepad_main()
    {
        small_note.SetActive(!small_note.activeSelf);
        Notepad.SetActive(!Notepad.activeSelf);
        change_permission();
    }
    void change_permission()
    {
        player.cameraCanMove = !player.cameraCanMove;
        player.enableZoom = !player.enableZoom;
        player.playerCanMove = !player.playerCanMove;
        player.enableCrouch = !player.enableCrouch;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = !this.gameObject.GetComponent<Rigidbody>().isKinematic;
    }

    public void lock_permission()
    {
        player.cameraCanMove = false;
        player.enableZoom = false;
        player.playerCanMove = false;
        player.enableCrouch = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void allow_permission()
    {
        player.cameraCanMove = true;
        player.enableZoom = true;
        player.playerCanMove = true;
        player.enableCrouch = true;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                hitSomething = true;
                InteractionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        InteractionUI.SetActive(hitSomething & !in_dialogue);
    }

    public void Get_transfrom()
    {
        prev_transform = transform.position;
        Invoke("Set_transform", 2);
    }
    public void Set_transform()
    {
        this.gameObject.transform.position = new Vector3(prev_transform.x, prev_transform.y, prev_transform.z);
    }

    public void drop_obj()
    {
        if(Input.GetKeyDown(KeyCode.Q) & picked_obj != null)
        {
            picked_obj.GetComponent<Rigidbody>().isKinematic = false;
            picked_obj.GetComponent<Pickup_obj>().picked = false;
            picked_obj.transform.parent = null;
            picked_obj = null;
            actionsUI.SetActive(false);
        }
    }

    public void Action_obj()
    {
        if(picked_obj != null & Input.GetKeyDown(KeyCode.F))
        {
            picked_obj.GetComponent<Pickup_obj>().Action();
        }
    }
}