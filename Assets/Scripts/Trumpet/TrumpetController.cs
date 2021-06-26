using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpetController : MonoBehaviour
{
	[Header("References")]
	public Transform[] TrumpetFingerParent = new Transform[3];
    
    private float _timer = -1f;

    private TrumpetPressKey[,] valves = new TrumpetPressKey[3,3];
    

    private IDictionary<string, int> valves2press = new Dictionary<string, int>() {
        {"E3",  7},
        {"F3",  5},
        {"F#3", 6},
        {"G3",  3},
        {"G#3", 1},
        {"A3",  2},
        {"A#3", 0},
        {"B3",  7},
        {"C4",  5},
        {"C#4", 6},
        {"D4",  3},
        {"D#4", 1},
        {"E4",  2},
        {"F4",  0},
        {"F#4", 6},
        {"G4",  3},
        {"G#4", 1},
        {"A4",  2},
        {"A#4", 0},
        {"B4",  3},
        {"C5",  1},
        {"C#5", 2},
        {"D5",  0},
        {"D#5", 1},
        {"E5",  2},
        {"F5",  0},
        {"F#5", 6},
        {"G5",  3},
        {"G#5", 1},
        {"A5",  2},
        {"A#5", 0},
        {"B5",  3},
        {"C6",  5},
        {"C#6", 6},
        {"D6",  3}
    };

    // Start is called before the first frame update
    void Start()
    {   int count=-1;

        foreach (Transform trumpet in TrumpetFingerParent) {
            count++;
            if (trumpet == null) 
                break;
            
            _timer = -1f;

            Transform[] children = trumpet.transform.GetComponentsInChildren<Transform> ();
            foreach (var child in children) {
                if (child.name == "Cylinder_11") 
                    valves[count, 0] = child.GetComponent<TrumpetPressKey>();
                if (child.name == "Cylinder_21") 
                    valves[count, 1] = child.GetComponent<TrumpetPressKey>();;
                if (child.name == "Cylinder_31") 
                    valves[count, 2] = child.GetComponent<TrumpetPressKey>();;
            }

        }
        
    }

    void Update() 
    {
        if (_timer>0)
        {
            _timer -= Time.deltaTime;
            if (_timer<0.01f)
            {
                UnpressValve();
                _timer = -1f;
            }
        }
        

    }

    private void UnpressValve()
    {
        int count=0;
        foreach (Transform trumpet in TrumpetFingerParent) {
            if (trumpet == null) 
                break;
            
            valves[count,0].pressed = false;
            valves[count,1].pressed = false;
            valves[count,2].pressed = false;
        
            count++;
        }
    }

    public void PressValve(string key, float length)
    {
        int count=0;
        int bits = valves2press[key];
        Debug.Log(bits.ToString() + " " + length.ToString());
        foreach (Transform trumpet in TrumpetFingerParent) {
            if (trumpet == null) 
                break;
            _timer = length;
            valves[count,0].pressed = ((bits & 1) != 0);
            valves[count,1].pressed = ((bits & 2) != 0);
            valves[count,2].pressed = ((bits & 4) != 0);
        
            count++;
        }
    }


}
