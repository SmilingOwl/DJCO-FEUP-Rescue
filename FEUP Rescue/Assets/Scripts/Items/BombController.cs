using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
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
        BombInstantiator.instance.RemoveBomb(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            gameObject.SetActive(false);
            BombInstantiator.instance.RemoveBomb(gameObject);
            //add UI
        }
    }
}
