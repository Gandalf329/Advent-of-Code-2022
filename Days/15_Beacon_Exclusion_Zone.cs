using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Days;
internal class _15_Beacon_Exclusion_Zone
{
    string path = "D:\\progVis\\Advent-of-Code-2022\\input\\15day_input.txt";
    List<string> data = new List<string>();

    public void GetData()
    {
        using (StreamReader fs = new StreamReader(path))
        {
            while (true)
            {
                string temp = fs.ReadLine();
                if (temp == null)
                {
                    break;
                }
                data.Add(temp);
            }
        }
    }
    public record Sensor(long X, long Y, long BeaconDistance);
    public static (HashSet<(long X, long Y)> Map, List<Sensor> Sensors) GetSensor(List<string> input)
    {
        var map = new HashSet<(long X, long Y)>();
        var sensors = new List<Sensor>();
        foreach (var line in input)
        {
            var split = line.Replace(",", "").Replace(":", "").Split(' ');
            var beacon = (long.Parse(split[8].Split('=')[1]), long.Parse(split[9].Split('=')[1]));
            var (sensorX, sensorY) = (long.Parse(split[2].Split('=')[1]), long.Parse(split[3].Split('=')[1]));
            var sensor = new Sensor(sensorX, sensorY, Math.Abs(sensorX - beacon.Item1) + Math.Abs(sensorY - beacon.Item2));
            map.Add(beacon);
            map.Add((sensor.X, sensor.Y));
            sensors.Add(sensor);
        }
        return (map, sensors);
    }
    public long Result1()
    {
        var rowToCheck = 2000000;
        var (map, sensors) = GetSensor(data);

        var rangeMin = sensors.Select(s => s.X - (s.BeaconDistance - Math.Abs(s.Y - rowToCheck))).Min();
        var rangeMax = sensors.Select(s => s.X + (s.BeaconDistance - Math.Abs(s.Y - rowToCheck))).Max();

        long total = 0;
        for (var i = rangeMin; i <= rangeMax; ++i)
        {
            var maxX = sensors
                .Where(s => Math.Abs(s.X - i) + Math.Abs(s.Y - rowToCheck) <= s.BeaconDistance)
                .Select(s => s.BeaconDistance + s.X - Math.Abs(s.Y - rowToCheck))
                .OrderByDescending(s => s)
                .FirstOrDefault(rangeMin - 1);

            if (maxX > rangeMin - 1)
            {
                total += maxX - i + 1 - map.Count(m => m.Y == rowToCheck && m.X >= i && m.X <= maxX);
                i = maxX;
            }
        }

        return total;
    }
    public string Result2()
    {
        var maxCoordinate = 4000000;
        var (_, sensors) = GetSensor(data);

        foreach (var sensor in sensors)
        {
            for (var i = Math.Max(0, sensor.X - sensor.BeaconDistance - 1); i <= Math.Min(maxCoordinate, sensor.X + sensor.BeaconDistance + 1); ++i)
            {
                var positiveY = Math.Min(sensor.Y + sensor.BeaconDistance + 1 - Math.Abs(sensor.X - i), maxCoordinate);
                var negativeY = Math.Max(sensor.Y - (sensor.BeaconDistance + 1 - Math.Abs(sensor.X - i)), 0);
                if (sensors.All(s => Math.Abs(s.X - i) + Math.Abs(s.Y - positiveY) > s.BeaconDistance))
                {
                    return (i * 4000000 + positiveY).ToString();
                }
                if (sensors.All(s => Math.Abs(s.X - i) + Math.Abs(s.Y - negativeY) > s.BeaconDistance))
                {
                    return (i * 4000000 + negativeY).ToString();
                }
            }
        }
        return "Not found";
    }
}
