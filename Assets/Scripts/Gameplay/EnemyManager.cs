using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private WaveConfiguration waveConfiguration;
    [SerializeField] private List<string> _pathNames = new();
    private List<Transform> _spawnPoints = new();
    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject  _mediumEnemyPrefab;
    [SerializeField] private GameObject  _strongEnemyPrefab;
    [SerializeField] private GameObject  _bossEnemy1;
    private int _currentWave = 0;

    private void Start()
    {
        for(int i = 0; i < _pathNames.Count; i++)
        {
            var waypointParent = GameObject.Find(_pathNames[i]);

            if (waypointParent != null)
            {
                var firstChild = waypointParent.transform.GetChild(0);
                if(firstChild != null)
                {
                    _spawnPoints.Add(firstChild);
                }
            }

        }

        StartCoroutine(CreateWave());

    }

    private IEnumerator CreateWave()
    {

        if (waveConfiguration._waves.Count <= _currentWave) yield break;
        var wave = waveConfiguration._waves[_currentWave];

        yield return StartCoroutine(SpawnEnemys(wave.weakEnemy, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemys(wave.mediumEnemy, _mediumEnemyPrefab));
        yield return StartCoroutine(SpawnEnemys(wave.strongEnemy, _strongEnemyPrefab));
        yield return StartCoroutine(SpawnEnemys(wave.bossEnemy1, _bossEnemy1));
        _currentWave++;
        yield return new WaitForSeconds(10f);

        StartCoroutine(CreateWave());

       //yield return StartCoroutine(SpawnEnemys(wave.))

    }

    private IEnumerator SpawnEnemys(int amount, GameObject prefab)
    {
        for(int i = 0; i < amount; i++)
        {
            var randomSpawn = Random.Range(0, _pathNames.Count);
            Instantiate(prefab, _spawnPoints[randomSpawn].position,Quaternion.identity);
            yield return new WaitForSeconds(1);
        }


    }





}



