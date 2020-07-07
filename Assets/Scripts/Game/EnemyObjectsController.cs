using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectsController : MonoBehaviour {
    public static EnemyObjectsController Instance;

     public List<GameObject> enemys;

    private void Awake() {
        Instance = this;
        enemys = new List<GameObject>();
    }

    public void destroyAll() {
        foreach (var enemy in enemys) {
            Destroy(enemy);
        }
    }
}
