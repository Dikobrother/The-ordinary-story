using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dialogue_mechanic : MonoBehaviour, IInteractable
{
    public string[] texts;
    public int number_text = 0;
    public bool in_dialogue;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public string GetDescription()
    {
        return "Talk";
    }
    public void Interact()
    {
        if (number_text < texts.Length & in_dialogue == true)
        {
            in_dialogue = true;
            player.GetComponent<Notepad_mechanic>().in_dialogue = true;
            player.GetComponent<Notepad_mechanic>().dialogue_text.SetActive(true);
            player.GetComponent<Notepad_mechanic>().dialogue_text.GetComponent<TextMeshProUGUI>().text = texts[number_text];
            number_text++;
            player.GetComponent<Notepad_mechanic>().lock_permission();
            if(number_text == texts.Length)
            {
                in_dialogue = false;
            }
        }
        else
        {
            player.GetComponent<Notepad_mechanic>().allow_permission();
            number_text = 0;
            in_dialogue = true;
            player.GetComponent<Notepad_mechanic>().in_dialogue = false;
            player.GetComponent<Notepad_mechanic>().dialogue_text.SetActive(false);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<Notepad_mechanic>().in_dialogue = true;
    //        other.GetComponent<Notepad_mechanic>().dialogue_text.SetActive(true);

    //        other.GetComponent<Notepad_mechanic>().dialogue_text.GetComponent<TextMeshProUGUI>().text = texts[number_text];
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<Notepad_mechanic>().in_dialogue = false;
    //        other.GetComponent<Notepad_mechanic>().dialogue_text.SetActive(false);
    //    }
    //}
}
