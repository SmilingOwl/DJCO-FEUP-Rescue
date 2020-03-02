using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInstantiator : MonoBehaviour
{
    public int activeTraps = 0;
    public static TrapInstantiator instance;

    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeTraps = 0;
    }

    public void RemoveTrap(GameObject obstacle) {
        activeTraps--;
        ObstacleController.instance.RemoveObstacle(obstacle);
    }
    
    void AddTrap() {
        GameObject trap = ObjectPool.instance.GetTrap();
        if (trap != null) {
            if(ObstacleController.instance.AddObstacle(trap)){
                activeTraps++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ObjectPool.instance.trapPool.Count; i++) {
            if (ObjectPool.instance.trapPool[i].activeInHierarchy) {
                ObjectPool.instance.trapPool[i].transform.position -= new Vector3(Time.deltaTime * ObstacleController.instance.obstacleVelocity, 0f, 0f);
            }
        }
        if(activeTraps < ObjectPool.instance.trapAmount && Random.Range(0, 200) == 0) {
            this.AddTrap();
        }
    }
}
