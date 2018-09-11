using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeReactionController : MonoBehaviour
{
    [SerializeField] GazeInputController _gazeInputController;
    [SerializeField] GameObject _objectToManipulate;
    [SerializeField] float _verticalScale = 1f;
    [SerializeField] float _horizontalScale = 1f;
    [SerializeField] float _horizontalPositionLimit = 10f;
    [SerializeField] float _verticalPositionLimit = 5f;
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _movementActivationMinimumDistance = 3f;
    [SerializeField] bool _invertAxisX = false;
    [SerializeField] bool _invertAxisY = false;
    [SerializeField] UnityEngine.UI.Text _text;
    [SerializeField] GameObject _gazePointingProp;
    [SerializeField] float _offset = 10f;


    private void Start()
    {
        if (_gazeInputController == null)
            _gazeInputController = FindObjectOfType<GazeInputController>();
        if (_objectToManipulate == null)
            _objectToManipulate = gameObject;
         

        StartCoroutine(OnGazeDetected());
    }

    private float a = 0f;
    private float b = 0f; 

    private IEnumerator OnGazeDetected()
    {
        while (true)
        {
            if (_gazeInputController == null || _objectToManipulate == null)
                yield break;
       
            _objectToManipulate.transform.localRotation = Quaternion.AngleAxis(-_gazeInputController.CurrentHorizontalValue, Vector3.up) * Quaternion.AngleAxis(-_gazeInputController.CurrentVerticalValue, Vector3.right);
               
            a = _gazeInputController.CurrentHorizontalValue;
            b = _gazeInputController.CurrentVerticalValue;


            yield return new WaitWhile(() => Mathf.Abs(_gazeInputController.CurrentHorizontalValue - a) < _offset || Mathf.Abs(_gazeInputController.CurrentVerticalValue - b) < _offset);

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
