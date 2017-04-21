using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update ()
    {
        transform.Rotate(new Vector3(120, 90, 0) * Time.deltaTime);	
	}
}
