using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private  int _money = 0;

    public event Action<int> ChangeBalance;

    public void AddMoney(int coin)
    {
        _money += coin;
        Change();
    }

    private void Change()
    {
        ChangeBalance?.Invoke(_money);
    }
}
