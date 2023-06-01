using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnZoneSize = new(6, 2, .25f);
    [SerializeField] private GameObject _spawnObjectPrefab;
    [SerializeField] private int _capacity = 5;
    [SerializeField] private float _spawnCooldown = .5f;
    [SerializeField] private Timer _timer;

    private List<GameObject> _spawnedObjects;
    private WaitForSeconds _waitSpawnCooldown;

    private void Start()
    {
        _waitSpawnCooldown = new WaitForSeconds(_spawnCooldown);
        _spawnedObjects = new();
    }

    [ContextMenu("Restart")]
    public void Restart()
    {
        if (_spawnedObjects.Count > 0) RemoveSpawnedObjects();
        StartCoroutine(SpawnObjects());
    }

    private void RemoveSpawnedObjects()
    {
        foreach (var spawnedObject in _spawnedObjects)
        {
            Destroy(spawnedObject);
        }
        _spawnedObjects.Clear();
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (_spawnedObjects.Count >= _capacity)
                yield break;

            SpawnObject();
            yield return _waitSpawnCooldown;
        }
    }

    private void SpawnObject()
    {
        var spawnPoint = new Vector3(
            Random.Range(-_spawnZoneSize.x / 2, _spawnZoneSize.x / 2),
            Random.Range(-_spawnZoneSize.y / 2, _spawnZoneSize.y / 2),
            Random.Range(-_spawnZoneSize.z / 2, _spawnZoneSize.z / 2));
        
        var spawnedObject = Instantiate(_spawnObjectPrefab, transform.position - spawnPoint, Quaternion.identity, transform);
        _spawnedObjects.Add(spawnedObject);
        
        var death = spawnedObject.GetComponent<Death>();
        death.onDestroy.AddListener(RemoveDestroyedTarget);
        
        var health = spawnedObject.GetComponent<Health>();
        health.OnDamaged.AddListener(_timer.StartIfPaused);
    }
    
    private void RemoveDestroyedTarget(GameObject sender)
    {
        _spawnedObjects.Remove(sender);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, _spawnZoneSize);
    }
}