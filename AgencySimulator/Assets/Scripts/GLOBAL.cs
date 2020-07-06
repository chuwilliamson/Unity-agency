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

    public void print(string message)
    {
        Debug.Log(message);
    }

    public void Toggle(GameObject target)
    {
        target.SetActive(!target.activeSelf);
    }
}