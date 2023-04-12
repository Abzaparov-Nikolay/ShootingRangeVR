using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform spawnBullet;
    public AudioSource fireAudio;

    public static event Action pistolFire;

    [ContextMenu("Fire")]
    public void doFire()
    {
        
        GameObject createBullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
        createBullet.GetComponent<Rigidbody>().velocity = speed * spawnBullet.forward;
        fireAudio.Play();
        Destroy(createBullet, 5f);
        pistolFire?.Invoke();
    }
}