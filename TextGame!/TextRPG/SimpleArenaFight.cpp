/*
Title  : Simple Arena Fight Game
author : Dalssak
github : https://github.com/j1sung
*/

#include <iostream>
#include <vector>
using namespace std;

enum PlayerType
{
	PT_None = 0, // 유효하지 않은 상태를 나타내기 위한 값
	PT_Knight = 1,
	PT_Archer = 2,
	PT_Mage = 3,
};

enum MonsterType
{
	MT_None = 0,
	MT_Slime = 1,
	MT_Orc = 2,
	MT_Skeleton = 3,
};

struct StatInfo
{
	int hp;
	int attack;
	int defence;
};

// 점점 추가될 예정이므로 하나로 묶어주는게 좋음 -> heap 영역으로 동적으로 묶어줌(Class)
// C#에선 enum타입과 int가 타입이 달라서 구별해야 하지만 C++에선 둘 다 같으므로 int로 써도 무방
PlayerType playerType = PT_None; // 플레이어 직업 저장 -> 직업에 따라서 모습이 달라지므로 필요!
StatInfo playerStat;

MonsterType monsterType = MT_None; // 몬스터 종류 저장 -> 종류에 따라 다른 리소스 필요
StatInfo monsterStat;

int killCount = 0; // 몬스터 처치 수 기록
vector<int> storage; // 전생 몬스터 처치 수 기록

void EnterLobby();
void SelectPlayer();
void EnterArena();
void CreateRandomMonster();
void EnterBattle();
void WaitForNextKey();
void KillCount();

// ============================================================
// <함수 정리>
// 1. EnterLobby() - 로비 입장 - [아레나 or 게임 종료]
// 2. SelectPlayr() - 직업 선택
// 3. EnterArena() - 아레나 입장 - 전투
// 4. CreateRandomMonster() - 랜덤 몬스터 스폰
// 5. EnterBattle(); - 몬스터와 턴제 전투(플레이어 우선 공격)
// 6. WaitForNextKey(); - 게임 씬 전환 전 선택 메시지
// 7. KillCount() - 몬스터 처치 수 집계, 전생 처치 수 기록
// ============================================================
int main()
{
	srand((unsigned int)time(0)); // 현재시간 시드로 랜덤 알고리즘 설정
	EnterLobby();

	return 0;
}

void EnterLobby()
{
	while (true)
	{
		cout << "------------------------------" << endl;
		cout << "로비에 오신 것을 환영합니다!" << endl;
		cout << "------------------------------" << endl;

		// 플레이어 직업 선택 - 함수에 관련없는 기능은 따로 함수 빼기
		if (playerType == PT_None) // 직업 선택은 한번만 해야하는데... 무한루프 피하기!
		{
			SelectPlayer();
		}

		cout << "---------------------------------------------" << endl;
		cout << "1) 아레나 입장 2) 몬스터 처치 수 3) 게임 종료" << endl;
		cout << "---------------------------------------------" << endl;

		int enter;
		cin >> enter;

		if (enter == 1)
		{
			EnterArena();
		}
		else if (enter == 2)
		{
			KillCount();
		}
		else if (enter == 3)
		{
			return;
		}

	}
}

void SelectPlayer()
{
	while (true)
	{
		cout << "------------------------------" << endl;
		cout << "당신의 직업을 골라주세요!" << endl;
		cout << "1) 기사 2) 궁수 3) 마법사" << endl;
		cout << "------------------------------" << endl;
		cout << ">> ";

		int choice;
		cin >> choice;


		if (choice == PT_Knight)
		{
			cout << "기사 캐릭터 생성중..." << endl << endl;
			playerType = (PlayerType)choice; // 직업 설정

			// 기초 스텟 설정
			playerStat.hp = 150;
			playerStat.attack = 10;
			playerStat.defence = 5;

			break;
		}
		else if (choice == PT_Archer)
		{
			cout << "궁수 캐릭터 생성중..." << endl << endl;
			playerType = (PlayerType)choice; // 직업 설정

			// 기초 스텟 설정
			playerStat.hp = 100;
			playerStat.attack = 15;
			playerStat.defence = 3;

			break;
		}
		else if (choice == PT_Mage)
		{
			cout << "마법사 캐릭터 생성중..." << endl << endl;
			playerType = (PlayerType)choice; // 직업 설정

			// 기초 스텟 설정
			playerStat.hp = 80;
			playerStat.attack = 25;
			playerStat.defence = 0;

			break;
		}
		else
		{	// 직업 설정 안하고 PT_NONE이 그대로 있음
			cout << "존재하는 직업 중 선택 해 주세요!" << endl;
		}
	}
	switch (playerType)
	{
	case PT_Knight:
		cout << "당신의 직업은 <기사> 입니다!" << endl;
		break;
	case PT_Archer:
		cout << "당신의 직업은 <궁수> 입니다!" << endl;
		break;
	case PT_Mage:
		cout << "당신의 직업은 <마법사> 입니다!" << endl;
		break;
	}

}

void EnterArena()
{
	system("cls");
	cout << "------------------------------" << endl;
	cout << "아레나에 오신 것을 환영합니다!" << endl;
	cout << "------------------------------" << endl;

	while (true)
	{
		// 플레이어 스텟 정보
		cout << "[PLAYER] HP : " << playerStat.hp << "/ ATT : " << playerStat.attack << "/ DEF : " << playerStat.defence << endl << endl;

		// 몬스터 스폰
		CreateRandomMonster();

		cout << "------------------------------" << endl;
		cout << "전투가 시작 됐습니다!" << endl;
		cout << "1) 전투 2) 도주" << endl;
		cout << ">> ";

		int input;
		cin >> input;

		if (input == 1)
		{
			EnterBattle();
			if (playerStat.hp == 0)
			{
				playerType = PT_None;
				return;
			}
		}
		else if (input == 2)
		{
			system("cls");
			return;
		}
		else
		{
			cout << "목숨이 아깝지 않다면 정신 차리세요!" << endl;
		}
	}


}

void CreateRandomMonster()
{

	int randomSpawn = 1 + rand() % 3; // 1, 2, 3 중에 하나 랜덤 선택

	switch (randomSpawn)
	{
	case MT_Slime:
		cout << "슬라임 생성중...!" << endl;
		monsterType = (MonsterType)randomSpawn; // 몬스터 종류 설정

		// 몬스터 기초 스텟 설정
		monsterStat.hp = 30;
		monsterStat.attack = 2;
		monsterStat.defence = 0;

		break;

	case MT_Orc:
		cout << "오크 생성중...!" << endl;
		monsterType = (MonsterType)randomSpawn; // 몬스터 종류 설정

		// 몬스터 기초 스텟 설정
		monsterStat.hp = 80;
		monsterStat.attack = 10;
		monsterStat.defence = 5;

		break;

	case MT_Skeleton:
		cout << "해골 생성중...!" << endl;
		monsterType = (MonsterType)randomSpawn; // 몬스터 종류 설정

		// 몬스터 기초 스텟 설정
		monsterStat.hp = 50;
		monsterStat.attack = 13;
		monsterStat.defence = 3;

		break;
	}
	cout << "[Monster] HP : " << monsterStat.hp << "/ ATT : " << monsterStat.attack << "/ DEF : " << monsterStat.defence << endl;


}

void EnterBattle()
{
	while (true)
	{
		int damage = playerStat.attack - monsterStat.defence;

		if (damage < 0) // 방어력을 뚫지 못하면 공격력 0 맞추기
			damage = 0;

		// 플레이어 공격
		cout << "당신이 공격합니다!" << endl;
		monsterStat.hp -= damage;

		if (monsterStat.hp < 0)
			monsterStat.hp = 0;

		cout << "몬스터 남은 체력 : " << monsterStat.hp << endl << endl;

		if (monsterStat.hp == 0)
		{
			cout << "몬스터를 처치 하였습니다!" << endl;
			cout << "Hp가 일부 회복됩니다!" << endl << endl;
			playerStat.hp += 5;
			::killCount++; // 몬스터 처치 기록

			WaitForNextKey();
			return;
		}

		// 몬스터의 공격
		damage = monsterStat.attack - playerStat.defence;

		if (damage < 0) // 방어력을 뚫지 못하면 공격력 0 맞추기
			damage = 0;

		cout << "몬스터가 공격합니다!" << endl;
		playerStat.hp -= damage;

		if (playerStat.hp < 0)
			playerStat.hp = 0;

		cout << "당신의 남은 체력 : " << playerStat.hp << endl << endl;

		if (playerStat.hp == 0)
		{
			cout << "당신은 몬스터에게 죽었습니다!" << endl << endl;
			storage.push_back(::killCount); // 명예의 전당 기록
			::killCount = 0; // 몬스터 처치 수 초기화
			WaitForNextKey();
			return;
		}

	}

}

void WaitForNextKey()
{
	cout << "계속하시려면 1을 누르세요" << endl;
	cout << ">> " << endl;

	int input;
	cin >> input;

	system("cls");
}


void KillCount()
{
	system("cls");
	cout << "------------------------------" << endl;
	cout << "당신의 몬스터 처치 수 : " << ::killCount << endl;
	cout << "------------------------------" << endl;
	cout << "<전생의 기록>" << endl;
	if (storage.size() == 0)
		cout << "당신이 첫번째 기록의 주인공!" << endl;
	for (int i = 0; i < storage.size(); i++)
	{
		cout << i+1 << "번째 당신 기록 : " << storage[i] <<"마리" << endl;
	}
	cout << "------------------------------" << endl;
	WaitForNextKey();
}