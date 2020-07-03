using UnityEngine;

public class PauseMenuBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject menuRoot;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) menuRoot.SetActive(!menuRoot.activeSelf);
    }
}