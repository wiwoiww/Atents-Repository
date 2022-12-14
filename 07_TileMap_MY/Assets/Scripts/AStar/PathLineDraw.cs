using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슬라임의 경로를 그리기 위한 클래스
public class PathLineDraw : MonoBehaviour
{
    /// <summary>
    /// 경로를 그릴 라인 랜더러
    /// </summary>
    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    /// <summary>
    /// 입력 받은 경로대로 라인 랜더러를 그리는 함수
    /// </summary>
    /// <param name="map">대상 맵</param>
    /// <param name="path">대상 맵에서 움직일 경로</param>
    public void DrawPath(GridMap map, List<Vector2Int> path)
    {
        if (path != null && this.gameObject.activeSelf)     // 경로가 있고 활성화 된 상태에서만 처리
        {
            lineRenderer.positionCount = path.Count;        // 경로 길이에 맞춰 라인 랜더러를 구성하는 점의 숫자 설정
            int index = 0;
            foreach (var node in path)                      // 경로를 하나하나 따라가며
            {
                Vector2 worldPos = map.GridToWorld(node);   // 월드 좌표를 계산
                lineRenderer.SetPosition(index, new(
                    worldPos.x - lineRenderer.transform.position.x,
                    worldPos.y - lineRenderer.transform.position.y,
                    1));    // 라인 랜더러에 설정(라인 랜더러의 Position은 local 좌표로 설정되어야 하기 때문에 변환과정 추가)
                index++;    // 라인 랜더러의 Position의 index 변경
            }
        }
    }

    /// <summary>
    /// 경로를 제거하는 함수
    /// </summary>
    public void ClearPath()
    {
        if (lineRenderer != null)                // 라인랜더러가 있을 떄만 처리(끈 상태로 시작하면 null)
            lineRenderer.positionCount = 0;     // 라인랜더러가 가진 위치 제거
        this.gameObject.SetActive(false);       // 비활성화 시키기
    }
}
