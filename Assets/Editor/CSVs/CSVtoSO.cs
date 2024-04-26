using UnityEngine;
using UnityEditor;
using System.IO;

public class CSVtoSO
{

    private static string characterCSVPath = "/Editor/CSVs/CharacterCSV.csv";
    private static string enemyCSVPath = "/Editor/CSVs/EnemyCSV.csv";
    private static string gunCSVPath = "/Editor/CSVs/GunCSV.csv";

    //Them Menu khoi tao Scriptable Object cho nhan vat
    [MenuItem("Ultinities/Genarate Character")]
    public static void GenarateCharacter()
    {
        string[] characters = File.ReadAllLines(Application.dataPath + characterCSVPath);
        foreach (string s in characters)
        {
            string[] splitData = s.Split(";");

            if(splitData.Length < 4)
                return;

            CharacterSO character = ScriptableObject.CreateInstance<CharacterSO>();
            character.id = int.Parse(splitData[0]);
            character.nameCharacter = splitData[1].ToString();
            character.speed = float.Parse(splitData[2]);
            character.health = int.Parse(splitData[3]);
            AssetDatabase.CreateAsset(character, $"Assets/FreeWater/Datas/Character/{character.id}_{character.nameCharacter}.asset");
        }

    }

    //Them Menu khoi tao Scriptable Object cho quai vat
    [MenuItem("Ultinities/Genarate Enemy")]
    public static void GenarateEnemy()
    {
        string[] enemies = File.ReadAllLines(Application.dataPath + enemyCSVPath);
        foreach (string s in enemies)
        {
            string[] splitData = s.Split(";");
            if (splitData.Length < 5)
                return;

            EnemySO enemy = ScriptableObject.CreateInstance<EnemySO>();
            enemy.nameEnemy = splitData[0];
            enemy.health = int.Parse(splitData[1]);
            enemy.minDamage = int.Parse(splitData[2]);
            enemy.maxDamage = int.Parse(splitData[3]);
            enemy.speed = float.Parse(splitData[4]);
            AssetDatabase.CreateAsset(enemy, $"Assets/FreeWater/Datas/Enemy/{enemy.nameEnemy}.asset");
        }
    }

    //Them Menu khoi tao Scriptable Object cho sung
    [MenuItem("Ultinities/Genarate Gun")]
    public static void GenarateGun()
    {
        string[] guns = File.ReadAllLines(Application.dataPath + gunCSVPath);
        foreach (string s in guns)
        {
            string[] splitData = s.Split(";");

            if (splitData.Length < 5)
                return;

            GunSO gun = ScriptableObject.CreateInstance<GunSO>();
            gun.nameGun = splitData[0];
            gun.minDamage = int.Parse(splitData[1]);
            gun.maxDamage = int.Parse(splitData[2]);
            gun.timeFire = float.Parse(splitData[3]);
            gun.bulletForce = float.Parse(splitData[4]);
            AssetDatabase.CreateAsset(gun, $"Assets/FreeWater/Datas/Gun/{gun.nameGun}.asset");
        }

    }
}
