using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInstantiator : MonoBehaviour
{
    int activeBomb;
    public static BombInstantiator instance;
    bool appeared;

    void Awake()
    {
        instance = this;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        activeBomb = 0;
        appeared = false;
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
                appeared = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!appeared && activeBomb < ObjectPool.instance.bombAmount && Random.Range(0, 1000) == 0)
        {
            this.AddBomb();
        }
    }
}
