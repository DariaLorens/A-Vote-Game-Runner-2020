using System.Collections.Generic;
using UnityEngine;

public class Sound:MonoBehaviour {
    public static Sound instance;

    private void Awake() {
        instance=this;
    }

    public List<AudioClip> sounds;
    public AudioSource sourse;

    public void playSound(int f) {
        sourse.PlayOneShot(sounds[f]);
    }
}
