using UnityEngine;

public class FlyOrbitalTrajectory : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _radius =3f;
    [SerializeField] private float _offsetHeight = 10f;
    [SerializeField] private float _speedRotation = 1f;
    private float _radian = 0f;
    private Vector3 start;

    void Start()
    {
        start = new Vector3(_target.transform.position.x, _target.transform.position.y + _offsetHeight, _target.transform.position.z);
    }

    void Update()
    {
        _radian += _speedRotation * Time.deltaTime;
        transform.position = new Vector3(start.x + _radius * Mathf.Cos(_radian),start.y , start.z+ _radius * Mathf.Sin(_radian));
        Vector3 direction = _target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
