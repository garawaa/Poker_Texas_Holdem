using UnityEngine;
using System.Collections;

public class FlopDeal : MonoBehaviour {

	public GameObject[] cards;
	//public float speed;
	//public int[] orders;

	public Material material;

	public GameObject[] targets;

	public Texture2D texture;

	//public Renderer rend;

	public void Flop()
	{

		StartCoroutine(MoveCards (cards, targets, 0.59f, 0.01f));
	}

	IEnumerator MoveCards(GameObject[] cards, GameObject[] targets, float overTime, float timeBetweenCards)
	{
		float startTime;

		//animate each flop card to its target over time "overTime"
		for (var i = 0; i < cards.Length; i++) {
			
			startTime = Time.time;

			//translate the cards
			while (Time.time < startTime + overTime) {
				
				cards [i].transform.position = Vector3.Lerp (cards [i].transform.position, targets [i].transform.position, (Time.time - startTime) / overTime);

				yield return null;
			
			}
			cards [i].transform.position = targets [i].transform.position;

			//time between moving each card
			//yield return new WaitForSeconds (timeBetweenCards);
		}
			
		//flip the cards
		for (var i = 0; i < cards.Length; i++) {

			startTime = Time.time;

			while (Time.time < startTime + overTime) {

				cards[i].transform.Rotate(Vector3.forward*5, Space.World);

				//changing the material of the card to card face once it is rotated to 90deg
				if (cards[i].transform.rotation.eulerAngles.z >= 90f) {

					//CHANGE THE MATERIAL
					GameObject cardObject = GameObject.Find("CardFlop"+i);
					Renderer cardRend = cardObject.GetComponent<Renderer>();
					cardRend.enabled = true;

					material.mainTexture = texture;
					cardRend.sharedMaterial = material;
				}

				//PUT THE FINAL ROTATED POSITION HERE

				yield return null;

			}


			//time between moving each card
			//yield return new WaitForSeconds (timeBetweenCards);
		}
	}
}
