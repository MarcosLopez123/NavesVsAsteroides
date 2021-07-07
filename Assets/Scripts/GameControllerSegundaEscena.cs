using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControllerSegundaEscena : MonoBehaviour
{

    public GameObject asteroide;
    public GameObject asteroideA;
    public Vector3 spawnValues;
    public int asteroidesCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private float score;
    public Text scoreText;
    public GameObject restartGameObject;
    private bool restart;
    public GameObject gameOverGameObject;
    private bool gameOver;
    public GameObject finishGameObject;
   
    
    // Start is called before the first frame update
    void Start()
    {
        restart = false;
        restartGameObject.SetActive(false);
        gameOver = false;
        gameOverGameObject.SetActive(false);
       
        finishGameObject.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
             
    }
    
      void Update()
        {
            if (restart && Input.GetKeyDown(KeyCode.R)){
           
                Restart();
               
            }
            
         
        }
       public void Restart(){
         SceneManager.LoadScene(2);
       }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        asteroideA.SetActive(true);
        asteroide.SetActive(true);
        while (true)
        {
        
            for (int i = 0; i < asteroidesCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x ), spawnValues.y, spawnValues.z);
                Vector3 spawnPosition2 = new Vector3(Random.Range(-spawnValues.x,spawnValues.x ), spawnValues.y, spawnValues.z);
                Instantiate(asteroide, spawnPosition, Quaternion.identity);
                Instantiate(asteroideA, spawnPosition2, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
               restartGameObject.SetActive(true);
                restart = true;
                break;
            }
        }
  
        
       
    }

    public void AddScore(float value)
    {
        score +=value;
        UpdateScore();
       
    }
    
 
    void UpdateScore()
    {
      scoreText.text = "Score: " + score;
      if(score>=1200){
         asteroideA.SetActive(true);
         asteroide.SetActive(true);
         gameOverGameObject.SetActive(false);
         finishGameObject.SetActive(true);       
         Invoke("cambio", 5f);
      }
      
    }
    
  
    
    void cambio(){
     
      finishGameObject.SetActive(false);
      SceneManager.LoadScene(3); 
    
    
    }
    
    
   
 
    public void GameOver()
    {
       gameOverGameObject.SetActive(true);

        gameOver = true;
    }
}
