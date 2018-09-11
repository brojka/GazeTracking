using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadInputController : MonoBehaviour
{
    [SerializeField] VisageTracker _tracker;
    [SerializeField] GameObject _cube;
    [SerializeField] float _speed = 10f;

    private void Update()
    {
        if (_tracker.Rotation.y > -180f)
            _cube.transform.Rotate(Vector3.up * Time.deltaTime * _speed);
        else
            _cube.transform.Rotate(Vector3.up * Time.deltaTime * -_speed);
    }

}
