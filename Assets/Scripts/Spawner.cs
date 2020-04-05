using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _bot;
    [SerializeField] private float _secondsDelaySpawn = 2f;
    private SpawnPoint[] _spawnPoints;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _spawnPoints = transform.GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_secondsDelaySpawn);
        StartCoroutine(StepSpawn());
    }

    private IEnumerator StepSpawn()
    {
        int i = 0;
        while (true && _spawnPoints.Length > 0)
        {
            yield return _waitForSeconds;
            Instantiate(_bot, _spawnPoints[i].transform.position, Quaternion.identity);
            i++;
            i %= _spawnPoints.Length;
        }
    }
}