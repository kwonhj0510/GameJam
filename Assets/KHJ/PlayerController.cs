using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;

    [SerializeField] private GameObject shield;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3;       //이동속도
    [SerializeField] private float jumpPower = 10;      //점프 힘

    [SerializeField] private bool isJump = false;
    [SerializeField] private bool isDashing = false;
    [SerializeField] private bool isShieldOn = false;

    [SerializeField] private float shieldDurability = 1500;    //보호막 내구도

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        shield.SetActive(false);
    }

    private void Update()
    {
        Jump();
        Dash();
        OnShield();
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);

        if (rigid.velocity.y < 0) //내려갈떄만 스캔
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Plat"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    isJump = false;
                }
            }
        }
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
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(!isShieldOn)
            {
                isShieldOn = true;
                shield.SetActive(true);
            }
            else if(isShieldOn)
            {
                isShieldOn = false;
                shield.SetActive(false);
            }
        }
    }
}
