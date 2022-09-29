using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Magas.Utilities;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration _waveConfiguration;
    [SerializeField] private List<string> _pathnames = new ();
    private List<Transform> _spawnpoints = new ();
    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;
    private int _currentWave = 0;

    private void Start()
    {
        for (int i = 0; i < _pathnames.Count; i++)
        {
            var waypointParent = GameObject.Find(_pathnames[i]);
            if (waypointParent != null)
            {
                var firstChild = waypointParent.transform.GetChild(0);
                if (waypointParent != null)
                {
                    _spawnpoints.Add(firstChild);

                }
            }
        }

        StartCoroutine(CreateWave());//para mandar a llamar el create wave
    }


    private IEnumerator CreateWave() //para saber en que wave nos encontramos
    {
        if (_waveConfiguration._waves.Count <= _currentWave) yield break; //esto es para que ya no haga nada
        var wave = _waveConfiguration._waves[_currentWave];
        yield return StartCoroutine(SpawnEnemies(wave.waveEnemy, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.mediumEnemy, _midEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.strongestEnemy, _strongEnemyPrefab));


    }

    private IEnumerator SpawnEnemies(int amount, GameObject prefab) //para spawnear a todos tus enemigos
    {
        for (int i = 0; i < amount; i++)
        {
            var randomSpawn = Random.Range(0, _pathnames.Count);
            // Instantiate(prefab, _spawnpoints[randomSpawn].position, Quaternion.identity);
            EventDispatcher.Dispatch(
                new SpawnObject(prefab,
                null, _spawnpoints[randomSpawn].position,
                Quaternion.identity,
                (gameObjectspawn) =>
                {
                    int rs = randomSpawn;
                    string pathName = _pathnames[rs];
                    gameObjectspawn.GetComponent<FollowPathMovement>().InitEnemy(pathName);
                    }));
        
            yield return new WaitForSeconds(1); //para esperarse unos segundos antes del siguiente
          
        }
    }

}
