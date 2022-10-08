using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public GameObject Target;

    Vector3 TargetPosition;
    Vector3 CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        CameraPosition = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        TargetPosition = Target.transform.position;

        CameraPosition.x = TargetPosition.x;

        transform.position = CameraPosition;
    }
}
