
namespace SciChartBlazor.Axes;

/// <summary>
/// Numeric Axis which by default uses a LabelProvider of type SmartDateLabelProvider
/// </summary>
/// <seealso cref="SciChartBlazor.Axes.AxisBase" />
public class DateTimeNumericAxis : NumericAxis
{
	/// <summary>
	/// The type of the element. Usually the name of the element in JS.
	/// </summary>
	/// <value>The type.</value>
	public override string Type => nameof(DateTimeNumericAxis);
}