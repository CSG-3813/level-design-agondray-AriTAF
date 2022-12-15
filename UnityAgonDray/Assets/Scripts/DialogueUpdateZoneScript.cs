using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUpdateZoneScript : MonoBehaviour
{
    public string dialogue;
    private bool used = false;

    public UIManager ui;

    private void OnTriggerEnter(Collider other)
    {
        if(!used && other.tag == "Player")
        {
            ui.SetDialogueUI(dialogue);
            used = true;
        }
    }
}
