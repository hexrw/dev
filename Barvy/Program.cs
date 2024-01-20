using System;

public class RgbBarva
{
    public int Červená { get; set; }
    public int Zelená { get; set; }
    public int Modrá { get; set; }

    public RgbBarva(int červená, int zelená, int modrá)
    {
        Červená = červená;
        Zelená = zelená;
        Modrá = modrá;
    }

    public CmykBarva NaCmyk()
    {
        double r = Červená / 255.0;
        double g = Zelená / 255.0;
        double b = Modrá / 255.0;

        double k = 1 - Math.Max(r, Math.Max(g, b));
        double c = (1 - r - k) / (1 - k);
        double m = (1 - g - k) / (1 - k);
        double y = (1 - b - k) / (1 - k);

        return new CmykBarva(c, m, y, k);
    }
}

public class CmykBarva
{
    public double Cyan { get; set; }
    public double Magenta { get; set; }
    public double Žlutá { get; set; }
    public double Černá { get; set; }

    public CmykBarva(double cyan, double magenta, double žlutá, double černá)
    {
        Cyan = cyan;
        Magenta = magenta;
        Žlutá = žlutá;
        Černá = černá;
    }

    public RgbBarva NaRgb()
    {
        int r = Convert.ToInt32(255 * (1 - Cyan) * (1 - Černá));
        int g = Convert.ToInt32(255 * (1 - Magenta) * (1 - Černá));
        int b = Convert.ToInt32(255 * (1 - Žlutá) * (1 - Černá));

        return new RgbBarva(r, g, b);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Příklad použití:
        RgbBarva rgb = new RgbBarva(255, 0, 0); // Červená
        CmykBarva cmyk = rgb.NaCmyk();
        Console.WriteLine($"RGB ({rgb.Červená}, {rgb.Zelená}, {rgb.Modrá}) na CMYK ({cmyk.Cyan}, {cmyk.Magenta}, {cmyk.Žlutá}, {cmyk.Černá})");

        CmykBarva cmykBarva = new CmykBarva(0, 1, 1, 0); // Cyan
        RgbBarva rgbBarva = cmykBarva.NaRgb();
        Console.WriteLine($"CMYK ({cmykBarva.Cyan}, {cmykBarva.Magenta}, {cmykBarva.Žlutá}, {cmykBarva.Černá}) na RGB ({rgbBarva.Červená}, {rgbBarva.Zelená}, {rgbBarva.Modrá})");
    }
}
