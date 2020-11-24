using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var foundObject = FindObjectsOfType(typeof(T)) as T[];  //typeof 안의 컴퍼넌트를 찾아줌

                if (foundObject.Length >= 2)
                {
                    foreach (var found in foundObject)
                        Debug.LogError($"gameobject name : {found.name}");

                    throw new System.Exception($"{typeof(T)} is duplicated.");
                }

                if (foundObject.Length > 0)
                {
                    instance = foundObject[0];
                }

                if (instance == null)
                {
                    var newGameObject = new GameObject(typeof(T).ToString());
                    instance = newGameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}