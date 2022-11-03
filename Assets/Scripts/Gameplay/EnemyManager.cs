using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Magas.Utilities;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration _waveConfiguration;
    [SerializeField] private List<string> _pathNames = new ();
    private List<Transform> _spawpoints = new ();
    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _StrongEnemyPrefab;
    [SerializeField] private float _timeToNextWave = 5f;
    private int _currentWave = 0;

    private void Start()
    {
        for (int i = 0; i < _pathNames.Count; i++)
        {
            var waypointParent = GameObject.Find(_pathNames[i]);
            if (waypointParent != null)
            {
                var firstChild = waypointParent.transform.GetChild(0);
                if (firstChild != null)
                {
                    _spawpoints.Add(firstChild);
                }


            }
        }
        StartCoroutine(CreateWave());
    }

    private IEnumerator CreateWave()
    {
        if (_waveConfiguration._waves.Count <= _currentWave) yield break;
        var wave = _waveConfiguration._waves[_currentWave];
        yield return StartCoroutine(SpawnEnemies(wave.weakEnemy, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.midEnemy, _midEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.strongEnemy, _StrongEnemyPrefab));
        _currentWave++;

        while (GameManager.Instance.EnemyCount > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(_timeToNextWave);
        StartCoroutine(CreateWave());
    }
     private IEnumerator SpawnEnemies(int amount, GameObject prefab)
    {
        for (int i = 0; i < amount; i++)
        {
            var randomSpawn = Random.Range(0, _pathNames.Count);
            //Instantiate(prefab,_spawpoints[randomSpawn].position, Quaternion.identity);
            EventDispatcher.Dispatch(new SpawnObject(prefab, null, _spawpoints[randomSpawn].position, Quaternion.identity, (gameObjectSpawn)=> 
            {
                int rs = randomSpawn;
                string pathName = _pathNames[rs];
                gameObjectSpawn.GetComponent<TrabajoClase2>().InitEnemy(pathName);
            }));
            yield return new WaitForSeconds(1);
        }
    }

}
