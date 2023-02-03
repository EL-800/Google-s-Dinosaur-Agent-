using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DinosaurController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;    
    [SerializeField] private EndGame end;
    [SerializeField] private List<string> obstacles;
    private Rigidbody2D physic;
    private SpriteRenderer sprite;
    private bool onGround;    
    private Animator animator;
    private Vector2 originalOffset;
    private Vector2 originalSize;
    private Vector2 reducedOffset;
    private Vector2 reducedSize;
    private BoxCollider2D boxColllider;
    private Vector3 originalPosition;
    private bool up;
    private bool down;
    private bool isGameOver = false;


    private void Awake()
    {
        sprite= GetComponent<SpriteRenderer>();
        physic = GetComponent<Rigidbody2D>();                
        animator = GetComponent<Animator>();
        originalPosition = transform.position;
        boxColllider = gameObject.GetComponent<BoxCollider2D>();
        originalOffset = boxColllider.offset;
        originalSize = boxColllider.size;
        reducedOffset = new Vector2(0.1289034f, 0.3253452f);
        reducedSize = new Vector2(0.7281456f, 0.5741789f);
    }

    private void FixedUpdate()
    {
        animator.SetBool("inGround", onGround);
        /*if (isGameOver && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)))
        {                      
            animator.SetBool("gameOver", false);
            isGameOver = false;
            transform.position = originalPosition;
            physic.bodyType = RigidbodyType2D.Dynamic;
            end.ResetGame();
        }*/        
        if (onGround && up && !down && physic.velocity.y == 0)
            physic.AddForce(Vector2.up * jumpForce);
        if (!onGround && down)
            physic.AddForce(Vector2.down * jumpForce);
        if (onGround && down)
        {
            boxColllider.offset = reducedOffset; 
            boxColllider.size = reducedSize;
            animator.SetBool("keyDown", true);
        }
        else
        {            
            boxColllider.offset = originalOffset; 
            boxColllider.size = originalSize;
            animator.SetBool("keyDown", false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = true;        
        if (obstacles.Any(s => s == collision.gameObject.tag))
        {
            sprite.enabled = false;
            physic.bodyType = RigidbodyType2D.Static;
            end.End();
            isGameOver = true;
            animator.SetBool("gameOver", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = false;        
    }

    public void SetInput(bool up, bool down)
    {
        this.up = up;
        this.down = down;
    }

    public void ResetGame()
    {
        sprite.enabled = true;
        animator.SetBool("gameOver", false);
        isGameOver = false;
        transform.position = originalPosition;       
        physic.bodyType = RigidbodyType2D.Dynamic;        
        end.ResetGame();
    }

    public float GetYVelocity()
    {
        return physic.velocity.y;
    }

    public bool GetGameState() 
    {
        return isGameOver;
    }
}
