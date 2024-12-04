using System;

namespace IoTGame.Practice.Client;

public class Future
{
    public Future(string name, string data_time, string flow_num)
    {
        Name = name;
        Date = data_time.Split(' ')[0];
        Time = data_time.Split(' ')[1];
        FlowNum = int.Parse(flow_num);
    }

    public string Name { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public int FlowNum { get; set; }
}
