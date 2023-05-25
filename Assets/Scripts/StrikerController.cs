using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerController : MonoBehaviour
{
    public Transform StrikerBG;
    public float maxForcePower = 1.3f;
    public float forceIncreaseRate = 0.1f;
    public float forceDecreaseRate = 0.1f;

    private bool isDragging;
    private float dragStartTime;
    private float forcePower;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDragging();

        }

        UpdateForcePower();
    }

    private void StartDragging()
    {
        isDragging = true;
        dragStartTime = Time.time;
        forcePower = 0.21f;
    }

    private void StopDragging()
    {
        isDragging = false;
        forcePower = 0.21f;
        forcePower = Mathf.Clamp(forcePower, 0, maxForcePower);

    }

    private void UpdateForcePower()
    {
        if (isDragging)
        {
            float mouseY = -(mainCamera.ScreenToWorldPoint(Input.mousePosition).y);
            forcePower = Mathf.Clamp((mouseY + 1.0f) / 2.0f * maxForcePower, 0, maxForcePower);
            // forcePower = Mathf.Max(0, forcePower - forceDecreaseRate * Time.deltaTime);
            StrikerBG.localScale = Vector3.one * forcePower;
        }
        else
        {
            //float mouseY = mainCamera.ScreenToWorldPoint(Input.mousePosition).y;
            //forcePower = Mathf.Clamp((mouseY + 1.0f) / 2.0f * maxForcePower, 0, maxForcePower);
            forcePower = Mathf.Max(0, forcePower - forceDecreaseRate * Time.deltaTime);
            StrikerBG.localScale = Vector3.one * forcePower;

        }
    }

}