using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Lab3 : MonoBehaviour
{
	public Transform referenceObj;
	public float m_initialVelocity;
	public float m_finalVelocity;
	public float m_acceleration;
	public float m_time;

	private Rigidbody rb;
	private Vector3 m_forceDirection = Vector3.up;
	private Vector3 m_Impulse;
	private float m_displacement;
	private bool m_isFlappyBird = false;

	private float CalcInitVelocity(float fVelocity, float displacement, float time)
	{
		return time > Mathf.Epsilon ? (displacement / time) * 2.0f - fVelocity : 0.0f;
	}

	private float CalcImpulse(float iV, float fV, float mass)
	{
		return ((fV - iV) * mass) / 0.02f; 
	}

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		m_displacement = referenceObj.transform.position.y;
		m_initialVelocity = CalcInitVelocity(m_finalVelocity, m_displacement, m_time);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			 m_isFlappyBird = true;
		}
	}

	void FixedUpdate()
	{
		m_Impulse = m_forceDirection * CalcImpulse(m_initialVelocity, m_finalVelocity, rb.mass);

		if (m_isFlappyBird)
		{
			rb.AddForce(m_Impulse);
			m_isFlappyBird = false;
		}
	}
}