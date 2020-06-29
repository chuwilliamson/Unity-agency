using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoader : MonoBehaviour
{
    public List<GameObject> PrefabsToload;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in PrefabsToload)
        {
            GameObject.Instantiate(go);
        }
    }

}
