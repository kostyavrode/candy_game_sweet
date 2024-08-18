using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ItemViewer : MonoBehaviour
{
    private bool isInteracting;
    private bool isScaled;
    public void Interact()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            ScaleObject();
            MeshFuck();
        }
        else
        {
            isInteracting = false;
            ScaleObject();
            MeshFuck();
        }
    }
    private void ScaleObject()
    {
        if ( (!isScaled))
        {
            isScaled = true;
            transform.DOScale(Vector3.one * 1.2f, 0.3f);
            return;
        }
        else
        {
            isScaled = false;
            transform.DOScale(Vector3.one, 0.3f);
            return;
        }

    }
    public void Dissapear()
    {
        transform.DOScale(Vector3.zero, 0.3f).OnComplete(DestroyItem);
    }
    private void DestroyItem()
    {
        Destroy(gameObject);
    }
    private void MeshFuck()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Sequence sequence=DOTween.Sequence();
        sequence.Append(meshRenderer.material.DOFade(0.3f, 0.15f));
        sequence.Append(meshRenderer.material.DOFade(1f, 0.15f));
    }
}
