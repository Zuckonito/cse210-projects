namespace Shapes;

public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Método abstracto que obliga a cada forma derivada a implementar su propia lógica de cálculo de área
    public abstract double GetArea();
}