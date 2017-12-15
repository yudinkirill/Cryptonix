using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
/*object bitcoin;
object ethereum;
object ethereumclassic;
object euro;
object dollar;
object bitcoincash;
object ripple;
object litecoin;
object waves;
object dash;
object zcash;*/
namespace CryptoCalculator
{
    [DataContract]
    class FilterJSON
    {
        [DataMember(Name = "BTC_RUB")]
        public BTC_RUB BTC { get; set; }

        [DataMember(Name = "BCH_RUB")]
        public BCH_RUB BCH { get; set; }

        [DataMember(Name = "ETH_RUB")]
        public ETH_RUB ETH { get; set; }

        [DataMember(Name = "ETC_RUB")]
        public ETС_RUB ETС { get; set; }

        [DataMember(Name = "XRP_RUB")]
        public XRP_RUB XRP { get; set; }

        [DataMember(Name = "LTC_RUB")]
        public LTC_RUB LTC { get; set; }

        [DataMember(Name = "WAVES_RUB")]
        public WAVES_RUB WAVES { get; set; }

        [DataMember(Name = "DASH_RUB")]
        public DASH_RUB DASH { get; set; }

        [DataMember(Name = "ZEC_RUB")]
        public ZEC_RUB ZEC { get; set; }


    }

    [DataContract]
    public class BTC_RUB : CurrencyPair
    {
        
    }

    [DataContract]
    public class BCH_RUB : CurrencyPair
    {

    }

    [DataContract]
    public class ETH_RUB : CurrencyPair
    {

    }

    [DataContract]
    public class ETС_RUB : CurrencyPair
    {

    }


    [DataContract]
    public class XRP_RUB : CurrencyPair
    {

    }

    [DataContract]
    public class LTC_RUB : CurrencyPair
    {

    }

    [DataContract]
    public class WAVES_RUB : CurrencyPair
    {

    }

    [DataContract]
    public class DASH_RUB : CurrencyPair
    {

    }

    [DataContract]
    public class ZEC_RUB : CurrencyPair
    {

    }


    [DataContract]
    public class CurrencyPair
    {
        [DataMember]
        public double buy_price { get; set; }
        [DataMember]
        public string sell_price { get; set; }
        [DataMember]
        public string last_trade { get; set; }
        [DataMember]
        public string high { get; set; }
        [DataMember]
        public string low { get; set; }
        [DataMember]
        public string avg { get; set; }
        [DataMember]
        public string vol { get; set; }
        [DataMember]
        public string vol_curr { get; set; }
        [DataMember]
        public string updated { get; set; }
    }
}
