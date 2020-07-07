using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
    public static HealthController Instance;

    public List<Image> hearts;
    public int counter;

    private void Awake() {
        Instance = this;
        counter = 0;
    }

    public void RemovieHeart() {
        hearts[counter].gameObject.SetActive(false);
        counter += 1;
        if (counter == hearts.Count) {
            GameController.Instance.GameOver();
        }
    }
    
    public void AddHeart() {
        if (counter != 0) {
            counter -= 1;
            hearts[counter].gameObject.SetActive(true);
        }
    }
}