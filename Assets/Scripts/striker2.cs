using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class striker2 : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    Transform selftrans;
    Vector2 startpos;
    public Slider myslider;
    Vector2 direction;
    Vector3 mousepos;
    Vector3 mousepos2;
    public LineRenderer line;
    Transform arrowtransorm;
    public GameObject arrowdirection;
    //public Transform StrikerBG;
    bool hasStriked = false;
    bool positionset = false;
    public GameObject board;
    public AudioSource audioPlayer2;
    public float drag = 5f;
    public float angularDrag = 5f;
    public Transform arrowpoint;





    // private LineRenderer lineRenderer;



    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.drag = drag;
        rigidbody.angularDrag = angularDrag;
        selftrans = transform;
        startpos = transform.position;
        arrowtransorm = arrowdirection.transform;
       





    }


    public void shootstriker()
    {
        float x = 0;
        if (positionset && rigidbody.velocity.magnitude == 0)
        {
            x = Vector2.Distance(transform.position, mousepos);
        }
        direction = (Vector2)(mousepos2 - transform.position);
        direction.Normalize();
        rigidbody.AddForce(direction * x * 6800);
        hasStriked = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        

        arrowdirection.SetActive(false);

        line.enabled = false;
        // Enable the StrikerBG game object
        


        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousepos2 = new Vector3(-mousepos.x, -mousepos.y-3, -mousepos.z);
        Vector3 inverseMouPos = new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, Input.mousePosition.z);
        mousepos2 = Camera.main.ScreenToWorldPoint(inverseMouPos);
        mousepos2.y = mousepos2.y + 3;

        if (selftrans.position.x != 0)
        {
            mousepos2.x = mousepos2.x + (selftrans.position.x * 2);
        }
        if (mousepos2.x > 2.454f)
        {
            mousepos2.x = 2.454f;
        }
        if (mousepos2.x < -2.462f)
        {
            mousepos2.x = -2.462f;
        }
        if (mousepos2.y < -2.507f)
        {
            mousepos2.y = -2.507f;
        }
        if (mousepos2.y > 2.409f)
        {
            mousepos2.y = -2.409f;
        }

        if (!hasStriked && !positionset)
        {
            selftrans.position = new Vector2(myslider.value, startpos.y);
            //HandleCollision();
            // OnEnable(striker.gameobject);
        }
        if (Input.GetMouseButtonUp(0) && rigidbody.velocity.magnitude == 0 && positionset)
        {
            shootstriker();
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (!positionset)
                {
                    positionset = true;
                }
            }
        }



        if (positionset && rigidbody.velocity.magnitude == 0)
        {
            arrowdirection.SetActive(true);
            line.enabled = true;
            line.SetPosition(0, arrowpoint.position);   
            line.SetPosition(1, mousepos2);
          // StrikerBG.gameObject.SetActive(true);
            // Set the position of the StrikerBG game object
            //StrikerBG.position = new Vector3(selftrans.position.x, selftrans.position.y, StrikerBG.position.z);
           // StrikerBG.LookAt(mousepos2);




            float angle = AngleBetweenTwoPoints(arrowtransorm.position, mousepos2);
            arrowtransorm.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));

        }

        if (rigidbody.velocity.magnitude < 0.05f && rigidbody.velocity.magnitude != 0)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0f;

            strikerreset();
            board.GetComponent<gameplayer>().count++;
        }


        ////Increase or decrease the size of the StrikerBG game object
        //if (Input.GetMouseButtonUp(0))
        //{
        //    currentSize += sizeStep;
        //    StrikerBG.localScale = new Vector3(currentSize, currentSize, StrikerBG.localScale.z);
        //    currentPower += powerStep;
        //    //currentPower = Mathf.Max(currentPower, 21f);
        //}
        //else if (Input.GetMouseButtonDown(0))
        //{
        //    currentSize -= sizeStep;
        //    StrikerBG.localScale = new Vector3(currentSize, currentSize, StrikerBG.localScale.z);
        //    currentPower -= powerStep;
        //    currentPower = Mathf.Max(currentPower, 0f);
        //}


    }
    public void strikerreset()
    {
        rigidbody.velocity = Vector2.zero;
        hasStriked = false;
        positionset = false;
        line.enabled = true;
       // StrikerBG.gameObject.SetActive(true);

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    //void HandleCollision(GameObject gameObject)
    // {

    // }

    

    
}
