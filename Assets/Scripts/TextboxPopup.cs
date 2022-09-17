using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxPopup : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    private Animator npcAnim;
    private BoxCollider boxCollider;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        npcAnim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcAnim.SetTrigger("BagAnim");          
            dialogueTrigger.TriggerDialogue();
            boxCollider.enabled = false;
        }
    }
}
