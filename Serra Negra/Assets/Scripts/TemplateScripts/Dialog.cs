using System;

[Serializable]
public class Dialog
{
    public int id;
    public string name;
    public string sentenses;
}

[Serializable]
public class Dialogs
{
    public Dialog[] dialogs;
}