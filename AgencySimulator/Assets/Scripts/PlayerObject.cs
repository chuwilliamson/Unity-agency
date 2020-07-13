using System;
using System.Collections.Generic;

[Serializable]
public class PlayerObject
{
    public Dictionary<string, List<float>> ResultsDictionary;
    public List<float> Inputs;
    public string Name;

    public List<List<float>> values;
}