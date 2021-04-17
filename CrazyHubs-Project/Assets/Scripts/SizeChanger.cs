using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public float loseWeightTime = 0;

    public int meshArrayOrder = 5;
    public int meshArrayDecreaseSize = 0;

    public bool canLoseWeight = true;

    int meeloCatMeshesInOrderLenght = 0;
    
    [SerializeField]
    Mesh[] meeloCatMeshesInOrder;

    [SerializeField]
    SkinnedMeshRenderer currentSkinnedMeshRenderer = default;

    public int meshArrayOrderIncrease(int increaseSize)
    {
        if (meshArrayOrder + increaseSize < meeloCatMeshesInOrderLenght)
        {
            meshArrayOrder += increaseSize;
        }
        else
        {
            meshArrayOrder = meeloCatMeshesInOrderLenght-1;
        }
        return meshArrayOrder;
    }

    public int meshArrayOrderDecrease(int decreaseSize)
    {
        if (meshArrayOrder - decreaseSize >= 0)
        {
            meshArrayOrder -= decreaseSize;
        }
        return meshArrayOrder;
    }

    void Start()
    {
        meeloCatMeshesInOrderLenght = meeloCatMeshesInOrder.Length;

        StartCoroutine(ChangeMesh());
    }

    public void MeshChange()
    {
        currentSkinnedMeshRenderer.sharedMesh = meeloCatMeshesInOrder[meshArrayOrder];
    }

    void StopMeshChanger()
    {
        StopAllCoroutines();
    }

    IEnumerator ChangeMesh()
    {
        while (true)
        {
            if (canLoseWeight)
            {
                yield return new WaitForSeconds(loseWeightTime);
                MeshChange();
                meshArrayOrderDecrease(meshArrayDecreaseSize);
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }


}
