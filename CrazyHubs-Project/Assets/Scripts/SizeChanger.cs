using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public float loseWeightTime = 0;
    public float loseWeightStep = 0;
    public float LoseWeightStopScaleMag = 0;

    public bool canLoseWeight = true;

    Transform catScaleChangeObject = default;

    Vector3 scaleVector = Vector3.zero;

    private void Awake()
    {
        catScaleChangeObject = gameObject.transform;

        scaleVector = catScaleChangeObject.transform.localScale;
    }

    void Start()
    {
        StartCoroutine(ChangeSize());
    }

    void LoseScaleChange()
    {
        if (catScaleChangeObject.localScale.magnitude >= LoseWeightStopScaleMag )
        {
            catScaleChangeObject.localScale -= scaleVector * loseWeightStep;
        }
        else
        {
            StopSizeChanger();
            print("game over");
        }
    }

    void StopSizeChanger()
    {
        StopAllCoroutines();
    }

    IEnumerator ChangeSize()
    {
        while (true)
        {
            if (canLoseWeight)
            {
                yield return new WaitForSeconds(loseWeightTime);
                LoseScaleChange();
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }


}
