using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxPopup : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    private Animator npcAnim;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        npcAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcAnim.SetTrigger("BagAnim");
            dialogueTrigger.TriggerDialogue();
        }
    }
}
