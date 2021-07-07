using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagament : MonoBehaviour
{
     public GameObject gameOverGameObject;
        void Start(){
            
        }
    
        void Update()
               {
                   if (Input.GetKeyDown(KeyCode.P)){
                  
                       PauseButton(); 
                   }else if (Input.GetKeyDown(KeyCode.S)){
                       PlayButton();
                        
                   }else if (Input.GetKeyDown(KeyCode.R)){
                        ReiniciarN();
                   }
                   
                
               }
        public GameObject pauseMenu;
        
        public void PauseButton(){
            
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        
        }
        public void PlayButton(){
                pauseMenu.SetActive(false);
                
                Time.timeScale = 1;
                
            
         }
         
         
     public void ReiniciarN(){
      Time.timeScale = 1;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     
     }
     
     public void VolverMenu(){
     Time.timeScale = 1;
      SceneManager.LoadScene(0);
     
     }
     
     public void Salir(){
     
       Application.Quit();
     
     }

}
