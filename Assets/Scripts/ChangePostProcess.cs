using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangePostProcess : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _ppv;
    private float _dissolveDuration = 3f;
    private float _dissolveStrength1;
    private float _dissolveStrength2;
    private Vignette _vignette;

    // Start is called before the first frame update
    void Start()
    {
        _ppv.profile.TryGetSettings(out _vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(VignettePPV());
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(VignetteDefault());
        }
        

                


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
        }
    }

    private IEnumerator VignettePPV()
    {
        float elapsedTime = 0;
        while (elapsedTime < _dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            _dissolveStrength1 = Mathf.Lerp(0.4f, 1f, elapsedTime / _dissolveDuration);
            _vignette.intensity.value = _dissolveStrength1;

            _dissolveStrength2 = Mathf.Lerp(0.4f, 0.6f, elapsedTime / _dissolveDuration);
            _vignette.smoothness.value = _dissolveStrength2;

            yield return null;
        }

    }

    private IEnumerator VignetteDefault()
    {
        float elapsedTime = 0;
        while (elapsedTime < _dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            _dissolveStrength1 = Mathf.Lerp(1, 0.4f, elapsedTime / _dissolveDuration);
            _vignette.intensity.value = _dissolveStrength1;

            _dissolveStrength2 = Mathf.Lerp(0.6f, 0.4f, elapsedTime / _dissolveDuration);
            _vignette.smoothness.value = _dissolveStrength2;

            yield return null;
        }

    }

}
