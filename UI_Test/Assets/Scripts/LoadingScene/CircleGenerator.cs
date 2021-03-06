using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleGenerator : MonoBehaviour
{   
    private int count;
    private int maxCount;
    private GameObject tempCircle;

    public GameObject circleObjectPrefab;
    public Queue<GameObject> activeCirclePool;
    public Queue<GameObject> deactiveCirclePool;

    void Start()
    {
        count = 0;
        maxCount = 6;
        activeCirclePool = new Queue<GameObject>();
        deactiveCirclePool = new Queue<GameObject>();

        StartCoroutine(nameof(InstantiateCircle));
    }

    IEnumerator InstantiateCircle()
    {
        while (true)
        {
            if (count == maxCount) count = maxCount;
            else count++;

            tempCircle = Instantiate(circleObjectPrefab, Vector3.zero, Quaternion.identity, transform);
            tempCircle.SetActive(false);
            deactiveCirclePool.Enqueue(tempCircle);

            if (count == maxCount)
            {
                yield return new WaitForSeconds(1f);
                StartCoroutine(nameof(GenerateCircle));
                yield break;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator DestroyCircle()
    {
        while (true)
        {
            if (activeCirclePool.Count == 0)
            {
                yield return new WaitForSeconds(0.2f);
                StartCoroutine(nameof(GenerateCircle));
                yield break;
            }
            else
            {
                tempCircle = activeCirclePool.Dequeue();
                tempCircle.SetActive(false);
                deactiveCirclePool.Enqueue(tempCircle);

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    IEnumerator GenerateCircle()
    {
        while (true)
        {
            if (deactiveCirclePool.Count == 0)
            {
                yield return new WaitForSeconds(1.4f);
                StartCoroutine(nameof(DestroyCircle));
                yield break;
            }
            else
            {
                tempCircle = deactiveCirclePool.Dequeue();
                tempCircle.SetActive(true);
                activeCirclePool.Enqueue(tempCircle);

                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
