using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject basketball;
    public Vector3 basketballOffset;
    public float basketballDistance = 1f;
    public float minimumShootingForce = 400f;
    public float maximumShootingForce = 1000f;

    private bool holdingBasketball;
    private bool calculatingShot;
    private float shootingTimer = 0f;
	// Use this for initialization
	void Start () {
        holdingBasketball = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (holdingBasketball)
        {
            basketball.transform.position = this.transform.position + this.transform.forward * basketballDistance + basketballOffset;
            basketball.GetComponent<Rigidbody>().useGravity = false;

            if (calculatingShot)
            {
                shootingTimer += Time.deltaTime;
            }
            if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
            {
                if (!calculatingShot)
                {
                    calculatingShot = true;
                }
                else if (holdingBasketball)
                {
                    holdingBasketball = false;
                    float calculatedScale = Mathf.Min(shootingTimer, 1f);
                    float calculatedForce = minimumShootingForce + (maximumShootingForce - minimumShootingForce) * calculatedScale;
                    basketball.GetComponent<Rigidbody>().useGravity = true;
                    basketball.GetComponent<Rigidbody>().AddForce(this.transform.forward * calculatedForce);
                }
            }
        }

        
	}
}
