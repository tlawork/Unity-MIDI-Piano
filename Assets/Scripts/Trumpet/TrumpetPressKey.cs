using UnityEngine;

public class TrumpetPressKey : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    public bool pressed = false;
    private bool right_now = false;
    private Vector3 lastPos;
    private Vector3 origPos;
    private Vector3 pressPos;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        origPos = transform.position;
        pressPos = new Vector3(origPos.x, origPos.y-0.014f, origPos.z);
    }


    void FixedUpdate()
    {
        if (right_now != pressed)
        {
            right_now = pressed;
            if (pressed) {
                m_Rigidbody.MovePosition(pressPos);
            }
            else
            {
                m_Rigidbody.MovePosition(origPos);
            }
        }
    }
}