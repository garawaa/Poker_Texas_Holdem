using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DealCard : MonoBehaviour {

	//public GameObject card;
	public float speed;
	public int order;

	public Transform target;

	public void Deal()
	{
		// The step size is equal to speed times frame time.
//		var step = speed * Time.deltaTime;
//
//		// Move our position a step closer to the target.
//		transform.position = Vector3.Lerp(transform.position, target.position, step);

		//transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, step);

//		StartCoroutine (DealCards (1f));

	}

	IEnumerator DealCards(float overTime, float timeBetweenCards)
	{
		// The step size is equal to speed times frame time.
		//var step = speed * Time.deltaTime;

		float startTime;

		//TURN THIS INTO A FOR LOOP, PUT ALL ACTIVE CARDS INTO AN ARRAY

		//animate each flop card to its target over time "overTime"
		//for (var i = 0; i < cards.Length; i++) {

		startTime = Time.time;

		//translate the cards
		while (Time.time < startTime + overTime) {

			// Move our position a step closer to the target.
			transform.position = Vector3.Lerp(transform.position, target.position, (Time.time - startTime) / overTime);

			yield return null;

		}
		transform.position = target.position;

		//time between moving each card
		yield return new WaitForSeconds (timeBetweenCards);

		//}

	
	}

	// Use this for initialization
	void Start () {
		
		StartCoroutine (DealCards (1f, 1f));
	}

	// Update is called once per frame
	void Update () {

//		float timeDelay = 0.05f;
//
//		Invoke ("Deal", timeDelay*order);

	}
}
