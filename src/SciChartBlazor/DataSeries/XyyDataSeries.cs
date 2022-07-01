namespace SciChartBlazor.DataSeries;

public class XyyDataSeries<TX, TY1, TY2> : DataSeriesBase
{
    public XyyDataSeries(TX[] xValues, TY1[] y1Values, TY2[] y2Values)
    {
        XValues = xValues;
        Y1Values = y1Values;
        Y2Values = y2Values;
    }

    public TX[] XValues { get; }
    public TY1[] Y1Values { get; }
    public TY2[] Y2Values { get; }
}