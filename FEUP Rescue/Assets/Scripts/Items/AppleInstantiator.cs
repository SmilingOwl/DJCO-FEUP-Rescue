using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleInstantiator : MonoBehaviour
{
    public int activeApples = 0;
    public static AppleInstantiator instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeApples = 0;
    }

    public void RemoveApple(GameObject collectable)
    {
        activeApples--;
        ObstacleController.instance.RemoveCollectable(collectable);
    }

    void AddApple()
    {
        GameObject apple = ObjectPool.instance.GetObject("apple");
        if (apple != null)
        {
            if (ObstacleController.instance.AddCollectable(apple))
            {
                activeApples++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeApples < ObjectPool.instance.appleAmount && Random.Range(0, 500) == 0)
        {
            this.AddApple();
        }
    }
}
