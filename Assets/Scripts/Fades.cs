using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fades : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private float duration;
    private float minAlpha;
    private float maxAlpha = 1;
    private CanvasGroup cg;
    private float t;
    private bool isFaded;

    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponentInChildren<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFaded)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, minAlpha, t);

            if (cg.alpha == minAlpha)
            {
                image.SetActive(false);
            }
            t += duration / Time.deltaTime;
        }

        else if (isFaded)
        {
            image.SetActive(true);
            cg.alpha = Mathf.Lerp(cg.alpha, maxAlpha, t);
            t += duration / Time.deltaTime;
        }
    }

    public void SetFaded()
    {
        isFaded = !isFaded;
        t = 0;
    }
}
