using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration _waveConfiguration;
    [SerializeField] private List<string> _pathNames = new ();
    private List<Transform> _spawnpoints = new ();
    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _mediumEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;
    private int _currentWave = 0;

    private void Start()
    {
        for (int i = 0; i < _pathNames.Count; i++)
        {
            var waypointParent = GameObject.Find(_pathNames[i]);
            if (waypointParent != null)
            {
                var firstChild = waypointParent.transform.GetChild(0);
                if(firstChild != null)
                {
                    _spawnpoints.Add(firstChild);
                }
            }
        }
        StartCoroutine(routine: CreateWave());
    }
    




    private IEnumerator CreateWave()
    {
        if(_waveConfiguration._waves.Count <= _currentWave) yield break;
        var wave = _waveConfiguration._waves[_currentWave];
        yield return StartCoroutine(SpawnEnemies(wave.weakEnemy, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.mediumEnemy, _mediumEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.strongEnemy, _strongEnemyPrefab));
        _currentWave ++;
        StartCoroutine(CreateWave());
    }


    private IEnumerator SpawnEnemies(int amount, GameObject preFab)
    {
        for(int i = 0; i < amount; i++)
        {
            var randomSpawn = Random.Range(0, _pathNames.Count);
            Instantiate(preFab,_spawnpoints[randomSpawn].position,Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

}

