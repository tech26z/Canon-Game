using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//***************************************************************
//FPSController has no camera. FirstPersonCharacter has Camera
//Camera cast ray from it's lens center
//Debug.DrawRay use Ray's position, direction to draw a ray.
//player won't see the ray if no draw.
//***************************************************************

public class ManageWeapons : MonoBehaviour {

    public GameObject sparksAtImpact;

    Camera playersCamera;
    Ray rayFromPlayer;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        playersCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        rayFromPlayer = playersCamera.ScreenPointToRay(new Vector3(Screen.width / 2,
            Screen.height / 2));
        Debug.DrawRay(rayFromPlayer.origin, rayFromPlayer.direction * 100, Color.red);

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(rayFromPlayer, out hit, 100))
            {
                Debug.Log("The object" + hit.collider.gameObject.name +
                    "is in the front of the player ");

                Vector3 positionOfImpact;
                positionOfImpact = hit.point;
                Instantiate(sparksAtImpact, positionOfImpact, Quaternion.identity);
            }
        }
        
	}
}
