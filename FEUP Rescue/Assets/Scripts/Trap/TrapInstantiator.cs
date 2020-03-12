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
        GameObject trap = ObjectPool.instance.GetObject("trap");
        if (trap != null) {
            Physics2D.IgnoreCollision(Thief.instance.GetComponent<Collider2D>(), trap.GetComponent<Collider2D>());   
            if(ObstacleController.instance.AddObstacle(trap)){
                activeTraps++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(activeTraps < ObjectPool.instance.trapAmount && Random.Range(0, 100) == 0) {
            this.AddTrap();
        }
    }
}
