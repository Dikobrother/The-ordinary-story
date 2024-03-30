using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Notepad_mechanic notepad;

    void Start()
    {
        notepad = GameObject.FindWithTag("Player").GetComponent<Notepad_mechanic>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            notepad.have_key = true;
            notepad.quests[0] = true;
            notepad.quest_texts[0].GetComponent<TextMeshProUGUI>().text = "<s>" + notepad.quest_texts[0].GetComponent<TextMeshProUGUI>().text + "</s>";
            notepad.quest_texts[1].SetActive(true);
        }
    }
}
