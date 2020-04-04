using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _bot;
    [SerializeField] private float _secondsDelaySpawn = 2f;
    private Transform[] _spawnPoints;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<Transform>();
        Transform[] spawnPointsTemp = new Transform[_spawnPoints.Length - 1];
        for (int i =0, j=0;  i<_spawnPoints.Length; i++)
        {
            if (_spawnPoints[i].GetComponent<Spawner>() == null)
                spawnPointsTemp[j] = _spawnPoints[i];
            else
                continue;

            j++;
        }
        _spawnPoints = spawnPointsTemp;
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_secondsDelaySpawn);
        StartCoroutine(StepSpawn());
    }

    private IEnumerator StepSpawn()
    {
        int i = 0;
        while (true)
        {
            yield return _waitForSeconds;
            Instantiate(_bot, _spawnPoints[i].position, Quaternion.identity);
            i++;
            i %= _spawnPoints.Length;
        }
    }
}