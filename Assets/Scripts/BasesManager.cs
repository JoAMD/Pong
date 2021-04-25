using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasesManager : MonoBehaviour
{
    #region Events

    public UnityEvent<string> scoreChangeComputer;
    public UnityEvent<string> scoreChangeHuman;

    #endregion

    #region Singleton

    public static BasesManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private Dictionary<Collider2D, PlayerType> basesMap;
    private Dictionary<PlayerType, int> pointsMap;

    // Start is called before the first frame update
    void Start()
    {
        basesMap = new Dictionary<Collider2D, PlayerType>();
        pointsMap = new Dictionary<PlayerType, int>();
        pointsMap.Add(PlayerType.Human, 10);
        pointsMap.Add(PlayerType.Computer, 10);
    }

    public void AddCollider2D(PlayerType playerType, Collider2D collider2D)
    {
        print("playerType = " + playerType);
        print("collider2D = " + collider2D);
        basesMap.Add(collider2D, playerType);
        print(collider2D.GetHashCode());
    }

    public bool IsTriggerBase(Collider2D collider2D)
    {
        //print(collider2D.GetHashCode());
        if (basesMap.ContainsKey(collider2D))
        {
            if (basesMap.TryGetValue(collider2D, out PlayerType playerType)) 
            {
                //Maybe another singleton for points?
                pointsMap[playerType] = pointsMap[playerType] - 1; // make such that other guy gets a positive point?
                if (playerType == PlayerType.Computer)
                {
                    scoreChangeComputer?.Invoke(pointsMap[playerType] + "");
                }
                else if (playerType == PlayerType.Human)
                {
                    scoreChangeHuman?.Invoke(pointsMap[playerType] + "");
                }
                print("innnnnnnnnnnnnn player " + playerType);
            }
            else
            {
                Debug.LogError("Error!");
            }
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
