using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController Instance;

    public int maxTimeBtwSpawn;
    public int minTimeBtwSpawn;
    public int speed;
    public GameObject gameOverPanel;
    public GameObject house;
    public GameObject helpText;
    public GameObject sound;

    private void Awake() {
        Instance = this;
        StartCoroutine(GameSpeedUp());
        StartCoroutine(DisableText());
        Time.timeScale = 1;
    }
    

    private IEnumerator GameSpeedUp() {
        while (true) {
            yield return new WaitForSeconds(15f);
            speed += 1;
            maxTimeBtwSpawn -= 1;
            if (speed == 10) {
                EndGame();
                yield break;
            }
        }

        yield return null;
    }


    private IEnumerator DisableText() {
        yield return new WaitForSeconds(10f);
        helpText.SetActive(false);

        yield return null;
    }

    public void GameOver() {
        Sound.instance.playSound(4);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        Destroy(sound);
    }

    public void EndGame() {
        house.SetActive(true);
        speed = 0;
        Spawner.Instance.spawn = false;
        EnemyObjectsController.Instance.destroyAll();
        StartCoroutine(PlayerMovie.Instance.GoToHouse());
        StartCoroutine(PlayerMovie.Instance.ToVote());
    }
}