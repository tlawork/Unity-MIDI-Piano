using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxKey : MonoBehaviour
{
	public Material Material { get; set; }

	private bool _play = false;
	//private bool _played = false;
	private float _velocity;
	private float _length;
	private float _speed;
	private Color _colour;
	private Color _originalColour;
	private float _Timer;
	
	private Vector3 _position;
	private Vector3 _rotation;

	private Rigidbody _rigidbody;
	private HingeJoint _springJoint;
	private ConstantForce _constantForce;
	private IEnumerator _playCoro;
	private IEnumerator _volumeCoro;

	private List<AudioSource> _toFade = new List<AudioSource>();

	private bool _depression;
	private float _startAngle;

	private Vector2 startingPos;

	// Debug
	public bool TestPlay = false;

	void Awake()
	{
		_position = transform.position;
		startingPos.x = _position.x;
		startingPos.y = _position.y;

		_rotation = transform.eulerAngles;
		Material = GetComponent<MeshRenderer>().material;
		_originalColour = Material.color;
	}

	// Update is called once per frame
	void Update()
	{
		_speed=1;
		if (_play)
		{
			_position.x = startingPos.x + Mathf.Sin(Time.time * _speed);
			_position.y = startingPos.y + Mathf.Sin(Time.time * _speed);
		}

		// Debug
		if (TestPlay)
		{
			Play(2);
			TestPlay = false;
		}
	}


    public void Play(float length)
    {
		_play = true;
        return;
    }

	




}
