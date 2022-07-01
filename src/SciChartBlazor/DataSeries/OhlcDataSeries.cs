namespace SciChartBlazor.DataSeries;

public class OhlcDataSeries<TOpen, THigh, TLow, TClose> : DataSeriesBase
{
    public OhlcDataSeries(TOpen[] openValues, THigh[] highValues, TLow[] lowValues, TClose[] closeValues)
    {
        OpenValues = openValues;
        HighValues = highValues;
        LowValues = lowValues;
        CloseValues = closeValues;
    }

    public TOpen[] OpenValues { get; }
    public THigh[] HighValues { get; }
    public TLow[] LowValues { get; }
    public TClose[] CloseValues { get; }
}