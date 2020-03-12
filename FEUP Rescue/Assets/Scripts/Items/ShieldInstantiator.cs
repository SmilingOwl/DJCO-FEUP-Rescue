using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldInstantiator : MonoBehaviour
{
    public int activeShield = 0;
    public static ShieldInstantiator instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeShield = 0;
    }

    public void RemoveShield(GameObject collectable)
    {
        activeShield--;
        ObstacleController.instance.RemoveCollectable(collectable);
    }

    void AddShield()
    {
        GameObject shield = ObjectPool.instance.GetObject("shield");
        if (shield != null)
        {
            Physics2D.IgnoreCollision(Thief.instance.GetComponent<Collider2D>(), shield.GetComponent<Collider2D>());   
            if (ObstacleController.instance.AddCollectable(shield))
            {
                activeShield++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeShield < ObjectPool.instance.shieldAmount && Random.Range(0, 900) == 0)
        {
            this.AddShield();
        }
    }
}
