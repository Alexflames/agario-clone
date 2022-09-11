using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FoodManager : NetworkBehaviour
{
    public GameObject foodPrefab;
    public List<GameObject> foodlist;
    public float interval = 0.5f;
    private float timer = 0;
    private bool isRunning = false;
    public Vector2 fieldSize = Vector2.one * 50f;

    private void Awake()
    {
        foodlist = new List<GameObject>();
    }

    public override void OnStartServer()
    {
        isRunning = true;
    }

    void SpawnFood()
    {
        GameObject food = Instantiate(foodPrefab);
        foodlist.Add(food);
        food.transform.position = new Vector3(
            Random.Range(-fieldSize.x / 2f, fieldSize.x / 2f), 
            Random.Range(-fieldSize.y / 2f, fieldSize.y / 2f),
            0);
        NetworkServer.Spawn(food);
    }

    private void Update()
    {
        if (isRunning && timer <= 0)
        {
            SpawnFood();
            timer = interval;
        }
        else
            timer -= Time.deltaTime;
    }
}
