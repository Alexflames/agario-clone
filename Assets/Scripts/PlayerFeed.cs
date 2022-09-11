using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerFeed : NetworkBehaviour
{
    [SyncVar]
    public int foodCount = 0;

    public void Feed(int foodSize) {
        foodCount += foodSize;
    }
}
