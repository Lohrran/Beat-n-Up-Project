using UnityEngine;
using System.Collections;

public class BlockToScreen : MonoBehaviour {

    public bool mudandoDeFase = false;

	void Update () 
	{
		SpriteRenderer playerRend = GetComponent<SpriteRenderer>();
		
        float top = mudandoDeFase ? 1f : 0.56f;

		var distanceZ = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0 , 0, distanceZ)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1 , 0, distanceZ)).x;
		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, top, distanceZ)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).y;
		
		transform.position = new Vector3
		(
			Mathf.Clamp(transform.position.x, leftBorder + (playerRend.bounds.size.x /6), rightBorder - (playerRend.bounds.size.x / 6)), 
			Mathf.Clamp(transform.position.y, bottomBorder + (playerRend.bounds.size.y / 4), topBorder - (playerRend.bounds.size.y / 4)),
			transform.position.z
		);
	}
}
