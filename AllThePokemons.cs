public class Rootobject
{
    public int Count { get; set; }
    public string Next { get; set; }
    public object Previous { get; set; }
    public Pokemon[] Results { get; set; }  // This should match the API structure
}

public class Pokemon
{
    public string Name { get; set; }
    public string Url { get; set; }
}
