using System;

class Point
{
    private int _xCor;
    private int _yCor;

    public Point()
    {
        _xCor = 0;
        _yCor = 0;
   }

    public void SetCordinates(int p1 , int p2)
    {
        this._xCor = p1;
        this._yCor = p2;
    }

    public void PrintPoint()
    {
        Console.WriteLine("Point.X = {0}, Point.Y = {1}",this._xCor, this._yCor);
    }
}
