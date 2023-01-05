using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    /// <summary>
    /// 맵의 세로 갯수
    /// </summary>
    const int HeightCount = 3;

    /// <summary>
    /// 맵의 가로 갯수
    /// </summary>
    const int WidthCount = 3;

    const float mapHeightLength = 20.0f;
    const float mapWidthLength = 20.0f;

    readonly Vector2 totalOrigin = new Vector2(-mapWidthLength * WidthCount * 0.5f, -mapHeightLength * HeightCount * 0.5f); // 맵 전체 길이의 절반

    /// <summary>
    /// 씬 이름 조합에 사용할 기본 이름
    /// </summary>
    const string SceneNameBase = "Seemless";

    /// <summary>
    /// 모든 씬들의 이름
    /// </summary>
    string[] sceneNames;

    /// <summary>
    /// 씬의 로딩 상태를 나타낼 enum
    /// </summary>
    enum SceneLoadState : byte
    {
        Unload = 0,     // 로딩이 안되어있음
        PendingUnload,  // 로딩 해제 중이다.
        PendingLoad,    // 로딩 중이다.
        Loaded          // 로딩이 완료되었음
    }

    /// <summary>
    /// 각 씬들의 로딩 상태
    /// </summary>
    SceneLoadState[] sceneLoadState;

    /// <summary>
    /// 초기화 함수(단 한번만 실행)
    /// </summary>
    public void Initialize()
    {
        // 맵의 갯수에 맞게 배열 생성
        sceneNames = new string[HeightCount * WidthCount];
        sceneLoadState = new SceneLoadState[HeightCount * WidthCount];

        for (int y = 0; y < HeightCount; y++)
        {
            for (int x = 0; x < WidthCount; x++)
            {
                int index = GetIndex(x, y);
                sceneNames[index] = $"{SceneNameBase}_{x}_{y}";     // 각 씬의 이름 설정
                sceneLoadState[index] = SceneLoadState.Unload;      // 각 씬의 로딩 상태 초기화
            }
        }

        Player player = GameManager.Inst.Player;
        Vector2Int grid = WorldToGrid(player.transform.position);
        RequestAsyncSceneLoad(grid.x, grid.y);
        RefreshScenes(grid.x, grid.y);
    }

    /// <summary>
    /// x, y 그리드 좌표를 인덱스로 변환해주는 함수
    /// </summary>
    /// <param name="x">x 좌표</param>
    /// <param name="y">y 좌표</param>
    /// <returns>좌표에 해당하는 인덱스</returns>
    int GetIndex(int x, int y)
    {
        return x + WidthCount * y;
    }

    /// <summary>
    /// 인덱스를 x,y 그리드 좌표로 변경해주는 함수
    /// </summary>
    /// <param name="index">인덱스 값</param>
    /// <returns>인덱스에 해당하는 그리드 좌표</returns>
    Vector2Int GetGrid(int index)
    {
        return new Vector2Int(index % WidthCount, index / WidthCount);
    }

    /// <summary>
    /// 지정된 좌표에 해당하는 맵을 비동기로 로딩 시작
    /// </summary>
    /// <param name="x">그리드 x좌표</param>
    /// <param name="y">그리드 y좌표</param>
    void RequestAsyncSceneLoad(int x, int y)
    {
        int index = GetIndex(x, y);                         // 인덱스 계산
        if (sceneLoadState[index] == SceneLoadState.Unload) // 해당 맵이 Unload 상태일 때만 로딩 시도
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneNames[index], LoadSceneMode.Additive);  // 비동기 로딩 시작
            async.completed += (_) => sceneLoadState[index] = SceneLoadState.Loaded;                        // 로딩이 완료되면 Loaded로 상태 변경
            sceneLoadState[index] = SceneLoadState.PendingLoad;                                             // 로딩 시작 표시
        }
    }

    /// <summary>
    /// 지정된 좌표에 해당하는 맵을 비동기로 로딩해제 시작
    /// </summary>
    /// <param name="x">그리드 x좌표</param>
    /// <param name="y">그리드 y좌표</param>
    void RequestAsyncSceneUnload(int x, int y)
    {
        int index = GetIndex(x, y);                         // 인덱스 계산
        if (sceneLoadState[index] == SceneLoadState.Loaded) // 해당 맵이 Load 상태일 때만 로딩해제 시도
        {
            AsyncOperation async = SceneManager.UnloadSceneAsync(sceneNames[index]);    // 비동기 로딩해제 시작
            async.completed += (_) => sceneLoadState[index] = SceneLoadState.Unload;    // 로딩이 완료되면 Unload로 상태 변경
            sceneLoadState[index] = SceneLoadState.PendingUnload;                       // 로딩해제 시작 표시
        }
    }

    /// <summary>
    /// 입력 받은 월드좌표가 어떤 그리드좌표인지 알려주는 함수
    /// </summary>
    /// <param name="worldPos">확인할 월드좌표</param>
    /// <returns>변환된 그리드 좌표</returns>
    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        Vector2 offset = (Vector2)worldPos - totalOrigin;   // 전체맵의 원점에서 얼마나 떨어졌는지 계산
        return new Vector2Int((int)(offset.x / mapWidthLength), (int)(offset.y / mapHeightLength)); // 몇번째 맵에 해당하는지 확인
    }

    void RefreshScenes(int x, int y)
    {

    }

    // 테스트용 -----------------------------------------------------------------------------------
    public void Test_LoadScene(int x, int y)
    {
        RequestAsyncSceneLoad(x, y);
    }

    public void Test_UnloadScene(int x, int y)
    {
        RequestAsyncSceneUnload(x, y);
    }
}
