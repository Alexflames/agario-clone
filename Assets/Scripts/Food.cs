using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Food : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isServer)
        {
            collision.GetComponent<PlayerFeed>().Feed(1);
            NetworkServer.Destroy(gameObject);
        }
    }
}
