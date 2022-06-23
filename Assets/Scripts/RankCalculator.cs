using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RankCalculator : MonoBehaviour
{
    public Transform[] opponents;
    public Transform player;
    public TMP_Text textTMP;
    public int rank = 11;

    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if (player.position.x > opponents[i].position.x )
            {
                if(opponents[i].tag == "ahead")
                {
                    rank--;
                }
                opponents[i].tag = "back";
            }
            if (player.position.x < opponents[i].position.x)
            {
                if (opponents[i].tag == "back")
                {
                    rank++; 
                }
                opponents[i].tag = "ahead";
            }
        }
        textTMP.text = "Your rank: " + rank.ToString();
    }
    

}
