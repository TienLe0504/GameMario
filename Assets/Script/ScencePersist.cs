using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ScencePersist : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        int numPersist = FindObjectsOfType<ScencePersist>().Length;
        if (numPersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetPersist()
    {
        Destroy(gameObject);
    }
}
