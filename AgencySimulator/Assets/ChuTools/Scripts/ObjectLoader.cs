using System.Collections.Generic;
using UnityEngine;

public class ObjectLoader : MonoBehaviour
{
    public List<GameObject> PrefabsToload;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (var go in PrefabsToload) Instantiate(go);
    }
}