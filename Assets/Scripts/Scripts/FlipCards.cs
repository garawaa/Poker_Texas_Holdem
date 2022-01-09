using UnityEngine;
using System.Collections;

public class FlipCards : MonoBehaviour {

	public GameObject[] cards;

	public Material material;

	public Texture2D texture1;
	public Texture2D texture2;
	// Use this for initialization
	void Start () {
	
		StartCoroutine(FlipMyCards (cards, 0.59f));
	}
	
	IEnumerator FlipMyCards(GameObject[] cards, float overTime)
	{

		yield return new WaitForSeconds (2);

		float startTime;

		//rotate the cards
		for (var i = 0; i < cards.Length; i++) {

			startTime = Time.time;

			while (Time.time < startTime + overTime) {

				cards[i].transform.Rotate(Vector3.forward*5, Space.World);

				//changing the material of the card to card face once it is rotated to 90deg
				if (cards[i].transform.rotation.eulerAngles.z >= 90f) {
					cards[i].transform.eulerAngles = new Vector3(cards[i].transform.rotation.eulerAngles.x, cards[i].transform.rotation.eulerAngles.y, 90f); 
					//CHANGE THE MATERIAL
					GameObject cardObject = GameObject.Find("Card"+i+"-0");
					Renderer cardRend = cardObject.GetComponent<Renderer>();
					cardRend.enabled = true;
					if(i==0)
                    {
						material.mainTexture = texture1;
						cardRend.sharedMaterial = material;
					}
					else
                    {
						material.mainTexture = texture2;
						cardRend.sharedMaterial = material;
					}
					
				}

				//PUT THE FINAL ROTATED POSITION HERE

				yield return null;

			}


			//time between rotating each card
			//yield return new WaitForSeconds (timeBetweenCards);
		}
	}
}
