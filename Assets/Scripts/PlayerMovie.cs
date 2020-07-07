using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovie : MonoBehaviour {
    public static PlayerMovie Instance;
    public GameObject gameOverPanel;
    private Animator _animator;
    public GameObject particle;

    private void Awake() {
        Instance = this;
        _animator = gameObject.GetComponent<Animator>();
    }


    public IEnumerator GoToHouse() {
        while (true) {
            transform.Translate(new Vector2(6.16f, -1.41f) * Time.deltaTime);
            if (gameObject.GetComponent<Transform>().position.x >= 6.40f) {
                //           StartCoroutine(ToVote());
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator ToVote() {
        yield return new WaitForSeconds(3f);
        _animator.SetBool("mirrow", true);
        while (true) {
            transform.Translate(new Vector2(-1.5f, -1.41f) * Time.deltaTime * 3);
            if (gameObject.GetComponent<Transform>().position.x <= 2f) {
                gameOverPanel.SetActive(true);
                Sound.instance.playSound(3);
                particle.SetActive(true);
                _animator.SetBool("win", true);
                Destroy(GameController.Instance.sound);
                yield break;
            }

            yield return null;
        }
    }
}