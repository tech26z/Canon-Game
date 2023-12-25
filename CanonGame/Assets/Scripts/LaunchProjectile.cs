using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour {

    public GameObject projectile;
    public GameObject target;
    float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if(time >= 2.0)
        {
            time = 0;
            transform.LookAt(target.transform);
            GameObject t = Instantiate(projectile, transform.position, Quaternion.identity);           
            t.GetComponent<Rigidbody>().AddForce(transform.forward * 2500);
            Destroy(t, 3);
        }

       
	}
}
