using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [Header("Objects To Load On Start")]
    [SerializeField] protected uint InitSize;

    [Header("Object To Load")]
    [SerializeField] protected PooledObject pObject;

    Stack<PooledObject> stack = new Stack<PooledObject>();

    private void Start()
    {
        Setup();
    }

    void Setup()
    {
        PooledObject instancia = null;

        for (int i = 0; i < InitSize; i++)
        {
            instancia = Instantiate(pObject);
            instancia.pool = this;
            instancia.gameObject.SetActive(false);
            stack.Push(instancia);
        }
    }

    public PooledObject Get()
    {
        if (stack.Count == 0)
        {
            PooledObject newinstance = Instantiate(pObject);
            newinstance.pool = this;
            return newinstance;
        }

        PooledObject nextinstance = stack.Pop();
        nextinstance.gameObject.SetActive(true);
        return nextinstance;
    }

    public void Return(PooledObject pooled)
    {
        stack.Push(pooled);
        pooled.gameObject.SetActive(false);
    }

}
