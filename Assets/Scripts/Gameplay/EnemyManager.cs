using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Magas.Utilities;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration _waveConfiguration;
    [SerializeField] private List<string> _pathWaves = new();
    private List<Transform> _spawpoints = new();
    [SerializeField] private GameObject _weakEnemyPrefab; //no se tiene que llamar igual que los prefabs
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;
    private int _currentWave = 0; //para el indice de waves

    private void Start()
    {
        for (int i = 0; i < _pathWaves.Count; i++)
        {
            var wayPointParent = GameObject.Find(_pathWaves[i]);
            if (wayPointParent != null)
            {
                var firstChild = wayPointParent.transform.GetChild(0);
                if (firstChild != null)
                {
                    _spawpoints.Add(firstChild);
                }
            }
        }

        StartCoroutine(CreateWave()); //para comenzar las olas y progresivamente se pare.
    }

    private IEnumerator CreateWave() //necesitamos saber en que wave os encontramos, para es se crea un indice
    {
        if (_waveConfiguration._waves.Count <= _currentWave) yield break; //para que al llegar al ultimo wave ya no haga nada.
        var wave = _waveConfiguration._waves[_currentWave];
        yield return StartCoroutine(SpawnEnemies(wave.weakEnemy, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.mediumEnemy, _midEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.strongEnemy, _strongEnemyPrefab));
        _currentWave++;
        yield return new WaitForSeconds(10f);
        StartCoroutine(CreateWave());
    }

    private IEnumerator SpawnEnemies(int amount, GameObject prefab) //para spamear los enemigos
    {
        for(int i = 0; i < amount;i++ )
        {
        var randomSpawn = Random.Range(0, _pathWaves.Count);
            //Instantiate(prefab, _spawpoints[randomSpawn].position, Quaternion.identity);
            EventDispatcher.Dispatch(new SpawnObject(prefab,null, _spawpoints[randomSpawn].position, Quaternion.identity, 
                (gameObjectSpawn) => { //apartir de aqui 
                    int rs = randomSpawn;
                    string pathName = _pathWaves[rs];
                    gameObjectSpawn.GetComponent<FollowPathMovement>().InitEnemy(pathName); //mandamos llamar para que se inicialice al reusar los enemigos.
                })); 
            //usams el codigo que instalamos, le pasamos los prefabs y le decimos que identifique la posicion qe se le asigno.
        yield return new WaitForSeconds(1);
        }
    }
}

