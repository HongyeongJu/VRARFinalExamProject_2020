using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftLife : MonoBehaviour
{
    public int target = 1;
    // 물건 줄 위치 객체등록
    private GameObject plane;
    private GameObject aPersonSpot;
    private GameObject bPersonSpot;
    private GameObject cPersonSpot;
    private GameObject dPersonSpot;
    // Start is called before the first frame update
    void Start()
    {
        // 태그를 통해서 물건을 배달해줄 위치 추적
        plane = GameObject.FindWithTag("Plain");
        aPersonSpot = GameObject.FindWithTag("aPerson");
        bPersonSpot = GameObject.FindWithTag("bPerson");
        cPersonSpot = GameObject.FindWithTag("cPerson");
        dPersonSpot = GameObject.FindWithTag("dPerson");

        // 선물을 생성되고 3초뒤 삭제
        Destroy(gameObject, 3.0f);      // 충돌이 발생하고 5초뒤 삭제
    }

    // Update is called once per frame
    void Update()
    {
        if(target == 1)     // 타겟의 번호를 통해서 누구한테 줄지 결정
        {
            float dist = Vector3.Distance(transform.position, aPersonSpot.transform.position);      // 타겟의 위치와 현재 위치의 차이를 구해서 1.0f 이하이면 움직이지 않도록만들기.
            if(dist > 1.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, aPersonSpot.transform.position, Time.deltaTime * 4.0f);
            }
        }
        else if(target == 2)
        {
            float dist = Vector3.Distance(transform.position, bPersonSpot.transform.position);  // 타겟의 위치와 현재 위치의 차이를 구해서 1.0f 이하이면 움직이지 않도록만들기.
            if (dist > 1.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, bPersonSpot.transform.position, Time.deltaTime * 4.0f);
            }
        }
        else if(target == 3)
        {
            float dist = Vector3.Distance(transform.position, cPersonSpot.transform.position);   // 타겟의 위치와 현재 위치의 차이를 구해서 1.0f 이하이면 움직이지 않도록만들기.
            if (dist > 1.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, cPersonSpot.transform.position, Time.deltaTime * 4.0f);
            }
        }
        else
        {
            float dist = Vector3.Distance(transform.position, dPersonSpot.transform.position);     // 타겟의 위치와 현재 위치의 차이를 구해서 1.0f 이하이면 움직이지 않도록만들기.
            if (dist > 1.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, dPersonSpot.transform.position, Time.deltaTime * 4.0f);
            }
        }
    }
}
