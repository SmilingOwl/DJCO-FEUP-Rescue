using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeController : MonoBehaviour
{    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        CoffeeInstantiator.instance.RemoveCoffee(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Hero") {
            FindObjectOfType<AudioManager>().Play("powerUp");
            gameObject.SetActive(false);
            CoffeeInstantiator.instance.RemoveCoffee(gameObject);
            GameLogic.instance.SpeedUp();
        }
    }
}
