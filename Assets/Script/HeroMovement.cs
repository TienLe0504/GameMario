using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class HeroMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myrigidbody2D;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(moveSpeed, 0f);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipScale();

    }
    public void FlipScale()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myrigidbody2D.velocity.x)), 1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            animator.SetBool("attack",true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            animator.SetBool("attack", false);
        }
    }




}
