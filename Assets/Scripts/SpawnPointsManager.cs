using System.Collections;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float timeBetweenSpawns;

    private Coroutine _spawningProcess;

    private SpawnPoint GetRandomSpawnPoint => _spawnPoints[Random.Range(0, _spawnPoints.Length)];

    private void OnEnable()
    {
        _spawningProcess = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawningProcess);
    }

    private IEnumerator Spawning()
    {
        var delay = new WaitForSecondsRealtime(timeBetweenSpawns);

        while (true)
        {
            yield return delay;
            GetRandomSpawnPoint.Spawn();
        }
    }
}
