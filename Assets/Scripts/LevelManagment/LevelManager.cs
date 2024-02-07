using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  [SerializeField] private Collider2D PlayerCollider;
  [SerializeField] private Collider2D PlayerCrouchCollider;
  public static int level = 1;

  public void SavePlayer()
  {
    SaveSystem.SavePlayer(this);
  }

  public void LoadPlayer()
  {
    PlayerData data = SaveSystem.LoadPlayer();

    level = data.level;
  }


  void OnTriggerEnter2D(Collider2D col)
  {
    if(col == PlayerCollider || col == PlayerCrouchCollider)
    {
      SavePlayer();
    }
  }



  public void StartGame()
  {
    SceneManager.LoadScene("Level1");
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  public void BacktoMenu()
  {
    SceneManager.LoadScene("Start");
  }

  public void Gotolvl2()
  {
    if(level > 1){
      SceneManager.LoadScene("Level2");
    }

  }
}
