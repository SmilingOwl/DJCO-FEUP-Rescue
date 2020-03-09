using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public static BombAttack instance;

    void Awake() {
        instance = this;
    }

    public void Attack() {
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(Thief.instance.transform.position.x, 11f, 0f);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Thief")
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<Animator>().SetTrigger("Explode");
        }
    }
}
