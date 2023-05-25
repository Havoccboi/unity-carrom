using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coincollpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter = 0;
    public TMP_Text textpoint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textpoint = GetComponent<TMP_Text>();
        textpoint.text = counter.ToString();
    }
}
