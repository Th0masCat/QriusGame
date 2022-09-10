using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TextboxPopup : MonoBehaviour
{
    [SerializeField] GameObject textboxPopup;
    public float offset;

    [TextArea(2, 10)]
    public string[] dialogue;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 position = new Vector3(transform.position.x, offset, transform.position.z);
        if (other.CompareTag("Player"))
        {
            Instantiate(textboxPopup, position , Quaternion.identity, transform);
        }
    }
}
