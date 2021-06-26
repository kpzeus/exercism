using System.Collections.Generic;
using System;

public class BankAccount
{
    static List<BankAccount> accounts = new List<BankAccount>();

    decimal balance = 0;

    public void Open()
    {
        var account = new BankAccount();
        accounts.Add(this);
    }

    public void Close()
    {
        accounts.Remove(this);
    }

    public decimal Balance
    {
        get
        {
            if (!accounts.Contains(this))
                throw new InvalidOperationException();

            return this.balance;
        }
    }

    public void UpdateBalance(decimal change)
    {
        if (!accounts.Contains(this))
            throw new InvalidOperationException();

        lock (this)
        {
            this.balance += change;
        }
    }
}
