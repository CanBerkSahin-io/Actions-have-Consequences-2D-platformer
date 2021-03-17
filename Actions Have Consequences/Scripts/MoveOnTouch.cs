using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    private bool moving;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }


}
