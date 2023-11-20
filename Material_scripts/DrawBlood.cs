using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBlood : MonoBehaviour
{
    public Renderer bloodRend;
    [SerializeField] float _bloodDrawTime;
    float elapsedTime;
    bool canDraw;
    [SerializeField] GameObject piston;
    void Start()
    {
        bloodRend = GetComponent<Renderer>();
        canDraw = false;
    }
    void Update()
    {
        if(canDraw)
        {
            StartCoroutine(PhlebotomyRoutine());
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            canDraw = true;
        }
    }
    IEnumerator PhlebotomyRoutine()
    {
        yield return null;
        PerformPhlebotomy();
    }

    void PerformPhlebotomy()
    {
        elapsedTime += Time.deltaTime;
        bloodRend.material.SetFloat("_fill", Mathf.Lerp(0.30f, 0.38f, elapsedTime/_bloodDrawTime));
        piston.transform.localPosition = new Vector3(
            piston.transform.localPosition.x,
            Mathf.Lerp(-0.08599773f, -0.1424f, elapsedTime/_bloodDrawTime ), //original position -0.08599773
            piston.transform.localPosition.z
            
        );
    }
}
