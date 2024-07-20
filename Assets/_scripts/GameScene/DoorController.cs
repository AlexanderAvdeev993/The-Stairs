using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform _doorTransform;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private float _openDuration;
    [SerializeField] private float _closeAngle;
    [SerializeField] private float _openAngle;

    public void CloseDoor()
    {
        Debug.Log("CLoseDoor");
        StartCoroutine(MoveDoorCoroutine(DoorMovedState.Closing));
    }
    public void OpenDoor()
    {
        Debug.Log("OpenDoor");       
        StartCoroutine(MoveDoorCoroutine(DoorMovedState.Opening));
    }
   
    private IEnumerator MoveDoorCoroutine(DoorMovedState state)
    {
        float timer = 0.0f;
        while (timer < _openDuration)
        {
            timer += Time.deltaTime;
            float t = timer / _openDuration;
            float curveValue = _animationCurve.Evaluate(t); 

            _doorTransform.rotation = Quaternion.Lerp(Quaternion.Euler(0, (state == DoorMovedState.Opening) ? _closeAngle : _openAngle, 0),
                                                      Quaternion.Euler(0, (state == DoorMovedState.Opening) ? _openAngle : _closeAngle, 0), 
                                                      curveValue);

            yield return null;
        }

        _doorTransform.rotation = Quaternion.Euler(0, (state == DoorMovedState.Opening) ? _openAngle : _closeAngle, 0);
    }
        
    public enum DoorMovedState
    {
        Opening,
        Closing
    }
}
