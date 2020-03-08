using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInstantiator : MonoBehaviour
{
    public int activeBomb = 0;
    public static BombInstantiator instance;

    void Awake()
    {
        instance = this;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        activeBomb = 0;
    }

    public void RemoveBomb(GameObject collectable)
    {
        activeBomb--;
        ObstacleController.instance.RemoveCollectable(collectable);
    }

    void AddBomb()
    {
        GameObject bomb = ObjectPool.instance.GetObject("bomb");
        if (bomb != null)
        {
            Physics2D.IgnoreCollision(Thief.instance.GetComponent<Collider2D>(), bomb.GetComponent<Collider2D>());
            if (ObstacleController.instance.AddCollectable(bomb))
            {
                activeBomb++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeBomb < ObjectPool.instance.bombAmount && Random.Range(0, 400) == 0)
        {
            this.AddBomb();
        }
    }
}
