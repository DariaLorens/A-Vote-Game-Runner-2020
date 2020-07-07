﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovie : MonoBehaviour {
    private void Awake() {
        EnemyObjectsController.Instance.enemys.Add(gameObject);
    }

    // Update is called once per frame
    private void Update() {
        transform.Translate(Vector2.left * (GameController.Instance.speed * Time.deltaTime));
    }

    private void OnBecameInvisible() {
        EnemyObjectsController.Instance.enemys.Remove(gameObject);
        Destroy(this.gameObject);
    }
}