using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    //[SerializeField] private GameObject _effect;
    [Header("Item")]
    [SerializeField] private float _cont;
    //[SerializeField] private Collection _collection;

    [Header("Shader")]
    [SerializeField] private Material _dissolve;
    [SerializeField] private float _dissolveDuration = 2f;
    [SerializeField] private float _dissolveStrength;

    [Header("Colores")]
    [SerializeField] private Color starColor;
    [SerializeField] private Color endColor;

    [Header("Sonido")]
    [SerializeField] private AudioClip _sound;
    
    // Start is called before the first frame update
    void Start()
    {
        _dissolve.SetFloat("_DissolveStrength", 0f);
        _dissolve.SetColor("_Color", starColor);
    }

    public void ItemCollect()
    {
        StartCoroutine(Dissolver());
    }
  

    public IEnumerator Dissolver()
    {
        float elapsedTime = 0;
        Color lerpedColor;
        AudioController.Instance.PlaySound(_sound);
        while (elapsedTime < _dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            _dissolveStrength = Mathf.Lerp(0, 1, elapsedTime / _dissolveDuration);
            _dissolve.SetFloat("_DissolveStrength", _dissolveStrength);

            lerpedColor = Color.Lerp(starColor, endColor, _dissolveStrength);
            _dissolve.SetColor("_Color", lerpedColor);
            yield return null;
        }
        //_collection.ItemSum(_cont);
        
        //this.gameObject.SetActive(false);
    }
}
