using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftDrop : MonoBehaviour
{

    public GameObject spot;     // 선물이 떨어지는 장소 객체
    public GameObject gift;      // 선물 객체
    bool isGift = false;            // 선물을 주었는지 판단
    
    // 산타가 선물주는 지점에 닿았을때 실행되는 콜백함수
    private void OnTriggerEnter(Collider other)
    {
        GiftLife mGiftLife = gift.GetComponent<GiftLife>();
        if (other.CompareTag("a"))          // 태그를 통해 누구한테 줄지 결정
        {
            mGiftLife.target = 1;
        }else if (other.CompareTag("b")){
            mGiftLife.target = 2;
        }
        else if (other.CompareTag("c"))
        {
            mGiftLife.target = 3;
        }
        else
        {
            mGiftLife.target = 4;
        }

        if (!isGift)        // 선물을 안주었다면 선물주기
        {
            isGift = true;
            StartCoroutine(DropGift());     // 3초간 딜레이를 주면서 선물주도록 만드는 코루틴
        }
    }

    // 딜레이를 주면서 선물을 주는 함수
    IEnumerator DropGift()
    {
        Debug.Log("선물 나눠주는 이벤트 발생");
        Instantiate(gift, spot.transform.position, Quaternion.identity);  // 선물 객체를 생성하기
        yield return new WaitForSeconds(3.0f);
        isGift = false;
    }
}
