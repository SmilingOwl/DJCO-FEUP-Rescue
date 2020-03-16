using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour{
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        ShieldInstantiator.instance.RemoveShield(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Hero") {
            FindObjectOfType<AudioManager>().Play("powerUp");
            gameObject.SetActive(false);
            ShieldInstantiator.instance.RemoveShield(gameObject);
            GameLogic.instance.ProtectedWithShield();
        }
    }
}
