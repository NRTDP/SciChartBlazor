using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.DataSeries;

public class XyzDataSeries<TX, TY, TZ> : DataSeriesBase
{

    public TX[] XValues { get; }
    public TY[] YValues { get; }
    public TZ[] ZValues { get; }

    public XyzDataSeries(TX[] xValues, TY[] yValues, TZ[] zValues)
    {
        XValues = xValues;
        YValues = yValues;
        ZValues = zValues;
    }
}
