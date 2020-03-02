using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustbinInstantiator : MonoBehaviour
{
    public int activeDustbins = 0;
    public static DustbinInstantiator instance;

    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeDustbins = 0;
    }

    public void RemoveDustbin(GameObject obstacle) {
        activeDustbins--;
        ObstacleController.instance.RemoveObstacle(obstacle);
    }
    
    void AddDustbin() {
        GameObject dustbin = ObjectPool.instance.GetDustbin();
        if (dustbin != null) {
            if(ObstacleController.instance.AddObstacle(dustbin)){
                activeDustbins++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ObjectPool.instance.dustbinPool.Count; i++) {
            if (ObjectPool.instance.dustbinPool[i].activeInHierarchy) {
                ObjectPool.instance.dustbinPool[i].transform.position -= new Vector3(Time.deltaTime * ObstacleController.instance.obstacleVelocity, 0f, 0f);
            }
        }
        if(activeDustbins < ObjectPool.instance.dustbinAmount && Random.Range(0, 500) == 0) {
            this.AddDustbin();
        }
    }
}
