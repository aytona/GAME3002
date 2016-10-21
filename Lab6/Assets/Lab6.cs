using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Lab6 : MonoBehaviour
{
	public Vector3 m_angularVelocity;
	public bool m_isUsingLinearVelocity;

	private float m_desiredDisplacement = 200f;
	private float m_traveledDisplacement;
	private bool m_startSim = false;
	private Rigidbody m_rb;
	private Vector3 m_radius;

	void Start () {
		m_radius = m_rb.transform.localScale * 0.5f;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			m_startSim = true;
			m_traveledDisplacement = 0f;
		}
		if (Input.GetKeyDown(KeyCode.T)) {
			m_isUsingLinearVelocity = !m_isUsingLinearVelocity;
		}
		if(Input.GetKeyDown(KeyCode.L)) {
			LaunchSphere();
		}
		if (m_traveledDisplacement >= m_desiredDisplacement) {
			m_startSim = false;
			m_rb.angularVelocity = Vector3.zero;
			m_rb.velocity = Vector3.zero;
		}
	}

	void FixedUpdate () {
		if (m_startSim) {
			if (m_isUsingLinearVelocity) {
				m_rb.angularVelocity = AngularVeloctyToLinearVelocity(m_angularVelocity, m_radius);
			} else {
				m_rb.angularVelocity = m_angularVelocity;
			}
			m_traveledDisplacement += m_rb.velocity.magnitude * Time.fixedDeltaTime;
		}
	}

	void LaunchSphere() {
	// Launch a marble 25m in 5 seconds. The radius of the marble is 0.5m. The mass is 2kg
	// d = 25 t = 5s r = 0.5m m = 2kg = vi = 0m/s
	// 25m = vf/2 * 5
	// 25 / 5 = vf / 2
	// 5 * 2 = vf 
	// vf = 10m/s
	//
		Vector3 torque = ;
		m_rb.AddTorque(torque, ForceMode.VelocityChange);
	}

	Vector3 AngularVeloctyToLinearVelocity(Vector3 angularVelocity, Vector3 radius) {
		return angularVelocity * radius.magnitude;
	}

	Vector3 LinearVelocityToAngularVelocity(Vector3 linearVelocity, Vector3 radius) {
		return linearVelocity / radius.magnitude;
	}
}
