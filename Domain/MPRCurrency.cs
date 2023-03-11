namespace WemaAnalyticsAPI.Domain
{
  public class MPRCurrency
  {
    public string CAPTION { get; set; }
    public string CURRENCY { get; set; }
    public int OctoberAVGVOLN000 { get; set; }
    public int NovemberACTVOLN000 { get; set; }
    public int NovemberAVGVOLN000 { get; set; }
    public int MoMVariance { get; set; }
    public int NovemberBUDGETAVGVOLN000 { get; set; }
    public int BUDGETVARIANCE { get; set; }
    public object YIELD { get; set; }
    public int POOLRATE { get; set; }
    public object SPREAD { get; set; }
    public int INTERESTINCOME { get; set; }
  }
}
