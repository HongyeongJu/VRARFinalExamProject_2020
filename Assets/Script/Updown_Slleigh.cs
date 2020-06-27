using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updown_Slleigh : MonoBehaviour
{

    public float speed = 0.1f;          // 위아래 움직일 속도
    public bool isUp = false;              // 위로 향할 차례인가?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUp)       // 위로 향해야된다면 위로 움직이기
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }else           // 아래로 움직여야된다면 아래로 움직이기
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (speed > 2.0f)           // 스피드가 2.0f 이상이면 움직임 반전
        {
            isUp = !isUp;
            speed = 0.0f;
        }
        else
        {
            speed += 0.05f;
        }
    }
}
