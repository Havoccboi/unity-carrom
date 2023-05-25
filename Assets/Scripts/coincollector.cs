using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class coincollector : MonoBehaviour
{
    public int point = 0;
    public GameObject striker1;
    public GameObject striker_2;
   // public TMP_Text points;
    public GameObject text1;
    public GameObject text2;
    public GameObject board;
    public AudioSource audioPlayer;
    public int nocoins = 0;
    int decideno = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //   if (textpoint != null)
        // {
        //     textpoint.text = counter.ToString();
        // }

    }


  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            Destroy(collision.gameObject);
            
            decideno = board.GetComponent<gameplayer>().count;

            if (decideno % 2 == 0)
            {
                audioPlayer.Play();
                text1.GetComponent<coincollpoint>().counter = text1.GetComponent<coincollpoint>().counter + 10;
                //StartCoroutine(OnTriggerEnter2DCoroutine(collision));
                striker1.GetComponent<striker>().strikerreset();

            }
            else
            {
                audioPlayer.Play();
                text2.GetComponent<coincollpoint>().counter = text2.GetComponent<coincollpoint>().counter + 10;
                //striker_2.GetComponent<striker2>().strikerreset();
                //StartCoroutine(OnTriggerEnter2DCoroutine(collision));
                striker_2.GetComponent<striker2>().strikerreset();
            }



        }



    }

    //private IEnumerator OnTriggerEnter2DCoroutine(Collider2D collision)
    //{
    //    yield return new WaitForSeconds(0.5f);

    //}




}
