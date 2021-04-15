using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class FoodGainScale : MonoBehaviour
{
    [SerializeField]
    string catTag = default;
    [SerializeField]
    float GainWeightAmounth = 0;

    Vector3 GainWeightScale = Vector3.zero;

    private void Awake()
    {
        GainWeightScale = Vector3.one*GainWeightAmounth;
    }

    private void OnTriggerEnter(Collider Touched)
    {
        if (Touched.CompareTag(catTag))
        {
            GainScaleWitgFood(Touched.gameObject.transform);
        }
    }

    public void GainScaleWitgFood(Transform cat)
    {
        cat.localScale += GainWeightScale;
    }
}
