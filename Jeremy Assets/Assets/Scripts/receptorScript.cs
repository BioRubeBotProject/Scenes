using UnityEngine;
using System.Collections;

public class receptorScript : MonoBehaviour {

	public GameObject _ActiveReceptorA, _ActiveReceptorB, _ActiveReceptorC;


	IEnumerator transformReceptor(Collider2D other){

		Destroy (other.gameObject);
		// if the player entered the trigger... 
		// create the object and get a reference to it: 


		GameObject NewAReceptorA = (GameObject)Instantiate(_ActiveReceptorA, transform.position, transform.rotation);
		// play the sound in the trigger AudioSource:

		Debug.Log ("starting To waitThreeSeconds2");
		yield return new WaitForSeconds(1);
		GameObject NewAReceptorB = (GameObject)Instantiate(_ActiveReceptorB, NewAReceptorA.transform.position, NewAReceptorA.transform.rotation);
		Debug.Log("Did we wait?2");
		NewAReceptorA.gameObject.SetActive(false);


		Debug.Log ("starting To waitThreeSeconds3");
		yield return new WaitForSeconds(1);
		GameObject NewAReceptorC = (GameObject)Instantiate(_ActiveReceptorC, NewAReceptorB.transform.position, NewAReceptorB.transform.rotation);

		NewAReceptorB.gameObject.SetActive(false);
		Debug.Log("Did we wait3?");
		this.gameObject.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "ECP") 
		{

			StartCoroutine(transformReceptor(other));


		}
	}


	
	// Update is called once per frame
	void Update () 
	{


	
	}


}
