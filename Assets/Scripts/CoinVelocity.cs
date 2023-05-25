using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinVelocity : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float drag = 5f;
    public float angularDrag = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.drag = drag;
        rigidbody.angularDrag = angularDrag;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (rigidbody.velocity.magnitude < 0.05f && rigidbody.velocity.magnitude != 0)
        {
            if (col.gameObject.tag == "coins")
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.angularVelocity = 0f;


            }
        }
    }

}
