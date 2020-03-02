using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int obstacleAmount = 4;
    public float obstacleVelocity = 11f;
    public static ObstacleController instance;
    public List<GameObject> activeObstacles;
    public Vector3 initialPosition = new Vector3(22f, -6f, 0f);
    public float spaceBetween = 0f;

    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeObstacles = new List<GameObject>();
    }

    public void RemoveObstacle(GameObject obstacle) {
        activeObstacles.Remove(obstacle);
    }

    public bool AddObstacle(GameObject obstacle) {
        if(!this.ScreenIsFull() && this.CanAddObstacle(obstacle)) {
            activeObstacles.Add(obstacle);
            obstacle.SetActive(true);
            obstacle.transform.position = initialPosition;
            return true;
        }
        return false;
    }

    public bool CanAddObstacle(GameObject obstacle) {
        
        for(int i = 0; i < activeObstacles.Count; i++) {
            float previousObstaclePosition = activeObstacles[i].GetComponent<SpriteRenderer>().bounds.size.x / 2.0f
                + activeObstacles[i].transform.position.x;
            float currentPosition = initialPosition.x - obstacle.GetComponent<SpriteRenderer>().bounds.size.x / 2.0f;
            if(currentPosition - previousObstaclePosition <= spaceBetween) {
                return false;
            }
        }
        return true;
    }

    public bool ScreenIsFull() {
        return activeObstacles.Count >= obstacleAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}