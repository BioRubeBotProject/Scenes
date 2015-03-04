using UnityEngine;
using System.Collections;

public class receptorScript : MonoBehaviour {

	public GameObject _ActiveReceptor;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "ECP") 
		{
			//Destroy (other.gameObject);
			this.gameObject.SetActive(false);
			// if the player entered the trigger... 
			// create the object and get a reference to it: 
			GameObject NewAReceptor = (GameObject)Instantiate(_ActiveReceptor, transform.position, transform.rotation); 
			// play the sound in the trigger AudioSource:
			Destroy (other.gameObject);

		}
	}

	
	// Update is called once per frame
	void Update () 
	{


	
	}


}
