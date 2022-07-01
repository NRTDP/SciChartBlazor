namespace SciChartBlazor.DataSeries;

[Serializable]
[SciChartDataSeries(DataSeriesType.XyData)]
public class XyDataSeries<TX, TY> : DataSeriesBase
{
    public XyDataSeries()
    {
        XValues = new List<TX>();
        YValues = new List<TY>();
    }

    public XyDataSeries(ICollection<TX> xValues, ICollection<TY> yValues)
    {
        XValues = xValues;
        YValues = yValues;
    }

    public ICollection<TX> XValues { get; }
    public ICollection<TY> YValues { get; }

    public void Append(TX xValue, TY yValue)
    {
        XValues.Add(xValue);
        YValues.Add(yValue);
    }
}