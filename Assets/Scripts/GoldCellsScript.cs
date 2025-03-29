using System.Collections;
using UnityEngine;

public class GoldCellsScript : MonoBehaviour
{
    private Material material;
    [SerializeField] private float duration = 1f;
    
    //Réduit progressivement l'alpha du débris pour un disparition smooth :)
    public IEnumerator FadeOut()
    {
        //creation d une instance permettant la modification individuelle
        material = new Material(GetComponent<MeshRenderer>().material);


        Color _color = material.color;
        float _startAlpha = _color.a;
        float _endAlpha = 0.0f;
        float _elapsedTime = 0.0f;

        while (_elapsedTime < duration)
        {
            _elapsedTime += Time.deltaTime;
            float _ratio = Mathf.Lerp(_startAlpha, _endAlpha, _elapsedTime / duration);
            _color.a = _ratio;
            GetComponent<MeshRenderer>().material.color = _color;
            transform.localScale = new Vector3(_ratio, _ratio, _ratio);
            yield return null;
        }

        // Assure que l'alpha est exactement 0 à la fin
        _color.a = _endAlpha;
        material.color = _color;

        //puis on le detruit
        Destroy(gameObject);
    }
}
