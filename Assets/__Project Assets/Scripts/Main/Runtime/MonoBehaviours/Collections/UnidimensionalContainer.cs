using System.Collections;
using System.Collections.Generic;
using d4160.Core;
using UnityEngine;

public abstract class UnidimensionalContainer<T> : MonoBehaviour
{
    [SerializeField] protected T[] _objects;
    // TODO: Missing 'None' value for LoopType, for now Random means None for this app.
    [Tooltip("Missing 'None' value for LoopType, for now Random means None for this app.")]
    [SerializeField] protected LoopType _loopType;
    [SerializeField] protected int _selectedIndex = 0;
    [SerializeField] protected bool _setupAtStart = true;

    public T this[int index]
    {
        get
        {
            if (_objects.IsValidIndex(index))
            {
                return _objects[index];
            }

            return default;
        }
    }

    public int Count => _objects.Length;

    public T Selected => this[_selectedIndex];

    protected virtual void Start()
    {
        if (_setupAtStart)
        {
            Setup();
        }
    }

    protected abstract void Setup();

    public virtual void Next()
    {
        _selectedIndex++;

        CheckForLoop();
    }

    public virtual void Prev()
    {
        _selectedIndex--;

        CheckForLoop();
    }

    public virtual void GoTo(int index)
    {
        _selectedIndex = index;

        CheckForLoop();
    }

    protected virtual void CheckForLoop()
    {
        switch (_loopType)
        {
            case LoopType.Random:
                _selectedIndex = Mathf.Clamp(_selectedIndex, 0, Count - 1);
                break;
            case LoopType.Restart:
                break;
            case LoopType.PingPong:
                break;
        }
    }
}
