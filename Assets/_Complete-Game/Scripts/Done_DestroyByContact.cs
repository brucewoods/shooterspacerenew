using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            if (gameController != null)
            gameController.GameOver();
		}
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (gameController != null && scoreValue != null) { 
	    gameController.AddScore(scoreValue);
        }
        Destroy (other.gameObject);
        if(gameObject!=null)
		Destroy (gameObject);
	}
}