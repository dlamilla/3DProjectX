using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangeTime : MonoBehaviour
{
    public bool titila = false;
    public float timeDelay;

    private Light _light;
    // Start is called before the first frame update
    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (titila == false)
        {
            StartCoroutine(LuzQueTitila());
        }
    }

    IEnumerator LuzQueTitila()
    {
        titila = true;
        _light.intensity = 0f;
        timeDelay = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(timeDelay);
        _light.intensity = 1f;
        timeDelay = Random.Range(1f, 3f);
        yield return new WaitForSeconds(timeDelay);
        _light.intensity = 2f;
        timeDelay = Random.Range(1f, 3f);
        yield return new WaitForSeconds(timeDelay);
        titila = false;


    }
}
