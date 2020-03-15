using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInstantiator : MonoBehaviour
{
    public int activePc = 0;
    public static PcInstantiator instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activePc = 0;
    }

    public void RemovePc(GameObject obstacle)
    {
        activePc--;
        ObstacleController.instance.RemoveCollectable(obstacle);
    }

    void AddPc()
    {
        GameObject pc = ObjectPool.instance.GetObject("pc");
        if (pc != null)
        {
            Physics2D.IgnoreCollision(Thief.instance.GetComponent<Collider2D>(), pc.GetComponent<Collider2D>());
            if (ObstacleController.instance.AddCollectable(pc))
            {
                activePc++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activePc < ObjectPool.instance.pcAmount && Random.Range(0, 20) == 0)
        {
            this.AddPc();
        }
    }
}
