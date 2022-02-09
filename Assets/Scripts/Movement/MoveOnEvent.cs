using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnEvent : MonoBehaviour
{

    [Tooltip("Linearly interpolates between two points")]
    [SerializeField] private float interpolates = 0.1f;
    //[SerializeField] private float speed = 0.1f;

    private bool lerpMove = false;
    private Transform target;

    public bool LerpMove { get => lerpMove; set => lerpMove = value; }
    public Transform Target { get => target; set => target = value; }

    private void FixedUpdate()
    {
        if (LerpMove)
        {
            DoLerpMove(Target);
        }
    }

    public void DoLerpMove(Transform target)
    {
        Target = target;
        StartCoroutine(Lerping());
    }

    IEnumerator Lerping()
    {
        while (Vector3.Distance(transform.position, Target.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, interpolates * Time.deltaTime);
            yield return null;
        }
        LerpMove = false;

        Debug.Log("Reached the Target");
    }
}
