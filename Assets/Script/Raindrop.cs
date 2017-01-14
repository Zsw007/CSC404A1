using UnityEngine;

public class Raindrop : MonoBehaviour
{
    public const float AdhesionK = 1f;
    public const float CohesionK = 1f;
    public const float MergeThreshold = 0.1f;

    private const float ScaleScaler = 4;

    private Rigidbody _rigidbody;
    private Transform _cloth;

	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();
	    _cloth = GetComponentInChildren<Transform>();
	}
	void FixedUpdate ()
	{
		_rigidbody.AddForce(new Vector3(0, Mathf.Min(GetAdhesionForce() + _rigidbody.mass * Physics.gravity.y, 0), 0));
	}

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody && other.CompareTag("Raindrop"))
        {
            var dir = transform.position - other.transform.position;
            if (Controller.Instance.AttachedRaindrop == gameObject || 
                transform.localScale.x >= other.transform.localScale.x && 
                dir.magnitude + other.transform.localScale.x < transform.localScale.x && 
                Controller.Instance.AttachedRaindrop != other.gameObject)
            {
                transform.localScale += other.transform.localScale / transform.localScale.x / ScaleScaler;
                _cloth.localScale = transform.localScale / _cloth.localScale.x / ScaleScaler;
                _rigidbody.mass += other.attachedRigidbody.mass;
                Destroy(other.gameObject);
                _rigidbody.velocity = Vector3.zero;
            }
            else
            {
                other.attachedRigidbody.AddForce(dir * CohesionK / dir.sqrMagnitude);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Window"))
        {
            _rigidbody.velocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
        }
    }

    private float GetAdhesionForce()
    {
        return Mathf.Sqrt(_rigidbody.mass) * AdhesionK;
    }
}
