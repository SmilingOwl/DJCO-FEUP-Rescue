using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcController : MonoBehaviour
{
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        PcInstantiator.instance.RemovePc(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider) {
         if(collider.gameObject.tag == "Hero") {
            FindObjectOfType<AudioManager>().Play("collectPcs");
            gameObject.SetActive(false);
            PcInstantiator.instance.RemovePc(gameObject);
            GameLogic.instance.IncrementPoints();
        }
    }
}

