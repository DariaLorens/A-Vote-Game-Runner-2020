using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScript : MonoBehaviour {
    private Transform m_transform;
    private float size;

    private void Start() {
        m_transform = GetComponent<Transform>();
        size = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update() {
        Moves();
    }

    private void Moves() {
        m_transform.Translate(Vector3.left * (GameController.Instance.speed * Time.deltaTime));
        var offset = Vector3.zero;
        if (m_transform.position.x <= -size) {
            offset = new Vector3(size * 2, 0, 0);
        }

        if (m_transform.position.x >= size) {
            offset = new Vector3(-size * 2, 0, 0);
        }

        m_transform.position += offset;
    }
}