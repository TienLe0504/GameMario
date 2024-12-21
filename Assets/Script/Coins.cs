using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Coins : MonoBehaviour
{
    [SerializeField] AudioClip audio;
    [SerializeField] int coinpickUp=10;
    bool wasCoin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&!wasCoin)
        {
            wasCoin = true;
            FindObjectOfType<GameSession>().addpoint(coinpickUp);
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
