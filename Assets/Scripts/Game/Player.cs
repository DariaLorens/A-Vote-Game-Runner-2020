using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private LayerMask _layerMask;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    public Animator animator;
    public GameObject panel;

    private void Awake() {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        _boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (Input.GetMouseButton(0) && IsGrounded()) {
            animator.SetBool("jump", true);
            float jumpVelocity = 7f;
            _rigidbody2D.velocity = Vector2.up * jumpVelocity;
            Sound.instance.playSound(2);
        } else if (IsGrounded()) {
            animator.SetBool("jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("tile")) {
            Sound.instance.playSound(1);
            HealthController.Instance.RemovieHeart();
            Destroy(collision.gameObject);
        }
        
        if (collision.collider.CompareTag("other")) {
            Sound.instance.playSound(5);
            HealthController.Instance.RemovieHeart();
            Destroy(collision.gameObject);
            StartCoroutine(ShowPanel());
        }

        if (collision.collider.CompareTag("health")) {
            Sound.instance.playSound(0);
            HealthController.Instance.AddHeart();
            Destroy(collision.gameObject);
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f,
            Vector2.down, .1f, _layerMask);
        return raycastHit2D.collider != null;
    }
    
    
    public IEnumerator ShowPanel() {
        panel.SetActive(true);
        Sound.instance.playSound(5);
        yield return new WaitForSeconds(2f);
        panel.SetActive(false);
    }
}