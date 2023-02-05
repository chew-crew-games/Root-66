using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
  // Start is called before the first frame update
  public static AudioManager _instance;

  //   public AudioSource Destruction;
  public AudioSource MenuMusic;

  public static AudioManager Instance {
    get {
      if (_instance == null) {
        Debug.LogError("Audio Manager is NULL!");
      }
      return _instance;
    }
  }
  void Awake() {
    _instance = this;
    PlayMenuMusic();
  }

  // Update is called once per frame
  void Update() {

  }

  void PlayMenuMusic() {
    MenuMusic.Play();
  }

  //   void PlayDetructionCarCrashSmall() {
  //     Destruction.Play();
  //   }
}
