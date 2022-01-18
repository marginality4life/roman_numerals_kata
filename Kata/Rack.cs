namespace roman_numerals_kata;

public class Rack
{
    public int[] Balls { get; private set; }

    public Rack()
    {
        Balls = Array.Empty<int>();
    }
    
    public void Add(int input)
    {
        var tempBalls = Balls.ToList();
        
        tempBalls.Add(input);
        Balls = tempBalls.OrderBy(x => x).ToArray();
    }

}