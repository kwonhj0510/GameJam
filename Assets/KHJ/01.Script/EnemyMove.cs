using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public int nextMove;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 5);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(nextMove, rigidbody.velocity.y);

        Vector2 frontVec = new Vector2(rigidbody.position.x + nextMove * 0.2f, rigidbody.position.y);
        Debug.DrawRay(rigidbody.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Plat"));
        if(rayHit.collider == null)
        {
            Debug.Log("Collider is null");
            Turn();
        }
    }
    private void Think()
    {
        nextMove = Random.Range(-1, 2);

        animator.SetInteger("WalkSpeed", nextMove);
        
        if(nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == 1;
        }

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }

    private void Turn()
    {
        nextMove *= -1;

        CancelInvoke();
        Invoke("Think", 2);
    }
}
