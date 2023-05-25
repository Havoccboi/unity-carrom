using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    bool hasStriked = false;
    bool positionset = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //HandleCollision(col.gameObject);
        GameObject striker = GameObject.FindWithTag("striker");
        GameObject coin = GameObject.FindWithTag("coins");
        if (!hasStriked && !positionset)
        {
            if (col.gameObject.tag == "coins")
            {
                Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
                col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                //Destroy(col.gameObject);
                Debug.Log("Collision updated!");
                //Vector3 inverseMouPos = new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, Input.mousePosition.z);


                //
                StartCoroutine(EnableCollision(col.collider));

            }


        }
        // if (!hasStriked || positionset) return;
        //   Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);



    }
    IEnumerator EnableCollision(Collider2D col)
    {
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(col, GetComponent<Collider2D>(), false);
        Debug.Log("Collision re-enabled!");
    }

}
