using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 4f;
    public float startTime = 3f;
    public GameObject prefab;   // Food prefab to spawn
    [Header("References")]
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    private void Start()
    {
        Subscribe();
    }

    private void OnDestroy()
    {
        UnSubscribe();
    }

    public void Subscribe()
    {
        // Subscribe function to this function call
        GameManager.Instance.onSpawn += Spawn;
    }

    public void UnSubscribe()
    {
        // Subscribe function to this function call
        GameManager.Instance.onSpawn -= Spawn;
    }

    // Spawn the food randomly
    void Spawn()
    {
        // Get coordinates of borders
        float left = borderLeft.position.x;
        float right = borderRight.position.x;
        float bottom = borderBottom.position.y;
        float top = borderTop.position.y;

        // Get random x and y coordinates - Corrected by Eric Wang
        int x = (int)Random.Range(left + .5f, right - .5f);
        int y = (int)Random.Range(top - .5f, bottom + .5f);

        // Spawn object at this point
        Instantiate(prefab, new Vector2(x, y), Quaternion.identity, transform);
    }
}