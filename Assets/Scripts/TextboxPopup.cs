using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxPopup : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueTrigger.TriggerDialogue();
        }
    }
}
