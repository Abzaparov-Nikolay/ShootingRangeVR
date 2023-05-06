using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    private bool SpawnOn;
    public GameObject TargetPrefab;
    public float X = 5;
    public float Z = 5;
    public float TargetHeight;
    public int Capacity = 5;
    public float SpawnCooldown = 1;
    List<GameObject> Targets = new List<GameObject>();
    public Timer timer;

    private double lastSpawnTime;

    private void Start()
    {
        SpawnAll();
    }

    private void Update()
    {
        if(!SpawnOn) 
            return;
        if (Time.timeAsDouble - lastSpawnTime >= SpawnCooldown && Targets.Count < Capacity)
        {
            SpawnTarget();
            lastSpawnTime = Time.timeAsDouble;
        }
    }

    private void RemoveDestroyedTarget(object sender)
    {
        Targets.Remove((GameObject)sender);
    }

    [ContextMenu("StartAgain")]
    public void SpawnAll()
    {
        for(var i = 0; i< Capacity; i++)
        {
            SpawnTarget();
        }
        SpawnOn = true;
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        for(var i = Targets.Count-1; i >= 0; i--)
        {
            Destroy(Targets[i]);
        }
        SpawnOn = false;
    }

    private void SpawnTarget()
    {
        var spawnedTarget = Instantiate(TargetPrefab, gameObject.transform);
        spawnedTarget.transform.Translate(Random.Range(-X, X), TargetHeight, Random.Range(-Z, Z));
        Targets.Add(spawnedTarget);
        var death = spawnedTarget.GetComponent<Death>();
        death.onDestroy.AddListener(RemoveDestroyedTarget);
        var health = spawnedTarget.GetComponent<Health>();
        health.OnDamaged.AddListener(timer.StartIfPaused);
    }
}
