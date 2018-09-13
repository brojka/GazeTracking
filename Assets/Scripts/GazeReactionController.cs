using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeReactionController : MonoBehaviour
{
    [SerializeField] GazeInputController _gazeInputController;
    [SerializeField] GameObject _objectToManipulate;
    [SerializeField] float _verticalScale = 1f;
    [SerializeField] float _horizontalScale = 1f; 
    [SerializeField] bool _invertAxisX = false;
    [SerializeField] bool _invertAxisY = false;
    [SerializeField] UnityEngine.UI.Text _text;
    [SerializeField] GameObject _gazePointingProp;
    [SerializeField] float _horizontalAngleDeltaThreshold = 10f;
    [SerializeField] float _verticalAngleDeltaThreshold = 2f;
    [SerializeField] float _rotationSpeed = 20f;
    [SerializeField] Vector2 _screenLimitsInWorldPosition;


    private void Start()
    {
        if (_gazeInputController == null)
            _gazeInputController = FindObjectOfType<GazeInputController>();
        if (_objectToManipulate == null)
            _objectToManipulate = gameObject;
         

        StartCoroutine(OnGazeDetected());
    }

    [SerializeField] float _activationDistance = 1f;
    Quaternion _targetRotation;
    private float _angleDelta;


    Vector2 _lookingAngleLimits;

    private IEnumerator OnGazeDetected()
    { 
        _lookingAngleLimits = new Vector2(_gazeInputController.HorizontalLookAtLimit, _gazeInputController.VerticalLookAtLimit);

        _horizontalScale = _screenLimitsInWorldPosition.y / _lookingAngleLimits.y;
        _verticalScale = _screenLimitsInWorldPosition.x / _lookingAngleLimits.x;

        while (true)
        {
            if (_gazeInputController == null || _objectToManipulate == null)
                yield break;

            /*  _targetRotation = Quaternion.Euler(Mathf.Round(_gazeInputController.CurrentVerticalValue * _verticalScale), Mathf.Round(_gazeInputController.CurrentHorizontalValue * _horizontalScale), 0f);

              _angleDelta = Quaternion.Angle(_objectToManipulate.transform.rotation, _targetRotation);
              if (_angleDelta < _activationDistance)
              { 
                  _text.text = "NE BI SE TREBAO VRTITI!";

                  _angleDelta = Mathf.Abs(_objectToManipulate.transform.rotation.x - _targetRotation.x);
                  if (Mathf.Abs(_angleDelta) < _verticalAngleDeltaThreshold)
                      _targetRotation.x = Mathf.Round(_objectToManipulate.transform.eulerAngles.x);

                  _angleDelta = Mathf.Abs(_objectToManipulate.transform.rotation.y - _targetRotation.y);
                  if (Mathf.Abs(_angleDelta) < _horizontalAngleDeltaThreshold)
                      _targetRotation.y = Mathf.Round(_objectToManipulate.transform.eulerAngles.y);
              }
              else
              {
                  _objectToManipulate.transform.rotation = Quaternion.RotateTowards(_objectToManipulate.transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
                  _text.text = "SAD BI SE TREBAO VRTITI!";
              }*/

            _gazePointingProp.transform.position = new Vector3(_gazeInputController.CurrentHorizontalValue * _horizontalScale, -_gazeInputController.CurrentVerticalValue * _verticalScale + 3f, -10f);
            yield return null;
        } 
    }

  /*  private IEnumerator MoveRoutine()
    {
        while (Mathf.Abs(Vector3.Distance(_targetPosition, _objectToManipulate.transform.position)) > _movementActivationMinimumDistance)
        {
            _objectToManipulate.transform.position = Vector3.MoveTowards(_objectToManipulate.transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
            Debug.Log("KREĆEM SE!");
            yield return null;
        }
    }*/
}
