using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myrigidbody2D;
    [SerializeField] float speed=20f;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * speed;

    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(xSpeed, 0f);
        FlipSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    public void FlipSprite()
    {
        bool playHorizontal = Mathf.Abs(myrigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playHorizontal)
        {
            float xScale = Mathf.Sign(myrigidbody2D.velocity.x) * 0.75f;
            float yScale = transform.localScale.y;
            transform.localScale = new Vector2(xScale, yScale);
        }
    }

}
