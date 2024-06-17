using System.Collections;
using UnityEngine;

public class CameraRandomPan : MonoBehaviour
{
    public Vector3 min;
    public Vector3 max;
    public float minDistance = 5f;
    public float lerpSpeed = 0.75f;

    private Vector3 _targetPosition;

    private void Start()
    {
        StartRandomPan();
    }

    private void StartRandomPan()
    {
        transform.position = GetNewPosition(minDistance: 1f);
        _targetPosition = GetNewPosition(minDistance: minDistance);
        StartCoroutine(LerpPosition());
    }

    private IEnumerator LerpPosition()
    {
        float time = 0;
        float duration = Vector3.Distance(transform.position, _targetPosition) / lerpSpeed;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, _targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = _targetPosition;
        StartRandomPan();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private Vector3 GetNewPosition(float minDistance)
    {
        var xPos = Random.Range(min.x, max.x);
        var zPos = Random.Range(min.z, max.z);
        var newPosition = new Vector3(xPos, transform.position.y, zPos);

        if (Vector3.Distance(transform.position, newPosition) >= minDistance)
        {
            return newPosition;
        }
        else
        {
            return GetNewPosition(minDistance);
        }
    }
}
