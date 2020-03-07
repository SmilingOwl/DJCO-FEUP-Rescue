using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeInstantiator : MonoBehaviour
{
    public int activeCoffee = 0;
    public static CoffeeInstantiator instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeCoffee = 0;
    }

    public void RemoveCoffee(GameObject collectable)
    {
        activeCoffee--;
        ObstacleController.instance.RemoveCollectable(collectable);
    }

    void AddCoffee()
    {
        GameObject coffee = ObjectPool.instance.GetObject("coffee");
        if (coffee != null)
        {
            Physics2D.IgnoreCollision(Thief.instance.GetComponent<Collider2D>(), coffee.GetComponent<Collider2D>());   
            if (ObstacleController.instance.AddCollectable(coffee))
            {
                activeCoffee++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeCoffee < ObjectPool.instance.coffeeAmount && Random.Range(0, 400) == 0)
        {
            this.AddCoffee();
        }
    }
}
