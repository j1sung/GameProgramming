using UnityEngine;

// class
// ����������: 
public class Actor // Test3�� ������� �θ� Ŭ����
{
    // private ���� ������: �ܺ� Ŭ������ ������� �����ϴ� ������
    // public ���� ������: �ܺ� Ŭ������ ������ �����ϴ� ������
    public int id;
    public string name;
    public string title;
    public string weapon;
    public float strength;
    public int level;

    public string Talk()
    {
        return "��ȭ�� �ɾ����ϴ�.";
    }

    public string HasWeapon()
    {
        return weapon;
    }

    public void LevelUp()
    {
        level += 1;
    }
}
