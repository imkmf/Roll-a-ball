using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GUIText countText;
	public GUIText countLeftText;
	public GUIText winText;
	private int count;
	private int pickupsLeft;

	void Start ()
	{
		count = 0;
		pickupsLeft = GameObject.FindGameObjectsWithTag("PickUp").Length - 1; // Prefab is counted?
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			pickupsLeft = pickupsLeft - 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countLeftText.text = "Pick Ups Left: " + pickupsLeft.ToString();
		countText.text = "Count: " + count.ToString();
		if(pickupsLeft == 0)
		{
			winText.text = "You win!";
		}
	}
}
