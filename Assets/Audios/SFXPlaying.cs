using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
 public AudioSource Start;
 public AudioSource Einhowalk;
 public AudioSource RestartPause;
 public AudioSource ExitPause;
 public AudioSource KiahSong;
 public AudioSource MenuSoundtrack;

  [SerializeField]
  float bgMusicVolume;

  public void PLayStart () {
      Start.Play();
  }
  public void PlayEinhowalk () {
      Einhowalk.Play (); 
  }

  public void PlayRestartPause () {
    RestartPause.Play (); 

  }
  public void PlayExitPause () {
    ExitPause.Play (); 
  }
  
  public void PlayKiahSong () {
    KiahSong.Play (); 
    
  }

  public void PlayMenuSoundtrack (){
    MenuSoundtrack.Play ();
    
  }

}
