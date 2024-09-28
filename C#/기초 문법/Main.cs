using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// class: 클래스 선언에 사용
public class Main : MonoBehaviour // 유니티 게임 오브젝트 클래스(메인 클래스)
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 1. 변수: int, float, string, bool

        int level = 5;
        float strength = 15.5f; // 항상 f붙이기
        string playerName = "달싹이";
        bool isFullLevel = true; // 논리형 - ture, false

        // 프로그래밍: 선언 > 초기화 > 호출(사용)
        Debug.Log("용사의 이름은?");
        Debug.Log(playerName);
        Debug.Log("용사의 레벨은?");
        Debug.Log(level);
        Debug.Log("용사의 힘은?");
        Debug.Log(strength);
        Debug.Log("용사는 만렙인가?");
        Debug.Log(isFullLevel);


        // 2. 그룹형 변수: 변수들을 묶은 하나의 장소

        // 배열
        string[] monsters = { "슬라임", "악마", "골렘", "오크" };

        Debug.Log("맵에 존재하는 몬스터");
        Debug.Log(monsters[0]);
        Debug.Log(monsters[1]);
        Debug.Log(monsters[2]);

        int[] monsterLevel = new int[4];
        monsterLevel[0] = 1;
        monsterLevel[1] = 23;
        monsterLevel[2] = 42;
        monsterLevel[3] = 25;


        // 리스트: 기능이 추가된 가변형 그룹형 변수
        List<string> items = new List<string>();
        items.Add("생명물약30");
        items.Add("마나물약20");

        Debug.Log("가지고 있는 아이템은?");
        Debug.Log(items[0]);
        Debug.Log(items[1]);

        //items.RemoveAt(0); 0번 인덱스 값을 지워버림 -> 1번 인덱스 값이 0번으로 땡겨지고 1번은 메모리 할당 해제됨
        Debug.Log(items[0]);
        //Debug.Log(items[1]); // index 오류 발생! -> 지워버려서!


        // 3. 연산자
        int exp = 1500;

        exp = 1500 + 320;
        exp = exp - 10;
        level = exp / 300;
        strength = level * 3.1f;

        Debug.Log("용사의 총 경험치는?");
        Debug.Log(exp);
        Debug.Log("용사의 레벨은?");
        Debug.Log(level);
        Debug.Log("용사의 힘은?");
        Debug.Log(strength);

        int nextExp = 300 - (exp % 300);
        Debug.Log("다음 레벨까지 남은 경험치는?");
        Debug.Log(nextExp);

        string title = "전설의";
        Debug.Log("용사의 이름은?");
        Debug.Log(title + " " + playerName);

        int fullLevel = 99;
        isFullLevel = (level == fullLevel);
        Debug.Log("용사는 만렙입니까?" + isFullLevel);

        // 비교 연산자 <, >, <=, >=
        bool isEndTutorial = level > 10;
        Debug.Log("튜토리얼이 끝난 용사입니까? " + isEndTutorial);

        // 논리 연산자 &&(and), ||(or)
        int health = 30;
        int mana = 12;
        bool isBadCondition1 = (health <= 50 && mana <= 20);
        bool isBadCondition2 = (health <= 50 || mana <= 20);
        Debug.Log("용사의 상태가 나쁩니까? " + isBadCondition1);

        // 삼항 연산자 => if문
        string condition = isBadCondition2 ? "나쁨" : "좋음";
        Debug.Log("용사의 상태가 나쁩니까? " + condition);


        // 4. 키워드: 프로그래밍 언어를 구성하는 특별한 단어
        // => int float string bool new List
        // int float = 1;  - 키워드는 직접적으로 변수 이름이나 값으로 사용할 수 없다!
        // string name = List;

        // 5. 조건문: 조건에 만족하면 로직을 실행하는 제어문
        // if문: 조건이 true일 때, 로직 실행 / 앞의 if 조건이 실행되지 않으면 else 실행
        if (condition == "나쁨")
        {
            Debug.Log("플레이어 상태가 나쁘니 아이템을 사용하세요!");
        }
        else
        {
            Debug.Log("플레이어 상태가 좋습니다!");
        }

        // if말고 또 다른 조건일 경우는 else if로 조건 사용, else는 나머지
        if (isBadCondition1 && (items[0] == "생명물약30"))
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("생명 포션 30을 사용하였습니다!");
        }
        else if (isBadCondition1 && (items[1] == "마나물약20"))
        {
            items.RemoveAt(1);
            mana += 20;
            Debug.Log("마나 포션 20을 사용하였습니다!");
        }

        // switch, case: 변수의 값에 따라 로직 실행
        switch (monsters[0])
        {
            case "슬라임":
            case "사막뱀":
                Debug.Log("소형 몬스터가 출현!");
                break;
            case "악마":
                Debug.Log("중형 몬스터가 출현!");
                break;
            case "골렘":
                Debug.Log("대형 몬스터가 출현!");
                break;
            default:
                Debug.Log("??? 몬스터가 출현!");
                break;

        }

        // 6. 반복문: 조건에 만족하면 로직을 반복하는 제어문
        // while: 조건이 true일 때, 로직 반복 실행
        while (health>0)
        {
            health--;
            if (health > 0)
            {
                Debug.Log("독 데미지를 입었습니다. " + health);
            }
            else
            {
                Debug.Log("사망하였습니다.");
            }

            if(health == 10)
            {
                Debug.Log("해독제를 사용합니다.");
                break;
            }
        }

        // for: 변수를 연산하면서 로직 반복 실행
        for (int count = 0; count < 10; count++)
        {
            health++;
            Debug.Log("붕대로 치료 중... " + health); 
        }

        for (int i=0; i<monsters.Length;i++)
        {
            Debug.Log("이 지역에 있는 몬스터 " + monsters[i]);
        }

        // foreach: for의 그룹형 변수 탐색 특환
        foreach (var monster in monsters)
        {
            Debug.Log("이 지역에 있는 몬스터 : " + monster);
        }

        Heal(ref health); // 체력 회복 함수

        for (int i = 0; i < monsters.Length; i++)
        {
            Debug.Log("용사는 " + monsters[i] + "에게 " 
                + Battle(ref monsterLevel[i], ref level));
        }

        // 8. 클래스: 하나의 사물(오브젝트)와 대응하는 로직
        // 인스턴스: 정의된 클래스를 변수 초기화로 실체화
        Player player = new Player();
        player.id = 0;
        player.name = "감싹이";
        player.title = "싹이 난";
        player.strength = 2.4f;
        player.weapon = "새싹 지팡이";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name + "의 레벨은 " + player.level + " 입니다!");

        Debug.Log(player.Move());

    }
    // 전역변수: 함수 밖에 선언된 변수

    // 7. 함수(메소드): 기능을 편리하게 사용하도록 구성된 영역
    // void: 반환 데이터가 없는 함수 타입
    // 지역변수: 함수 안에서 선언된 변수
    void Heal(ref int health)
    {
        health += 10;
        Debug.Log("힐을 받았습니다. " +  health);
        //return: 함수가 값을 반환할 때 사용
    }

    string Battle(ref int monsterLevel, ref int level)
    {
        string result;
        if (level >= monsterLevel)
            result = "이겼습니다!";
        else
            result = "졌습니다!";

        return result;
    }
}