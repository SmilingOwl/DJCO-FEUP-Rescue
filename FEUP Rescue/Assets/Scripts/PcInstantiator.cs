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
        ObstacleController.instance.RemoveObstacle(obstacle);
    }

    void AddPc()
    {
        GameObject pc = ObjectPool.instance.GetPc();
        if (pc != null)
        {
            if (ObstacleController.instance.AddObstacle(pc))
            {
                activePc++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ObjectPool.instance.pcPool.Count; i++)
        {
            if (ObjectPool.instance.pcPool[i].activeInHierarchy)
            {
                ObjectPool.instance.pcPool[i].transform.position -= new Vector3(Time.deltaTime * ObstacleController.instance.obstacleVelocity, 0f, 0f);
            }
        }
        if (activePc < ObjectPool.instance.pcAmount && Random.Range(0, 200) == 0)
        {
            this.AddPc();
        }
    }
}
