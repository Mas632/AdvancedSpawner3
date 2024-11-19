using UnityEngine;

public class Fireball : MonoBehaviour
{
    private const float StartSpeed = 5f;

    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private ParticleSystemForceField _blast;

    private float _speed;
    private Warrior _target;

    private void Start()
    {
        _speed = StartSpeed;
    }

    private void Update()
    {
        transform.LookAt(_target.transform, Vector3.up);
        transform.position = Vector3.MoveTowards(
            transform.position,
            _target.transform.position,
            _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ActivateBlast();
        Destroy(gameObject, 1f);
    }

    public void SetTarget(Warrior warrior)
    {
        _target = warrior;
    }

    private void ActivateBlast()
    {
        _blast.gameObject.SetActive(true);

        foreach (ParticleSystem system in _particleSystems)
        {
            system.Stop();
        }
    }
}
