using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitScript : MonoBehaviour
{   
    public void ExitScene()
    {
        SceneManager.LoadScene(0);
    }
}
