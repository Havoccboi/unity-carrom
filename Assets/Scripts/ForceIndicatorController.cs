
using System.Collections;
using UnityEngine;


public class ForceIndicatorController : MonoBehaviour
{
    public float maxForce = 10f; // maximum force that can be applied to striker
    public float forceIncrement = 1f; // amount to increase/decrease force by
    public GameObject dottedLinePrefab; // prefab for dotted line
    public GameObject circlePrefab; // prefab for circle

    private GameObject dottedLine; // reference to active dotted line
    private GameObject circle; // reference to active circle
    private Vector3 startPosition; // starting position of striker
    private Vector3 endPosition; // ending position of striker
    private float currentForce = 0f; // current force applied to striker

    void Start()
    {
        startPosition = transform.position; // set starting position
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse button clicked
        {
            startPosition = transform.position; // set starting position
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // set ending position
            endPosition.z = 0f; // make sure z-coordinate is 0

            currentForce = 0f; // reset current force
            if (dottedLine != null) Destroy(dottedLine); // destroy any existing dotted line
            if (circle != null) Destroy(circle); // destroy any existing circle

            // calculate and display dotted line
            Vector3 direction = (endPosition - startPosition).normalized;
            float distance = Vector3.Distance(startPosition, endPosition);
            dottedLine = Instantiate(dottedLinePrefab, startPosition, Quaternion.identity);
            dottedLine.transform.right = direction;
            dottedLine.GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(distance, 1f);

            // calculate and display circle
            float radius = Mathf.Clamp(distance / 2f, 0f, 1f);
            circle = Instantiate(circlePrefab, endPosition, Quaternion.identity);
            circle.transform.localScale = new Vector3(radius, radius, 1f);
        }

        if (Input.GetMouseButton(0)) // left mouse button held down
        {
            float distance = Vector3.Distance(startPosition, endPosition);
            currentForce = Mathf.Clamp(distance, 0f, maxForce); // calculate current force
            dottedLine.GetComponent<LineRenderer>().material.mainTextureOffset = new Vector2(-Time.time * 2f, 0f); // animate dotted line
        }

        if (Input.GetMouseButtonUp(0)) // left mouse button released
        {
            // apply force to striker
            Vector3 direction = (endPosition - startPosition).normalized;
            GetComponent<Rigidbody2D>().AddForce(direction * currentForce, ForceMode2D.Impulse);

            // destroy dotted line and circle
            if (dottedLine != null) Destroy(dottedLine);
            if (circle != null) Destroy(circle);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) // increase force
        {
            currentForce = Mathf.Clamp(currentForce + forceIncrement, 0f, maxForce);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) // decrease force
        {
            currentForce = Mathf.Clamp(currentForce - forceIncrement, 0f, maxForce);
        }
    }
}