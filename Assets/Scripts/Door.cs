using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Notepad_mechanic notepad;

    void Start()
    {
        notepad = GameObject.FindWithTag("Player").GetComponent<Notepad_mechanic>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & notepad.have_key == true)
        {
            Destroy(this.gameObject);
            notepad.have_key = false;
            notepad.quests[1] = true;
            notepad.quest_texts[1].GetComponent<TextMeshProUGUI>().text = "<s>" + notepad.quest_texts[1].GetComponent<TextMeshProUGUI>().text + "</s>";
        }
    }
}
