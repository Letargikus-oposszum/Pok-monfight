
public class Rootobject
{
    public int Count { get; set; }
    public string Next { get; set; }
    public object Previous { get; set; }
    public Pokemon[] Pokemon { get; set; }
}

public class Pokemon
{
    public string Name { get; set; }
    public string Url { get; set; }
}


