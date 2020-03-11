using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        PcInstantiator.instance.RemovePc(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider) {
         if(collider.gameObject.tag == "Hero") {
            gameObject.SetActive(false);
            PcInstantiator.instance.RemovePc(gameObject);
            GameLogic.instance.IncrementPoints();
        }
    }
}

