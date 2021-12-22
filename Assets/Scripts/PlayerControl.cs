using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    [SerializeField]
    float speed;

    Vector3 resetPos;

    private void Awake()
    {
        Instance = this;
        resetPos = transform.position;
    }

    public void MovementPlayer() 
    {
        transform.position += new Vector3(0, speed, 0);
    }
    public void ResetGame()
    {

        transform.position = resetPos;
        
    }
}
