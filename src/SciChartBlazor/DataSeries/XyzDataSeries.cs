namespace SciChartBlazor.DataSeries;

public class XyzDataSeries<TX, TY, TZ> : DataSeriesBase
{
    public XyzDataSeries(TX[] xValues, TY[] yValues, TZ[] zValues)
    {
        XValues = xValues;
        YValues = yValues;
        ZValues = zValues;
    }

    public TX[] XValues { get; }
    public TY[] YValues { get; }
    public TZ[] ZValues { get; }
}