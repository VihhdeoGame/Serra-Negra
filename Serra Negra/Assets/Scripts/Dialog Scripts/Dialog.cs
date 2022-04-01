using System;

[Serializable]
public class Dialog
{
    public int spriteId;
    public int[] musicIds;
    public int[] sfxIds;
    public string name;
    public string sentenses;
}

[Serializable]
public class Dialogs
{
    public Dialog[] dialogs;
}