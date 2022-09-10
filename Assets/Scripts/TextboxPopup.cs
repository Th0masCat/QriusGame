using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxPopup : MonoBehaviour
{
    [SerializeField] GameObject textboxPopup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textboxPopup.SetActive(true);
        }
    }
}
