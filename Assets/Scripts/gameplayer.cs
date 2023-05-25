using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplayer : MonoBehaviour
{
    public int count = 0;
    public GameObject player1;
    public GameObject player2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count % 2 == 0)
        {
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else
        {
            player1.SetActive(false);
            player2.SetActive(true);
        }
    }
}
