using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 1f;
    public float minHeight = -3f;
    public float maxHeight = 3f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject logs = Instantiate(prefab, transform.position, Quaternion.identity);
        logs.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
