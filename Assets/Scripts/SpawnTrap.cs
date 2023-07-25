using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : MonoBehaviour
{
    public GameObject Spawner;
    public float SpawnTime = 3f; // Interval 3 detik sesuai kebutuhan
    private int MaxSpawn = 3;
    private int Spawned = 0;
    private bool canSpawn = true; // Kasih Flag kalau dibutuhkan nanti

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawnAfterDelay());
    }

    // Delay coin spawn setelah 3 detik
    private IEnumerator StartSpawnAfterDelay()
    {
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(SpawnTraps());
    }

    private IEnumerator SpawnTraps()
    {
        while (canSpawn)
        {
            if (Spawned < MaxSpawn)
            {
                float YPos = 0.23f;
                Vector3 RandomSpawnPosition = new Vector3(Random.Range(-3f, 3f), YPos, Random.Range(-1f, 1f));
                GameObject newTraps = Instantiate(Spawner, RandomSpawnPosition, Quaternion.Euler(90f, 0f, 0f));
                Spawned++;

                StartCoroutine(DespawnTrap(newTraps));
            }

            yield return new WaitForSeconds(SpawnTime);
        }
    }

    private IEnumerator DespawnTrap(GameObject trapToDespawn)
    {
        yield return new WaitForSeconds(10f); // Wait for 10 seconds
        Destroy(trapToDespawn);
        Spawned--;
    }

    // Fungsi despawn untuk dipanggil dari luar hitung hitung lindungin variable spawned
    public void TrapDespawned()
    {
        Spawned--;
    }
}
