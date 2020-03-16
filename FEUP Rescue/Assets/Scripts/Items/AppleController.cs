using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{  
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        AppleInstantiator.instance.RemoveApple(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Hero") {
            FindObjectOfType<AudioManager>().Play("gainLife");
            gameObject.SetActive(false);
            AppleInstantiator.instance.RemoveApple(gameObject);
            collider.gameObject.GetComponent<PlayerHealth>().GetLife();
        }
    }
}
