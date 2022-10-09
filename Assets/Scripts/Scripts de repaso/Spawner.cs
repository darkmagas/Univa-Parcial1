using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] int numberOfItems;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
           Vector3 position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f),
                Random.Range(0f, 0f));
            Instantiate(objectToBeSpawned, position, Quaternion.identity, parent);
            //PrefabUtility.InstantiatePrefab(objectToBeSpawned, position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


// OJO codigo y explicación en: https://www.youtube.com/watch?v=ycPhF_UyFo4
