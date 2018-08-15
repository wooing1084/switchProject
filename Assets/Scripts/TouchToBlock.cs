using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchToBlock : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 pos = Input.GetTouch(0).position;    // 터치한 위치
            Vector3 theTouch = new Vector3(pos.x, pos.y, 0.0f);    
            /* 터치는 2차원 좌표를 받기 때문에 pos로 터치한 위치를 받고
             theTouch로 3차원 좌표로 변환함 */
            Ray ray = Camera.main.ScreenPointToRay(theTouch);    // 터치한 좌표 정보를 ray에 저장
            RaycastHit hit;    // 정보 저장할 구조체    
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)    // 처음 터치 이벤트
                {
                    Debug.Log("터치됨"); //Log를 호출
                    SceneManager.LoadScene(1);
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)    // 터치 후 움직이면 이벤트
                {
                    // 아직 사용X
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)    // 터치 종료시 이벤트
                {
                    // 아직 사용X
                }
            }
        }
    }
}