using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject TargetPrefab;
    public float X = 5;
    public float Z = 5;
    public float TargetHeight;
    public int Capacity = 5;
    public float SpawnCooldown = 1;
    List<GameObject> Targets = new List<GameObject>();

    private double lastSpawnTime;

    private void Update()
    {
        if (Time.timeAsDouble - lastSpawnTime >= SpawnCooldown && Targets.Count < Capacity)
        {
            var spawnedTarget = Instantiate(TargetPrefab, gameObject.transform);
            spawnedTarget.transform.Translate(Random.Range(-X, X), TargetHeight, Random.Range(-Z, Z));
            Targets.Add(spawnedTarget);
            var death = spawnedTarget.GetComponent<Death>();
            death.onDestroy.AddListener(RemoveDestroyedTarget);

            lastSpawnTime = Time.timeAsDouble;
        }
    }

    private void RemoveDestroyedTarget(object sender)
    {
        Targets.Remove((GameObject)sender);
    }
}
