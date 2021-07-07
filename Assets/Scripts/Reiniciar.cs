using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Reiniciar : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R)){
           Restart();
       }
        
    }
    
    public void Restart(){
              SceneManager.LoadScene(1);
    }
}
