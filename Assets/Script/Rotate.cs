using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 10.0f;     // 회전속도
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);        // 자기 스스로 회전하기
    }
}
