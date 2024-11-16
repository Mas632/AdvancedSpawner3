using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Warrior _warrior;
    [SerializeField] private Fireball _fireballPrototype;

    public void Spawn()
    {
        const float FireballSpeed = 5f;

        if (_fireballPrototype != null)
        {
            Fireball fireball = Instantiate(_fireballPrototype, transform.position, Quaternion.identity);
            fireball.SetTarget(_warrior);
            fireball.SetSpeed(FireballSpeed);
        }
    }
}
