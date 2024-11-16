using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float _speed;
    private Warrior _target;
    private ParticleSystem[] _particleSystems;
    private ParticleSystemForceField _blast;

    private void Start()
    {
        _particleSystems = gameObject.GetComponentsInChildren<ParticleSystem>();
        _blast = gameObject.GetComponentInChildren<ParticleSystemForceField>(true);

        if (_blast == null)
        {
            Debug.Log("_blast is not active!");
        }
    }

    private void LateUpdate()
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

    public void SetSpeed(float value)
    {
        _speed = value;
    }

    private void ActivateBlast()
    {
        if (_blast != null)
        {
            _blast.gameObject.SetActive(true);
        }

        foreach (ParticleSystem system in _particleSystems)
        {
            system.Stop();
        }
    }
}
