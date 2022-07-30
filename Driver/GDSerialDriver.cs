using Godot;
using System;
using System.IO.Ports;
using System.Collections.Generic;
public class GDSerialDriver : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public String PortName;
    
    [Export]
    public int BaudRate;

    [Export]
    public Parity PortParity;

    [Export]
    public int DataBits;

    [Export]
    public StopBits StopBits;

    [Export]
    public Handshake HandshakeType;

    private SerialPort _serialPort;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _serialPort = new SerialPort();
    }

    public string[] GetOpenPorts()
    {
        return SerialPort.GetPortNames();
    }

    public void ConnectSerial()
    {
        //close if open
        _serialPort.Close();

        _serialPort.PortName = PortName;
        _serialPort.BaudRate = BaudRate;
        _serialPort.Parity = PortParity;
        _serialPort.DataBits = DataBits;
        _serialPort.StopBits = StopBits;

        _serialPort.ReadTimeout = 1000;
        _serialPort.WriteTimeout = 1000;

        _serialPort.Open();

    }

    public String Read()
    {
        try
        {
            return _serialPort.ReadExisting();
        }
        catch
        {
            return "";
        }
    }

    public void Write(String data)
    {
        try
        {
            _serialPort.Write(data);
        }
        catch
        {
        }
    }
    public void ClosePort()
    {
        _serialPort.Close();
    }

    public bool IsOpen()
    {
        return _serialPort.IsOpen;
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
