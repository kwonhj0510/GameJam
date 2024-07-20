using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatForm : MonoBehaviour
{
    private GameObject currentOneWayPlatfrom;

    [SerializeField] private CapsuleCollider2D playerCollider;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentOneWayPlatfrom != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentOneWayPlatfrom != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OnWayPlatform"))
        {
            currentOneWayPlatfrom = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OnWayPlatform"))
        {
            currentOneWayPlatfrom = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatfrom.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
