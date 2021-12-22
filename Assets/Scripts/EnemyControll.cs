using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public static EnemyControll Instance;
    
    [SerializeField]
    float time;

    Vector3 resetPos;

    private void Awake()
    {
        Instance = this;
        resetPos = transform.position;
    }

    public void PlayGame() 
    {
        StartCoroutine(MovementEnemy());
    }

    IEnumerator MovementEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            this.transform.position += new Vector3(0, .3f, 0);
        }

    }

    public void RestartGame() 
    {
        transform.position = resetPos;
    }
}
