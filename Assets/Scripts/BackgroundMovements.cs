using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMovements : MonoBehaviour
{
    [SerializeField] private RawImage imageForBackground;
    [SerializeField] private float _x, _y;
    private void Start()
    {
        StartCoroutine(Randomize());
    }
    void Update()
    {
       imageForBackground.uvRect = new Rect(imageForBackground.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, imageForBackground.uvRect.size);
    }
    IEnumerator Randomize()
    {
        while (true)
        {
            _x = Random.Range(-0.04f, 0.04f);
            _y = Random.Range(-0.04f, 0.04f);
            yield return new WaitForSeconds(15f);
        }
    }
}
