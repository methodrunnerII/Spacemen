﻿using UnityEngine;
using System.Collections;

public class PlanetPosition : MonoBehaviour {
	public GameObject orbitPlanet = GameObject.Find("/Star");

	public float mu;
	public float orbitRadius;
	public float omega;
	public float inclination;
	
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		Vector3 semiMajor = Vector3.right * orbitRadius;
		Vector3 semiMinor = Vector3.forward * orbitRadius;
		semiMajor = Quaternion.Euler(0, omega, 0)*semiMajor;
		semiMinor = Quaternion.Euler(0, omega, 0)*semiMinor;
		semiMajor = Quaternion.Euler(0, 0, inclination)*semiMajor;
		semiMinor = Quaternion.Euler(0, 0, inclination)*semiMinor;
		
		float angularVelocity = 2*Mathf.PI*Mathf.Sqrt(mu/Mathf.Pow(orbitRadius, 3));
		float theta = Time.time*angularVelocity;
		transform.position = orbitPlanet.transform.position + semiMajor*Mathf.Cos(theta) + semiMinor*Mathf.Sin(theta);
	}
}
