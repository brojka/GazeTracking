using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionX8 { Center, Down, LeftDown, Left, LeftUp, Up, RightUp, Right, RightDown}

public class GazeInputController : MonoBehaviour
{
    [SerializeField] VisageTracker _tracker; 
    [SerializeField] float _horizontalLookAtScale;
    [SerializeField] float _horizontalLookAtLimit;
    [SerializeField] float _verticalLookAtScale;
    [SerializeField] float _verticalLookAtLimit;
    [SerializeField] float _currentHorizontalValue;
    [SerializeField] float _currentVerticalValue; 



    public float CurrentVerticalValue
    {
        get
        {
            return _currentVerticalValue;
        } 
    }
    public float CurrentHorizontalValue
    {
        get
        {
            return _currentHorizontalValue;
        } 
    }

    public float VerticalLookAtLimit
    {
        get
        {
            return _verticalLookAtLimit;
        } 
    }

    public float HorizontalLookAtLimit
    {
        get
        {
            return _horizontalLookAtLimit;
        } 
    }

    private void Start()
    {
        StartCoroutine(DetectGazeDirection());
    }

    private IEnumerator DetectGazeDirection()
    {
        while (true)
        {
            _currentHorizontalValue = Mathf.Clamp(_tracker.GazeDirection.x * _horizontalLookAtScale, -_horizontalLookAtLimit, _horizontalLookAtLimit);
            _currentVerticalValue = Mathf.Clamp(_tracker.GazeDirection.y * _verticalLookAtScale, -_verticalLookAtLimit, _verticalLookAtLimit);

            yield return null;
        }
    } 
}
