using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int obstacleAmount = 5;
    public int collectableAmount = 8;
    public float obstacleVelocity = 10.3f;
    public static ObstacleController instance;
    public List<GameObject> activeObstacles;
    public List<GameObject> activeCollectables;
    public Vector3 initialObstaclePosition = new Vector3(22f, -6f, 0f);
    public Vector3 initialCollectablePosition = new Vector3(20f, -2.5f, 0f);
    public float spaceBetween = 5f;
    public float spaceBetweenCollectables = 0.5f;

    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeObstacles = new List<GameObject>();
        activeCollectables = new List<GameObject>();
    }

    public void RemoveObstacle(GameObject obstacle) {
        activeObstacles.Remove(obstacle);
    }

    public bool AddObstacle(GameObject obstacle) {
        if(!this.ScreenIsFullObstacles() && this.CanAddObstacle(obstacle, false)) {
            activeObstacles.Add(obstacle);
            obstacle.SetActive(true);
            Vector3 pos = initialObstaclePosition;
            obstacle.transform.position = pos;
            return true;
        }
        return false;
    }

    public bool CanAddObstacle(GameObject obstacle, bool isThief) {
        
        for(int i = 0; i < activeObstacles.Count; i++) {
            float previousObstaclePosition = activeObstacles[i].GetComponent<SpriteRenderer>().bounds.size.x / 2.0f
                + activeObstacles[i].transform.position.x;
            float currentPosition = initialObstaclePosition.x - obstacle.GetComponent<SpriteRenderer>().bounds.size.x / 2.0f;
            if(currentPosition - previousObstaclePosition <= spaceBetween) {
                return false;
            }
        }
        if(!isThief){
            float thiefPos = Thief.instance.GetComponent<SpriteRenderer>().bounds.size.x / 2.0f
                + Thief.instance.transform.position.x;
            float currentPos = initialObstaclePosition.x - obstacle.GetComponent<SpriteRenderer>().bounds.size.x / 2.0f;
            if(currentPos - thiefPos <= Thief.instance.deltaPos) {
                return false;
            }
        }
        return true;
    }

    public bool ScreenIsFullObstacles() {
        return activeObstacles.Count >= obstacleAmount;
    }

    public bool ScreenIsFullCollectables() {
        return activeCollectables.Count >= collectableAmount;
    }

    public void RemoveCollectable(GameObject collectable) {
        activeCollectables.Remove(collectable);
    }

    public bool AddCollectable(GameObject collectable) {
        if(!this.ScreenIsFullCollectables()) {
            float y_pos = this.CanAddCollectable(collectable);
            if(y_pos == -10f)
                return false;
            activeCollectables.Add(collectable);
            collectable.SetActive(true);
            Vector3 pos = initialCollectablePosition;
            pos.y = y_pos;
            collectable.transform.position = pos;
            return true;
        }
        return false;
    }

    public float CanAddCollectable(GameObject collectable) {
        
        for(int i = 0; i < activeCollectables.Count; i++) {
            float previousCollectablePosition = activeCollectables[i].GetComponent<SpriteRenderer>().bounds.size.x / 2.0f
                + activeCollectables[i].transform.position.x;
            float currentPosition = initialCollectablePosition.x - collectable.GetComponent<SpriteRenderer>().bounds.size.x / 2.0f;
            if(currentPosition - previousCollectablePosition <= spaceBetweenCollectables) {
                return -10f;
            }
        }

        for(int i = 0; i < activeObstacles.Count; i++) {
            float obstacleInitPosition = - activeObstacles[i].GetComponent<SpriteRenderer>().bounds.size.x / 2.0f
                + activeObstacles[i].transform.position.x;
            float obstaclePosition = activeObstacles[i].GetComponent<SpriteRenderer>().bounds.size.x / 2.0f
                + activeObstacles[i].transform.position.x;
            float currentPosition = initialCollectablePosition.x - collectable.GetComponent<SpriteRenderer>().bounds.size.x / 2.0f;
            float currentFinPosition = initialCollectablePosition.x + collectable.GetComponent<SpriteRenderer>().bounds.size.x / 2.0f;
            if(!(currentFinPosition < obstacleInitPosition - 2f || currentPosition > obstaclePosition + 2f)) {
                if(activeObstacles[i].tag == "Trap"){
                    return -10f;
                }
                return 3.3f;
            }
        }

        return initialCollectablePosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < activeObstacles.Count; i++)
        {
            if (activeObstacles[i].activeInHierarchy)
            {
                activeObstacles[i].transform.position -= new Vector3(Time.deltaTime * obstacleVelocity, 0f, 0f);
            }
        }

        for (int i = 0; i < activeCollectables.Count; i++)
        {
            if (activeCollectables[i].activeInHierarchy)
            {
                activeCollectables[i].transform.position -= new Vector3(Time.deltaTime * obstacleVelocity, 0f, 0f);
            }
        }

        if(!Thief.instance.gameObject.activeInHierarchy && this.CanAddObstacle(Thief.instance.gameObject, true)) {
            Thief.instance.InitThief();
        }
    }
}