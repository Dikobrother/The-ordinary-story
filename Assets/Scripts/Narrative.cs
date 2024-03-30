using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrative : MonoBehaviour
{
    public int[] days;

    void Start()
    {
        this.gameObject.SetActive(false);

        on();
    }
    bool check_day()
    {
        Notepad_mechanic player = GameObject.FindWithTag("Player").GetComponent<Notepad_mechanic>();
        for (int i = 0; i < days.Length; i++)
        {
            if(days[i] == player.current_day)
            {
                return true;
            }
        }
        return false;
    }
    public void on()
    {
        this.gameObject.SetActive(check_day());
    }
}
