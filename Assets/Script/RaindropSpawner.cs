using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RaindropSpawner : MonoBehaviour
{
    public float SpawnRate;

    public GameObject Raindrop;
    public GameObject Target;

    public Vector2 Range;

    private float _lastSpawn;
    private Transform _transform;

	// Use this for initialization
	void Start ()
	{
	    _transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time - _lastSpawn >= SpawnRate)
	    {
	        float randomX = Random.Range(-Range.x, Range.x);
	        float randomZ = Random.Range(-Range.y, Range.y);

	        Vector3 position = _transform.position;
	        position.x += randomX;
	        position.z += randomZ;

            GameObject droplet = Instantiate(Raindrop, position, _transform.rotation);

	        Vector3 direction = Target.transform.position - _transform.position;
            direction = direction.normalized * 10;
            
	        Rigidbody body = droplet.GetComponent<Rigidbody>();        
            body.velocity = direction;

            _lastSpawn = Time.time;
        }
	}
}
