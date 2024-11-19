using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Warrior _warrior;
    [SerializeField] private Fireball _fireballPrototype;

    public void Spawn()
    {
        if (_fireballPrototype != null)
        {
            Fireball fireball = Instantiate(_fireballPrototype, transform.position, Quaternion.identity);
            fireball.SetTarget(_warrior);
        }
    }
}
