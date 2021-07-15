using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public enum TransitionWhen
    {
        InteractPressed, OnTriggerEnter,
    }


    [SerializeField] private Transform Destination;
    public GameObject ObjTransform;
    bool m_TransitioningGameObjectPresent;
    public TransitionWhen transitionWhen;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == ObjTransform)
        {
            m_TransitioningGameObjectPresent = true;
            if (transitionWhen == TransitionWhen.OnTriggerEnter)
            {
                StartCoroutine(Teleport());
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == ObjTransform)
        {
            m_TransitioningGameObjectPresent = false;

        }

    }

    private void Update()
    {
        if (!m_TransitioningGameObjectPresent)
            return;
    }

    public void InteractTeleport(GameObject obj)
    {
        Test_iPlayerManger manger = obj.GetComponent<Test_iPlayerManger>();
        if (manger)
        {
            if(manger.KeyCount > 0)
            {
                manger.UseKey();
                StartCoroutine(Teleport());

            }
        }
    }


    IEnumerator Teleport()
    {

        yield return new WaitForSeconds(0.2f);
        ObjTransform.transform.position = new Vector2(Destination.position.x, Destination.position.y);
    }

}
