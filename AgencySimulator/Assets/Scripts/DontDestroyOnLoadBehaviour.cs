using UnityEngine;

public class DontDestroyOnLoadBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}