using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Magas.Utilities;

public class EnemyManger : MonoBehaviour
{
    [SerializeField] private WaveConfiguration _waveConfiguration;
    [SerializeField] private List<string> _pathName = new ();

    private List<Transform> _spawnpoints = new ();
    [SerializeField] private GameObject _weakEnemyPrefab; //no se tiene que llemar igual a los prefab
    [SerializeField] private GameObject _mediumEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;
    private int _currentWave = 0;

    private void Start()
    {
        for (int i = 0; i < _pathName.Count; i++)
        {
            var waypointParent = GameObject.Find(_pathName[i]);
            if (waypointParent != null)
            {
                var firstchild = waypointParent.transform.GetChild(0);
               if(firstchild != null)
                {
                    _spawnpoints.Add(firstchild);
                }
            }
        }
        StartCoroutine(CreateWave());// para comenzar las olas y progresion se pare
    }



    private IEnumerator CreateWave() //necesitamos saber en que wave nos encontramos, para que se crea un indice
    {
        if (_waveConfiguration._waves.Count <= _currentWave) yield break; //para cuando ya termines todo, se detiene todo, ya no hace nada
        var wave = _waveConfiguration._waves[_currentWave];
        yield return StartCoroutine(SpawnEnemies(wave.weakEnemy, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.mediumEnemy, _mediumEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.strongEnemy,_strongEnemyPrefab));
    }
    private IEnumerator SpawnEnemies(int amount, GameObject prefab)
    {
        for(int i =0; i<amount; i++)
        {
            var randomSpawn = Random.Range(0, _pathName.Count);
            //Instantiate(prefab,_spawnpoints[randomSpawn].position,Quaternion.identity);
            EventDispatcher.Dispatch(
                new SpawnObject(prefab,null,_spawnpoints[randomSpawn].position,Quaternion.identity,
                (gameObjectSpawn)=> {
                    int rs = randomSpawn;
                    string pathName = _pathName[rs];
                    gameObjectSpawn.GetComponent<FollowPathMovement>().InitEnemy(pathName);
                }));
            yield return new WaitForSeconds(1); //esperate ese cantidad de segundos
        }
    }
}
        

    
