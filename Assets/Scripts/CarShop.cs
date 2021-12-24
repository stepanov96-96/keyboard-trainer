using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarShop : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    [SerializeField]
    Image cars;

    [SerializeField]
    GameObject buttonBuy;

    // создание префабов наград
    public void BuyCar(int price)
    {
        if (price<=GameController.level)
        {
            Player.GetComponent<SpriteRenderer>().sprite = cars.sprite;
            buttonBuy.GetComponent<Graphic>().color = Color.green;
        }
    }
}
