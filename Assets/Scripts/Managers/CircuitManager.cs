using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// логика проверки собранной цепи
public class CircuitManager : MonoBehaviour
{
    // массив возможных связей
    [SerializeField] List<string> relations;
    // массив заменяющих друг друга связи
    [SerializeField] List<EqualRelations> EqualRelations; // в формате массив массивов "одинаковых" элементов [[1-5,1-7,7-5],[аналогично]]
    [SerializeField] GameObject CalcManager;
    [SerializeField] GameObject ProgressManager;
    
    public bool LogicFlag = false;
    // словарь связей, [связь]: true, [связь]: false и тд
    public Dictionary<string, bool> relationsDictionary;
    public List<GameObject> connectors;
    public List<ModuleSlot> slots;
    public List<ModulesWireManager> used;

    void Start()
    {
        CreateRelationsDictionary();
    }

    // проверка наличия текущей связи
    public bool CheckRelation(int startID, int endID)
    {
        var relation = $"{startID}-{endID}";
        var reversedRelation = $"{endID}-{startID}";
        
        CheckEqualRelations();

        foreach(var e in relationsDictionary)
        {
            if(e.Key == relation || e.Key == reversedRelation)
            {
                if(relationsDictionary[e.Key])
                    return false;
                relationsDictionary[e.Key] = true;
                return true;
            }
        }

        return false;
    }

    // проверка заменяемых связей
    public void CheckEqualRelations()
    {
        var countFlag = 0;

        foreach(var e in EqualRelations)
        {
            foreach(var x in e.relations)
            {
                if(relationsDictionary[x])
                {
                    countFlag++;
                }
                if(countFlag == e.relations.Count - 1)
                {
                    foreach(var n in e.relations)
                    {
                        relationsDictionary[n] = true;
                    }
                }
            }
            countFlag = 0;
        }
    }

    public void DestroyWires()
    {
        foreach(var e in used)
        {
            e.DoSlotsUnUsed();
        }

        foreach(var e in slots)
        {
            e.Pressed = false;
        }

        foreach(var e in connectors)
        {
            Destroy(e);
        }

        CreateRelationsDictionary();

        connectors.Clear();
        slots.Clear();

        CalcManager.GetComponent<PhysCalculationsManager>().ResetCalculations();
        ProgressManager.GetComponent<ProgressManager>().ResetProgress();
    }

    void CreateRelationsDictionary()
    {
        relationsDictionary = new Dictionary<string, bool>();

        foreach(var e in relations)
        {
            relationsDictionary.Add(e, false);
        }
    }
}

[System.Serializable]
public class EqualRelations
{
     public List<string> relations;
}