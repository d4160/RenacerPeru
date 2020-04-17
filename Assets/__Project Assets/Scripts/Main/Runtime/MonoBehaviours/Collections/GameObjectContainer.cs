using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectContainer : UnidimensionalContainer<GameObject>
{
    protected override void Setup()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].SetActive(i == _selectedIndex);
        }
    }

    public override void Next()
    {
        Selected?.SetActive(false);

        base.Next();

        Selected?.SetActive(true);
    }

    public override void Prev()
    {
        Selected?.SetActive(false);

        base.Prev();

        Selected?.SetActive(true);
    }

    public override void GoTo(int idx)
    {
        Selected?.SetActive(false);

        base.GoTo(idx);

        Selected?.SetActive(true);
    }
}
