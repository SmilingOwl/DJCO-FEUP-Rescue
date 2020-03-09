using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> benchPool;
    public List<GameObject> pcPool;
    public List<GameObject> trapPool;
    public List<GameObject> dustbinPool;
    public List<GameObject> applePool;
    public List<GameObject> coffeePool;
    public List<GameObject> bombPool;
    public GameObject bench;
    public GameObject pc;
    public GameObject trap;
    public GameObject dustbin;
    public GameObject apple;
    public GameObject coffee;
    public GameObject bomb;
    public int pcAmount = 6; 
    public int benchAmount = 2;
    public int trapAmount = 3;
    public int dustbinAmount = 3;
    public int appleAmount = 1;
    public int coffeeAmount = 1;
    public int bombAmount = 1;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        benchPool = new List<GameObject>();
        for(int i = 0; i < benchAmount || i < trapAmount || i < dustbinAmount || i < pcAmount || i < appleAmount || i < coffeeAmount || i < bombAmount; i++) {
            if(i < benchAmount) {
                GameObject obj = (GameObject) Instantiate(bench);
                obj.SetActive(false); 
                benchPool.Add(obj);
            }
            if(i < trapAmount) {
                GameObject obj = (GameObject) Instantiate(trap);
                obj.SetActive(false); 
                trapPool.Add(obj);
            }
            if(i < dustbinAmount) {
                GameObject obj = (GameObject) Instantiate(dustbin);
                obj.SetActive(false); 
                dustbinPool.Add(obj);
            }
            if (i < pcAmount)
            {
                GameObject obj = (GameObject)Instantiate(pc);
                obj.SetActive(false);
                pcPool.Add(obj);
            }
            if (i < appleAmount)
            {
                GameObject obj = (GameObject)Instantiate(apple);
                obj.SetActive(false);
                applePool.Add(obj);
            }
            if (i < coffeeAmount)
            {
                GameObject obj = (GameObject)Instantiate(coffee);
                obj.SetActive(false);
                coffeePool.Add(obj);
            }
            if (i < bombAmount)
            {
                GameObject obj = (GameObject)Instantiate(bomb);
                obj.SetActive(false);
                bombPool.Add(obj);
            }
        }
    }

    public GameObject GetObject(string obj) {
        List<GameObject> pool = new List<GameObject>();
        if(obj == "bench") {
            pool = benchPool;
        } else if(obj == "trap") {
            pool = trapPool;
        } else if(obj == "dustbin") {
            pool = dustbinPool;
        } else if(obj == "pc") {
            pool = pcPool;
        } else if(obj == "apple") {
            pool = applePool;
        } else if(obj == "coffee") {
            pool = coffeePool;
        }else if(obj == "bomb") {
            pool = bombPool;
        }

        for (int i = 0; i < pool.Count; i++) {
            if (!pool[i].activeInHierarchy) {
                return pool[i];
            }
        }
        return null;
    }
}
