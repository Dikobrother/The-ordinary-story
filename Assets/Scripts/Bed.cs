using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public GameObject player;
    public GameObject[] narratives;

    void Awake()
    {
        narratives = GameObject.FindGameObjectsWithTag("Narrative");
        player = GameObject.FindWithTag("Player");
    }
    public string GetDescription()
    {
        return "Sleep";
    }
    public void Interact()
    {
        player.GetComponent<Notepad_mechanic>().current_day++;
        for (int i = 0; i < narratives.Length; i++)
        {
            if (narratives[i] != null)
            {
                narratives[i].GetComponent<Narrative>().on();
            }        
        }
    }
}
