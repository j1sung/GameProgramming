using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// class: Ŭ���� ���� ���
public class Main : MonoBehaviour // ����Ƽ ���� ������Ʈ Ŭ����(���� Ŭ����)
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 1. ����: int, float, string, bool

        int level = 5;
        float strength = 15.5f; // �׻� f���̱�
        string playerName = "�޽���";
        bool isFullLevel = true; // ���� - ture, false

        // ���α׷���: ���� > �ʱ�ȭ > ȣ��(���)
        Debug.Log("����� �̸���?");
        Debug.Log(playerName);
        Debug.Log("����� ������?");
        Debug.Log(level);
        Debug.Log("����� ����?");
        Debug.Log(strength);
        Debug.Log("���� �����ΰ�?");
        Debug.Log(isFullLevel);


        // 2. �׷��� ����: �������� ���� �ϳ��� ���

        // �迭
        string[] monsters = { "������", "�Ǹ�", "��", "��ũ" };

        Debug.Log("�ʿ� �����ϴ� ����");
        Debug.Log(monsters[0]);
        Debug.Log(monsters[1]);
        Debug.Log(monsters[2]);

        int[] monsterLevel = new int[4];
        monsterLevel[0] = 1;
        monsterLevel[1] = 23;
        monsterLevel[2] = 42;
        monsterLevel[3] = 25;


        // ����Ʈ: ����� �߰��� ������ �׷��� ����
        List<string> items = new List<string>();
        items.Add("������30");
        items.Add("��������20");

        Debug.Log("������ �ִ� ��������?");
        Debug.Log(items[0]);
        Debug.Log(items[1]);

        //items.RemoveAt(0); 0�� �ε��� ���� �������� -> 1�� �ε��� ���� 0������ �������� 1���� �޸� �Ҵ� ������
        Debug.Log(items[0]);
        //Debug.Log(items[1]); // index ���� �߻�! -> ����������!


        // 3. ������
        int exp = 1500;

        exp = 1500 + 320;
        exp = exp - 10;
        level = exp / 300;
        strength = level * 3.1f;

        Debug.Log("����� �� ����ġ��?");
        Debug.Log(exp);
        Debug.Log("����� ������?");
        Debug.Log(level);
        Debug.Log("����� ����?");
        Debug.Log(strength);

        int nextExp = 300 - (exp % 300);
        Debug.Log("���� �������� ���� ����ġ��?");
        Debug.Log(nextExp);

        string title = "������";
        Debug.Log("����� �̸���?");
        Debug.Log(title + " " + playerName);

        int fullLevel = 99;
        isFullLevel = (level == fullLevel);
        Debug.Log("���� �����Դϱ�?" + isFullLevel);

        // �� ������ <, >, <=, >=
        bool isEndTutorial = level > 10;
        Debug.Log("Ʃ�丮���� ���� ����Դϱ�? " + isEndTutorial);

        // �� ������ &&(and), ||(or)
        int health = 30;
        int mana = 12;
        bool isBadCondition1 = (health <= 50 && mana <= 20);
        bool isBadCondition2 = (health <= 50 || mana <= 20);
        Debug.Log("����� ���°� ���޴ϱ�? " + isBadCondition1);

        // ���� ������ => if��
        string condition = isBadCondition2 ? "����" : "����";
        Debug.Log("����� ���°� ���޴ϱ�? " + condition);


        // 4. Ű����: ���α׷��� �� �����ϴ� Ư���� �ܾ�
        // => int float string bool new List
        // int float = 1;  - Ű����� ���������� ���� �̸��̳� ������ ����� �� ����!
        // string name = List;

        // 5. ���ǹ�: ���ǿ� �����ϸ� ������ �����ϴ� ���
        // if��: ������ true�� ��, ���� ���� / ���� if ������ ������� ������ else ����
        if (condition == "����")
        {
            Debug.Log("�÷��̾� ���°� ���ڴ� �������� ����ϼ���!");
        }
        else
        {
            Debug.Log("�÷��̾� ���°� �����ϴ�!");
        }

        // if���� �� �ٸ� ������ ���� else if�� ���� ���, else�� ������
        if (isBadCondition1 && (items[0] == "������30"))
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("���� ���� 30�� ����Ͽ����ϴ�!");
        }
        else if (isBadCondition1 && (items[1] == "��������20"))
        {
            items.RemoveAt(1);
            mana += 20;
            Debug.Log("���� ���� 20�� ����Ͽ����ϴ�!");
        }

        // switch, case: ������ ���� ���� ���� ����
        switch (monsters[0])
        {
            case "������":
            case "�縷��":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            case "�Ǹ�":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            case "��":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            default:
                Debug.Log("??? ���Ͱ� ����!");
                break;

        }

        // 6. �ݺ���: ���ǿ� �����ϸ� ������ �ݺ��ϴ� ���
        // while: ������ true�� ��, ���� �ݺ� ����
        while (health>0)
        {
            health--;
            if (health > 0)
            {
                Debug.Log("�� �������� �Ծ����ϴ�. " + health);
            }
            else
            {
                Debug.Log("����Ͽ����ϴ�.");
            }

            if(health == 10)
            {
                Debug.Log("�ص����� ����մϴ�.");
                break;
            }
        }

        // for: ������ �����ϸ鼭 ���� �ݺ� ����
        for (int count = 0; count < 10; count++)
        {
            health++;
            Debug.Log("�ش�� ġ�� ��... " + health); 
        }

        for (int i=0; i<monsters.Length;i++)
        {
            Debug.Log("�� ������ �ִ� ���� " + monsters[i]);
        }

        // foreach: for�� �׷��� ���� Ž�� Ưȯ
        foreach (var monster in monsters)
        {
            Debug.Log("�� ������ �ִ� ���� : " + monster);
        }

        Heal(ref health); // ü�� ȸ�� �Լ�

        for (int i = 0; i < monsters.Length; i++)
        {
            Debug.Log("���� " + monsters[i] + "���� " 
                + Battle(ref monsterLevel[i], ref level));
        }

        // 8. Ŭ����: �ϳ��� �繰(������Ʈ)�� �����ϴ� ����
        // �ν��Ͻ�: ���ǵ� Ŭ������ ���� �ʱ�ȭ�� ��üȭ
        Player player = new Player();
        player.id = 0;
        player.name = "������";
        player.title = "���� ��";
        player.strength = 2.4f;
        player.weapon = "���� ������";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name + "�� ������ " + player.level + " �Դϴ�!");

        Debug.Log(player.Move());

    }
    // ��������: �Լ� �ۿ� ����� ����

    // 7. �Լ�(�޼ҵ�): ����� ���ϰ� ����ϵ��� ������ ����
    // void: ��ȯ �����Ͱ� ���� �Լ� Ÿ��
    // ��������: �Լ� �ȿ��� ����� ����
    void Heal(ref int health)
    {
        health += 10;
        Debug.Log("���� �޾ҽ��ϴ�. " +  health);
        //return: �Լ��� ���� ��ȯ�� �� ���
    }

    string Battle(ref int monsterLevel, ref int level)
    {
        string result;
        if (level >= monsterLevel)
            result = "�̰���ϴ�!";
        else
            result = "�����ϴ�!";

        return result;
    }
}