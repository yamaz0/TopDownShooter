using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "SO/EnemyScriptableObject")]
public class EnemiesScriptableObject: SingletonScriptableObject<EnemiesScriptableObject>
{
    [SerializeField]
    private Enemy enemyTemplate;

    public Enemy EnemyTemplate { get => enemyTemplate; set => enemyTemplate = value; }

    public EnemyInfo GetEnemyInfoById(int id)
    {
        return (EnemyInfo)Objects.GetElementById(id);
    }

    public EnemyInfo GetEnemyInfoByName(string name)
    {
        return (EnemyInfo)Objects.GetElementByName(name);
    }

    public List<EnemyInfo> GetEnemiesList()
    {
        List<EnemyInfo> Enemies = new List<EnemyInfo>(Objects.Count);

        foreach (EnemyInfo Enemy in Objects)
        {
            Enemies.Add(Enemy);
        }

        return Enemies;
    }
}
