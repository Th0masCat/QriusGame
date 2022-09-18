using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(enumFunc());
        }
    }

    IEnumerator enumFunc()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
