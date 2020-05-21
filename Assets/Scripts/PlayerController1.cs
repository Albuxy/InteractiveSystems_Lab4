using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{
	public float speed; 
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count; 
	  
	// Start is called before the first frame update
    	void Start()
    	{
		speed = 10.0f;
        	rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
    	}

    	// Update is called once per frame
    	void FixedUpdate()
    	{
        	float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
    	}
	void OnTriggerEnter(Collider other)
    	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
    	}
	void SetCountText ()
	{
		countText.text = "Points: " + count.ToString ();
		if (count >= 8)
		{
			winText.text = "VICTORY";
		}
	}
}	

