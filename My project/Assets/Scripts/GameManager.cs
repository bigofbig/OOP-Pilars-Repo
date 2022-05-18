using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]GameObject rabbit;
    [SerializeField]GameObject Fox;
    [SerializeField]GameObject Eagle;
    [SerializeField]GameObject tree;
    int rabbitCount=8;
    int FoxCount = 4;
    int EagleCount = 3;
    int TreeCount = 5;
    

    private void Start()
    {

        GameObjectSpawner(rabbit, rabbitCount);
        GameObjectSpawner(Fox, FoxCount);
        GameObjectSpawner(Eagle, EagleCount);
        GameObjectSpawner(tree, TreeCount);

    }
    private void Update()
    {

        
    }
    void GameObjectSpawner(GameObject spawnGameObject,int spawnCount)
    {
        

        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(spawnGameObject, RandomPos(), RandomRotation());
        }
        

    }
    Vector3 RandomPos()
    {
        float zBoundry = Random.Range(-9, 9);
        float xBoundry = Random.Range(-13, 13);

        Vector3 randomPos = new Vector3(xBoundry, 0, zBoundry);
        



        return randomPos;
    }
    Quaternion RandomRotation()
    {
        Quaternion randomRotate = Quaternion.Euler(0, Random.Range(0.0f, 360f),0 );
        return randomRotate;
    }

    
    
}
