using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeDelay = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(loadScence());
    }
    IEnumerator loadScence()
    {
        yield return new WaitForSecondsRealtime(timeDelay);
        int scence = SceneManager.GetActiveScene().buildIndex;
        int scenceIndex = scence + 1;
        if(scenceIndex == SceneManager.sceneCountInBuildSettings){
            scenceIndex = 0;
        }
        FindObjectOfType<ScencePersist>().ResetPersist();
        SceneManager.LoadScene(scenceIndex);
    }
}
