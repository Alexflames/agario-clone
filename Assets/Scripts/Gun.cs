using System.Collections.Generic;
using UnityEngine;
using Mirror;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/guides/networkbehaviour
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

// NOTE: Do not put objects in DontDestroyOnLoad (DDOL) in Awake.  You can do that in Start instead.

public class Gun : NetworkBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gunPoint;

    public float reload = 0.5f;
    private float lastShot = -999f;

    public int damage = 1;

    private void Update()
    {
        if (!isLocalPlayer) return;
        if (Input.GetKeyDown(KeyCode.Space) && CanShoot())
        {
            Debug.Log("[1] Calling server to spawn bullet");
            Shoot();
        }
    }

    private bool CanShoot()
    {
        return (Time.time - lastShot) > reload;
    }

    [Command]
    private void Shoot()
    {
        if (CanShoot()) // Server-side check
        {
            Debug.Log("[2] Bullet is being spawned on server");
            lastShot = Time.time;
            var bulletInstance = Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
            NetworkServer.Spawn(bulletInstance);
            NotifyBulletSpawned();
        }
    }

    [ClientRpc]
    private void NotifyBulletSpawned()
    {
        Debug.Log("[3] Bullet has been spawned on server");
    }
}
