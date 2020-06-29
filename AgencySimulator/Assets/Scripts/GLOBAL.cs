using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObjects/Global")]
public class GLOBAL : ScriptableObject
{
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Toggle(GameObject target)
    {
        target.SetActive(!target.activeSelf);
    }

    
}
