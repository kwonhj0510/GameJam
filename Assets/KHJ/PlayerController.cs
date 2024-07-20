using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;
    [SerializeField] private float moveSpeed = 3;       //이동속도
    [SerializeField] private float jumpPower = 10;      //점프 힘
    [SerializeField] private bool isJump = false;
    [SerializeField] private bool isDashing = false;

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        Jump();
        Dash();
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isJump)
            {
                isJump = true;
                rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ground") || other.gameObject.name.Equals("Plat"))
        {
            isJump = false;
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (movement.x > 0)
            {
                StartCoroutine(Dashhh(Vector3.right));
            }
            else if (movement.x < 0)
            {
                StartCoroutine(Dashhh(Vector3.left));
            }
        }
    }

    private IEnumerator Dashhh(Vector3 direction)
    {
        var target = transform.position + direction * 2;
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.3f);
            if (Vector3.Distance(transform.position, target) <= 0.5f)
            {
                yield break;
            }
            yield return new WaitForSeconds(0.01f);

        }
    }

    private void OnShield()
    {

    }
}
