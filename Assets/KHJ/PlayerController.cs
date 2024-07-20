using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;

    [SerializeField] private GameObject shield;
    [SerializeField] private Image img_Skil;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3;       //이동속도
    [SerializeField] private float jumpPower = 10;      //점프 힘
    [SerializeField] private float dashPower = 20;      //대쉬 힘
    [SerializeField] private float dashDuration = 0.2f; //대쉬 지속 시간


    [SerializeField] private bool isJump = false;
    [SerializeField] private bool isShieldOn = false;
    [SerializeField] private bool isDashing;
    [SerializeField] private bool isDie = false;
    [SerializeField] public bool isGameStart = true;

    [SerializeField] private float shieldDurability = 1500;    //보호막 내구도
    [SerializeField] private float shieldCooldown = 3;      //보호막 재사용 대기시간

    private Rigidbody2D rigid;
    private Status status;
    private SpriteRenderer spriteRenderer;

    public SaveAndLoad SNL;
    public AudioSource DashSef;

    private void Awake()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        DashSef = GetComponents<AudioSource>()[0];
        rigid = GetComponent<Rigidbody2D>();
        status = GetComponent<Status>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        shield.SetActive(false);
    }

    private void Update()
    {
        if (isGameStart == false) return;
        Filp();
        Jump();
        Dash();
        OnShield();
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;

        movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime * SNL.data.timeScale;
        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);

        if (rigid.velocity.y < 0) // 내려갈때만 스캔
        {
            Vector2 leftRayOrigin = new Vector2(transform.position.x - spriteRenderer.bounds.extents.x, transform.position.y);
            Vector2 rightRayOrigin = new Vector2(transform.position.x + spriteRenderer.bounds.extents.x, transform.position.y);

            Debug.DrawRay(leftRayOrigin, Vector3.down * 1f, new Color(0, 1, 0));
            Debug.DrawRay(rightRayOrigin, Vector3.down * 1f, new Color(0, 1, 0));

            RaycastHit2D leftRayHit = Physics2D.Raycast(leftRayOrigin, Vector3.down, 1f, LayerMask.GetMask("Plat"));
            RaycastHit2D rightRayHit = Physics2D.Raycast(rightRayOrigin, Vector3.down, 1f, LayerMask.GetMask("Plat"));

            if (leftRayHit.collider != null || rightRayHit.collider != null)
            {
                if ((leftRayHit.collider != null && leftRayHit.distance < 1f) || (rightRayHit.collider != null && rightRayHit.distance < 1f))
                {
                    isJump = false;
                }
            }
        }
    }


    private void Filp()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
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

            StartCoroutine(DashCoroutine());

        }
    }

        private IEnumerator DashCoroutine()
        {
            isDashing = true;
            Vector2 dashDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;
            rigid.velocity = dashDirection * dashPower;

            yield return new WaitForSeconds(dashDuration);

            rigid.velocity = Vector2.zero;
            isDashing = false;
        }

        private void OnShield()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (!isShieldOn)
                {
                    isShieldOn = true;
                    shield.SetActive(true);
                }
                else if (isShieldOn)
                {
                    isShieldOn = false;
                    shield.SetActive(false);
                    StartCoroutine(ShieldCoroutine());

            }

            if (shieldDurability == 0)
                {
                    shield.SetActive(false);
                }
            }
        }

        private IEnumerator ShieldCoroutine()
        {
            while (shieldCooldown > 1)
            {
                shieldCooldown -= Time.deltaTime;
                img_Skil.fillAmount = (1 / shieldCooldown);
                yield return new WaitForFixedUpdate();

            }
            shieldCooldown = 3;
        }

        private void Attack()
        {
            if (isShieldOn && Input.GetKeyDown(KeyCode.Space))
            {

            }
        }

        private void TakeDamage()
        {
            status.curHP--;

            if (status.curHP <= 0)
            {
                isDie = true;
                SceneManager.LoadScene("");
            }
        }
    }
