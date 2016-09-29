using UnityEngine;
using System.Collections;

public class Lab4 : MonoBehaviour {

	public float m_distance;
	public float m_height;
	public float m_time;

	private float m_hypotenuse;
	private float m_velocity;
	private float m_angle;
	private float m_gravity = -9.8f;

	private float GetHypotenuse(float x, float y)
	{
		return Mathf.Sqrt((x * x) + (y * y));
	}

	void Start ()
	{
		m_hypotenuse = GetHypotenuse (m_distance, m_height);
		//20 = m_velocity * 5 + 0.5(-9.8)(5^2);
		m_velocity = (m_time + (0.5 * m_gravity * (m_time * m_time))) / m_distance;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
