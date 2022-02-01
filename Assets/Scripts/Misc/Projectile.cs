using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
            lifetime = 2.0f;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x != speed )
        {
            Destroy(gameObject);
        }
    }
}
