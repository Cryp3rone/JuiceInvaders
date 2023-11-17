using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtObjRandom : MonoBehaviour
{

    public Sprite[] spriteArray;

    public Transform ObjRandom;

    public Transform[] Positions;

    public float speed;

    public float minWait;
    public float maxWait;

    Transform TargetPos;
    Transform firstPos;
    float timeSinceStarted = 0f;

    Coroutine corout;

    // Start is called before the first frame update
    void Awake()
    {
        GameFeelManager.instance.OnToggleRandomObject.AddListener(RandomObject);
    }

    public void RandomObject(bool b)
    {
        if (!b)
        {
            StopCoroutine(corout); return;
        }
        corout = StartCoroutine(Movement());

    }

    // void Update()
    // {
    //       if(Input.GetKeyDown("w"))
    //     {
    //         StartCoroutine(Movement());
    //     }
    // }


    private void FixedUpdate() 
    {
        
        // ObjRandom.position = Vector3.Lerp(firstPos.position, TargetPos.position, Time.deltaTime);

        timeSinceStarted += Time.deltaTime;
        ObjRandom.position = Vector3.Lerp(ObjRandom.position, TargetPos.position, timeSinceStarted * speed);

    }

    IEnumerator Movement()
    {
        ObjRandom.gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[Random.Range(0, spriteArray.Length -1)];

        timeSinceStarted = 0;
        firstPos = Positions[Random.Range(0, Positions.Length -1)];
        TargetPos = Positions[Random.Range(0, Positions.Length-1)];

        ObjRandom.position = firstPos.position;

        Debug.Log(firstPos.gameObject);
        Debug.Log(TargetPos.gameObject);

        
        
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        corout = StartCoroutine(Movement());
    }

}
