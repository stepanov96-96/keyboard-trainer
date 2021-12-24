using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public static EnemyControll Instance;

    [SerializeField]
    float  min, max;

    float time;

    Vector3 resetPos;

    private void Awake()
    {
        Instance = this;
        resetPos = transform.position;
    }

    public void PlayGame() 
    {
        time = Random.Range(min, max);
        StartCoroutine(MovementEnemy());
    }

    IEnumerator MovementEnemy()
    {
        while (GameController.resetGame)
        {
            yield return new WaitForSeconds(time);
            this.transform.position += new Vector3(0, .3f, 0);
        }

    }

    public void RestartGame() 
    {
        StopCoroutine(MovementEnemy());
        transform.position = resetPos;
        StartCoroutine(MovementEnemy());
    }
}
