using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody2D;
    [SerializeField] float jumpSpeed = 5f;
    CapsuleCollider2D mycapsuleCollider;
    [SerializeField] float runClimb = 5f;
    float gravatiScale;
    Animator myAnimator;
    BoxCollider2D myFeetCollider;
    bool isAlive = true;
    [SerializeField] GameObject fire;
    [SerializeField] Transform gun;
    [SerializeField] Vector2 deathVelocity = new Vector2(20f, 20f);
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mycapsuleCollider = GetComponent<CapsuleCollider2D>();
        gravatiScale = myRigidbody2D.gravityScale;
        myAnimator = GetComponent<Animator>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
   public void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        Instantiate(fire,gun.position,transform.rotation);
    }
    public void Die()
    {
        if (mycapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards")) || myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Die");
            myRigidbody2D.velocity = deathVelocity;
            FindObjectOfType<GameSession>().ProcessPlayer();
        }
    }
    public void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }
    public void run()
    {
        Vector2 runHorizontal = new Vector2(moveInput.x*runSpeed,myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = runHorizontal;
        bool playerHorizontal = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running",playerHorizontal);
    }
    public void FlipSprite()
    {
        bool playHorizontal = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }
    public void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            myRigidbody2D.velocity += new Vector2(0f,jumpSpeed);
        }
    }
    public void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("ladder")))
        {
            myAnimator.SetBool("isClimbing", false);

            myRigidbody2D.gravityScale = gravatiScale;
            return;
        }
        Vector2 climb = new Vector2(myRigidbody2D.velocity.x, moveInput.y*runClimb);
        myRigidbody2D.velocity = climb;
        myRigidbody2D.gravityScale = 0f;
        bool playerVerticalSpeed = Mathf.Abs(myRigidbody2D.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerVerticalSpeed);
        
    }
}
