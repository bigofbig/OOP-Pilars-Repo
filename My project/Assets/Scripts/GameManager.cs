using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]GameObject rabbit;
    [SerializeField]GameObject Fox;
    [SerializeField]GameObject Eagle;
    [SerializeField]GameObject tree;
    int rabbitCount ;
    int FoxCount;
    int EagleCount ;
    int TreeCount;

    private void Awake()
    {
        SetInputValues();
        SpawnPrefabs();
    }
  
 
 

    void SetInputValues()
    {
        if (MainManager.mainManagerScript != null)
        {
            MainManager scriptAddress = MainManager.mainManagerScript;//this line is for shorten
            rabbitCount = scriptAddress.rabitNumber;
            FoxCount = scriptAddress.foxNumber;
            EagleCount = scriptAddress.eagleNumber;
            TreeCount = scriptAddress.treeNumber;
        }
        //using "if" statement to prevent error for when scene is opened individually
      

    }
    void SpawnPrefabs()
    {
        GameObjectSpawner(rabbit, rabbitCount);
        GameObjectSpawner(Fox, FoxCount);
        GameObjectSpawner(Eagle, EagleCount);
        GameObjectSpawner(tree, TreeCount);
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
