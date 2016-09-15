using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CalculateAcceleration : MonoBehaviour
{
	public float initialVelocity;   // Initial velocity of object
	public float finalVelocity;     // Final velocity of object
	public float totalTime;         // Time it takes to reach final velocity
	public bool useFormula;         // Check in inspector to use velocity formula

	private Rigidbody rb;
	private float KMtoM = 1000;
	private float HtoS = 3600;
	private float acceleration;
    private bool startSim = false;

	void Start()
	{
        // Get reference to this object's rigidbody
		rb = GetComponent<Rigidbody>();

        // Convert velocity to Metres / Seconds
		initialVelocity *= KMtoM / HtoS;
		finalVelocity *= KMtoM / HtoS;

        // Formula used: vf = vi + a * t
        // Changed to: a = (vf - vi) / t
		acceleration = (finalVelocity - initialVelocity) / totalTime;
	}

	void FixedUpdate ()
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startSim = true;
        }

		if (startSim)
		{
			if (!useFormula)
			{
				rb.AddForce (Vector3.forward * acceleration);
			}
			else
			{
				rb.velocity += (Vector3.forward) * acceleration * Time.deltaTime;
			}
		}
	}
}
