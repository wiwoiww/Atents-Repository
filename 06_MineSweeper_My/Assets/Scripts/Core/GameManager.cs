#define TEST_CODE

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 게임 상태 관련 ------------------------------------------------------------------------------
    enum GameState
    {
        Ready = 0,  // 게임 시작전(첫번째 셀이 안열린 상황)
        Play,       // 게임 진행 중
        GameClear,  // 모든 지뢰를 찾았을 때
        GameOver    // 지뢰가 있는 셀을 열었을 때
    }

    GameState state = GameState.Ready;

    /// <summary>
    /// 게임이 진행중인지 확인하는 프로퍼티.
    /// </summary>
    public bool IsPlaying => state == GameState.Play;

    /// <summary>
    /// Play 상태로 들어갔을 때 실행될 델리게이트.
    /// </summary>
    public Action onGameStart;

    /// <summary>
    /// 게임이 재시작될 때 실행될 델리게이트(리셋버튼 눌렀을 때 실행. 보드 초기화 될 때. Ready 상태로 변경)
    /// </summary>
    public Action onGameReset;

    /// <summary>
    /// GameClear 상태로 들어갔을 때 실행될 델리게이트.
    /// </summary>
    public Action onGameClear;

    /// <summary>
    /// GameOver 상태로 들어갔을 때 실행될 델리게이트.
    /// </summary>
    public Action onGameOver;


    // 깃발 갯수 관련 ------------------------------------------------------------------------------
    private int flagCount = 0;
    public int FlagCount
    {
        get => flagCount;
        private set
        {
            flagCount = value;
            onFlagCountChange?.Invoke(flagCount);
            //Debug.Log($"현재 깃발 갯수 : {flagCount}");
        }
    }
    public Action<int> onFlagCountChange;

    // 난이도 관련 ---------------------------------------------------------------------------------
    public int mineCount = 10;
    public int boardWidth = 8;
    public int boardHeight = 8;
    private Board board;

    public Board Board => board;

    // 랭킹 관련 -----------------------------------------------------------------------------------
    RankData rankData;
    public RankData RankData => rankData;

    // UI 관련 ------------------------------------------------------------------------------------

    /// <summary>
    /// 주의) 반드시 프로퍼티로만 사용할 것. 
    /// 플레이어가 이번 판에서 했던 행동 횟수. 
    /// </summary>
    private int actionCount = 0;

    /// <summary>
    /// 플레이어가 이번 판에서 했던 행동 횟수용 프로퍼티.
    /// </summary>
    public int ActionCount
    {
        get => actionCount;
        private set
        {
            if (actionCount != value)
            {
                actionCount = value;
                onActionCountChange?.Invoke(actionCount);
                //Debug.Log($"Action Count : {actionCount}");
            }
        }
    }

    /// <summary>
    /// 행동 횟수가 변경될 때 실행될 델리게이트
    /// </summary>
    public Action<int> onActionCountChange;

    Timer timer;
    public float PlayTime => timer.ElapsedTime;


    // 함수 ---------------------------------------------------------------------------------------
    protected override void Initialize()
    {
        base.Initialize();

        FlagCount = mineCount;
        ActionCount = 0;

        board = FindObjectOfType<Board>();
        board.Initialize(boardWidth, boardHeight, mineCount);

        timer = FindObjectOfType<Timer>();

        rankData = GetComponent<RankData>();
    }

    public void IncreaseFlagCount()
    {
        FlagCount++;
    }

    public void DecreaseFlagCount()
    {
        FlagCount--;
    }

    public void GameStart()
    {
        if (state == GameState.Ready)
        {
            state = GameState.Play;
            onGameStart?.Invoke();
            //Debug.Log("Play 상태");
        }
    }

    public void GameReset()
    {
        state = GameState.Ready;
        FlagCount = mineCount;
        ActionCount = 0;
        onGameReset?.Invoke();
        //Debug.Log("Ready 상태");
    }

    public void GameClear()
    {
        state = GameState.GameClear;
        onGameClear?.Invoke();
        //Debug.Log("Clear 상태");
    }

    public void GameOver()
    {
        state = GameState.GameOver;
        onGameOver?.Invoke();
        //Debug.Log("GameOver 상태");
    }

    /// <summary>
    /// 플레이어의 행동이 끝날 때 실행될 함수
    /// </summary>
    public void FinishPlayerAction()
    {
        ActionCount++;

        // 클리어 조건을 만족시키는지 확인
        if (flagCount == 0 && ((Board.OpenCellCount + Board.FoundMineCount) == boardWidth * boardHeight))
        {
            GameClear();
        }
    }

#if TEST_CODE
    public void TestFlag_Increase()
    {
        FlagCount++;
    }

    public void TestFlag_Decrease()
    {
        FlagCount--;
    }
#endif
}
