using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene(0);

        if (GameObject.FindGameObjectsWithTag("Hero") == null)
        {
            SceneManager.LoadScene(3);
        }

        if (GameObject.FindGameObjectsWithTag("Monster") == null)
        {
            SceneManager.LoadScene(2);
        }
    }

    /*public void Clear()
    {
        if (GameObject.FindGameObjectsWithTag("Monster") == null)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void End()
    {
        if (GameObject.FindGameObjectsWithTag("Hero") == null)
        {
            SceneManager.LoadScene(3);
        }
    }*/
}
