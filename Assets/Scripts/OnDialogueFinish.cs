using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDialogueFinish : MonoBehaviour
{
	public DialogueManager dialogueManager;

    private void LateUpdate()
    {
        EndScene();
    }

    void EndScene()
    {
		if (dialogueManager.changeScene)
		{
			SceneManager.LoadScene(0);
		}
	}

    
}
