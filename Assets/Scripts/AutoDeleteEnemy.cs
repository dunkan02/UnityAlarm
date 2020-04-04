using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeleteEnemy : MonoBehaviour
{
    [SerializeField] private float _secondsToDelete = 23f;
    void Start()
    {
        StartCoroutine(TimerToDelete());
    }

    IEnumerator TimerToDelete()
    {
        yield return new WaitForSeconds(_secondsToDelete);
        Destroy(gameObject);
    }
}
