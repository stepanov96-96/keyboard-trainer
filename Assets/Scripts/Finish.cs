using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    
    int nextPlayer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (nextPlayer == 0)
                GameController.Instance.NextLevel(true);
            else
                GameController.Instance.NextLevel(false);

        }

        if (other.tag == "Enemy1")
            nextPlayer++;

        if (other.tag == "Enemy2")
            nextPlayer++;


    }



}
