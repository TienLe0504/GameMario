using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Thoát game khi nh?n phím Escape
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

}
