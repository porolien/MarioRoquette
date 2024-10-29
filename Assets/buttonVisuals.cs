using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class buttonVisuals : MonoBehaviour ,ISelectHandler, IDeselectHandler
{
    Vector3 scale;
    [SerializeField] float _scaleMultiplierOnSelected = 1.2f;
    void Awake()
    {
        scale = transform.localScale;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        transform.localScale = scale;

    }

    public void OnSelect(BaseEventData eventData)
    {
        transform.localScale = scale * _scaleMultiplierOnSelected;
    }

}
