using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Magas.Utilities;
using System.Security.Claims;
using System.Security.Principal;



public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration _waveConfiguration;
    [SerializeField] private List<string> _pathNames = new();
    private List<Transform> _spawnPoints = new();
    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _mediumEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;
    [SerializeField] private GameObject _bossEnemyPrefab;
    [SerializeField] private float _timeToNextWave = 5f;
    private int _currentWave = 0;

    private void Start()
    {

        for (int i = 0; i < _pathNames.Count; i++)
        {

            var wayPointParent = GameObject.Find(_pathNames[i]);
            if(wayPointParent != null)
            {
                var firstChild = wayPointParent.transform.GetChild(0);
                if(firstChild != null)
                {
                    _spawnPoints.Add(firstChild);
                }
            }

        }

        StartCoroutine(routine: CreateWave());

    }

    private IEnumerator CreateWave()
    {

        if (_waveConfiguration._waves.Count <= _currentWave) yield break;
        var wave = _waveConfiguration._waves[_currentWave];
        yield return StartCoroutine(routine:SpawnEnemies(wave.weakEnemy, _weakEnemyPrefab));
        yield return StartCoroutine(routine: SpawnEnemies(wave.mediumEnemy, _mediumEnemyPrefab));
        yield return StartCoroutine(routine: SpawnEnemies(wave.strongEnemy, _strongEnemyPrefab));
        yield return StartCoroutine(routine: SpawnEnemies(wave.bossEnemy, _bossEnemyPrefab));
        _currentWave++;
       
        while(GameManager.Instance.EnemyCount > 0)
        {
            yield return null;
        }
        yield return new WaitForSeconds(_timeToNextWave);
        StartCoroutine(routine:CreateWave());

    }

    private IEnumerator SpawnEnemies(int amount, GameObject prefab)
    {

        for (int i = 0; i < amount; i++)
        {

            var randomSpawn = Random.Range(0, _pathNames.Count);
            //Instantiate(prefab, _spawnPoints[randomSpawn].position,Quaternion.identity);
            EventDispatcher.Dispatch(
                signal: new SpawnObject(prefab,
                null, _spawnPoints[randomSpawn].position,
                Quaternion.identity,
                (gameObjectSpawn) =>
                {
                    int rs = randomSpawn;
                    string pathName = _pathNames[rs];
                    gameObjectSpawn.GetComponent<FollowPathMovement>().InitEnemy(pathName);
                }));
            yield return new WaitForSeconds(1);

        }

    }
}
