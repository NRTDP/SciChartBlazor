namespace SciChartBlazor.DataSeries;

public class UniformHeatmapDataSeries<TX, TY, TZ> : DataSeriesBase
{
    public UniformHeatmapDataSeries(TX xStart, TX xStep, TY yStart, TY yStep, TZ[][]? zValues = null)
    {
        XStart = xStart;
        XStep = xStep;
        YStart = yStart;
        YStep = yStep;
        ZValues = zValues;
    }

    public TX XStart { get; }
    public TX XStep { get; }
    public TY YStart { get; }
    public TY YStep { get; }
    public TZ[][]? ZValues { get; }
}