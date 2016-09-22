using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Impulse : MonoBehaviour {

	public float distance;
	public float time;
	public float mass;
	public float finalVelocity;

	private float initialVelocity;
	private float acceleration;
	private float force;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.mass = mass;
		initialVelocity = ((distance / time) * 2) - finalVelocity;
		acceleration = ((Mathf.Pow(initialVelocity, 2) - Mathf.Pow(finalVelocity, 2))
						/ distance) / 2;
		force = (mass * (initialVelocity - finalVelocity)) / Time.deltaTime;
		rb.AddForce(Vector3.up  * force);
	}
}
