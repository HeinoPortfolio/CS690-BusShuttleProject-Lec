namespace BusShuttle;

public class Reporter
{
    public static Stop FindBusiestStop(List<PassengerData> data)
    {
        // Build a dictionary that contains the counts of the stops
        Dictionary<string, int> passengerCountPerStop = new Dictionary<string, int>();

        foreach(var piece in data)
        {
            if(!passengerCountPerStop.ContainsKey(piece.Stop.Name))
            {
                passengerCountPerStop.Add(piece.Stop.Name, 0);
            }
            passengerCountPerStop[piece.Stop.Name] +=  piece.Boarded;
        }

        // Find the busiest or the highest
        string highestStop ="";
        int highest = -1;

        foreach(var stopCountPair in passengerCountPerStop)
        {
            if(stopCountPair.Value > highest)
            {
                highestStop = stopCountPair.Key;
                highest = stopCountPair.Value;
            }
        }
        return new Stop(highestStop);
    }
}