using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Shown") == 0)
        {
            BirdControl.CanMoved = false;
            Time.timeScale = 0;
            PlayerPrefs.SetInt("Shown", 1);
        }
        else
        {
            Time.timeScale = 1;
            BirdControl.CanMoved = true;
            Destroy(gameObject);
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void StartGame()
    {
        Time.timeScale = 1;
        BirdControl.CanMoved = true;
        this.gameObject.SetActive(false);
    }
}
