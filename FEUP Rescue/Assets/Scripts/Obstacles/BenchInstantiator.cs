using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchInstantiator : MonoBehaviour
{
    public int activeBenches = 0;
    public static BenchInstantiator instance;

    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeBenches = 0;
    }

    public void RemoveBench(GameObject obstacle) {
        activeBenches--;
        ObstacleController.instance.RemoveObstacle(obstacle);
    }
    
    void AddBench() {
        GameObject bench = ObjectPool.instance.GetObject("bench");
        if (bench != null) {
            if(ObstacleController.instance.AddObstacle(bench)){
                activeBenches++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(activeBenches < ObjectPool.instance.benchAmount && Random.Range(0, 50) == 0) {
            this.AddBench();
        }
    }
}
