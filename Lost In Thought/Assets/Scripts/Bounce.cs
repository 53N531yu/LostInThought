using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bounce : MonoBehaviour, IPointerDownHandler
{
    Rigidbody2D rb;

    Vector3 LastVelocity;

    public float speed = 400f;
    public bool frozen;

    public Bounce bounce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(20 * Time.deltaTime * speed, 20 * Time.deltaTime * speed));
    }

    void Update()
    {
        LastVelocity = rb.velocity;
        rb.AddForce(new Vector2(20 * Time.deltaTime * bounce.speed, 20 * Time.deltaTime * bounce.speed));
    }

    void LateUpdate() 
    {
        if (frozen == true)
        {
            rb.drag = 1;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        var magnitude = LastVelocity.magnitude;
        var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(magnitude, 0f);
        bounce.speed = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (frozen == true)
        {
            frozen = false;
            bounce.speed = 800;
        }
        else
        {
            frozen = true;
        }
    }
}
