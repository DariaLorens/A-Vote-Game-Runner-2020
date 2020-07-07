using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    public List<GameObject> tiles;
    public bool spawn = true;

    private float timeBtwSpawn;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if (spawn) {
            if (timeBtwSpawn <= 0) {
                Instantiate(tiles[Random.Range(0, tiles.Count)], transform.position, Quaternion.identity);
                timeBtwSpawn = Random.Range(GameController.Instance.minTimeBtwSpawn, GameController.Instance.maxTimeBtwSpawn);
            } else {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }
}
