using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObjet = GameObject.FindWithTag("GameController");
        if (gameControllerObjet != null)
        {
            gameController = gameControllerObjet.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }



    private void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag( "Boundery" ) || other.CompareTag( "Enemy" ) )
        {
            return;
        }

		if (explosion != null) 
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.CompareTag( "Player" ))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    } 


}
