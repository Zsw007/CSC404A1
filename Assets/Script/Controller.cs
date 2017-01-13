using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller Instance { get; private set; }

    public GameObject AttachedRaindrop { get; private set; }

    private const int WindowLayer = 8;
    private Collider _trigger;

    void Awake()
    {
        Instance = this;
    }

	void Start ()
	{
	    _trigger = GetComponent<Collider>();
	}
	
	void Update ()
	{
	    if (Input.GetMouseButtonDown(0))
	    {
	        _trigger.enabled = true;
	    }
	    if (Input.GetMouseButton(0))
	    {
	        var v3 = Input.mousePosition;
	        v3.z = 10;
	        v3 = Camera.main.ScreenToWorldPoint(v3);

	        transform.position = v3;
	        if (AttachedRaindrop != null)
	        {
	            AttachedRaindrop.transform.position = transform.position;
            }
	    }

	    if (Input.GetMouseButtonUp(0))
	    {
	        AttachedRaindrop = null;
	        _trigger.enabled = false;
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Raindrop") && AttachedRaindrop == null)
        {
            
            AttachedRaindrop = other.gameObject;
        }
    }
}
