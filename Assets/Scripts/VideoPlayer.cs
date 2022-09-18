using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlayer : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject videoPlayer;

    private void FixedUpdate()
    {
        EndScene();
    }

    void EndScene()
    {
        if (dialogueManager.changeScene)
        {
            videoPlayer.SetActive(true);
        }
    }
}
