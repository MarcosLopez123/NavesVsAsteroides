using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour
{
    
   	public GameObject explosion;
    public GameObject playerExplosion;
    public float scoreValue;
       
   	private GameControllerTerceraEscena gameController;
   
   	 void Start()
       {
           GameObject gameControllerObject = GameObject.FindWithTag("GameController");
   		   gameController = gameControllerObject.GetComponent<GameControllerTerceraEscena>();
   		
   		
       }
       
       void OnTriggerEnter(Collider other)
       {
   		if(other.CompareTag ("Boundary")) return;
   		Instantiate(explosion, transform.position, transform.rotation);
           if(other.CompareTag ("Player")){
   
   		 Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
   			gameController.GameOver();
   		}
   	
           gameController.AddScore(scoreValue);
           Destroy(other.gameObject);
           Destroy(gameObject);
           
          
       }
        
       void Update()
       {
           
       } 
    
    
}
