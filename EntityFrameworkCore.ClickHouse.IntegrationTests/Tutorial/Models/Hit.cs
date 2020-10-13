using System;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Tutorial.Models
{
    public class Hit
    {
        public ulong WatchID { get; set; } 

        public byte JavaEnable { get; set; }

        public string Title { get; set; }

        public short GoodEvent { get; set; }

        public DateTime EventTime { get; set; }

        public DateTime EventDate { get; set; }

        public uint CounterID { get; set; }

        public uint ClientIP { get; set; }

        public string ClientIP6 { get; set; }

        public uint RegionID { get; set; }

        public ulong UserID { get; set; }

        public sbyte CounterClass { get; set; }

        public byte OS { get; set; }

        public byte UserAgent { get; set; }

        public string URL { get; set; }

        public string Referer { get; set; }

        public string URLDomain { get; set; }

        public string RefererDomain { get; set; }

        public byte Refresh { get; set; }

        public bool IsRobot { get; set; }

        public ushort[] RefererCategories { get; set; }

        public ushort[] URLCategories { get; set; }

        public uint[] URLRegions { get; set; }

        public uint[] RefererRegions { get; set; }

        public ushort ResolutionWidth { get; set; }

        public ushort ResolutionHeight { get; set; }

        public byte FlashMajor { get; set; }

        public byte FlashMinor { get; set; }

        public string FlashMinor2 { get; set; }

        public byte NetMajor { get; set; }

        public byte NetMinor { get; set; }

        public ushort UserAgentMajor { get; set; }

        public string UserAgentMinor { get; set; }

        public byte CookieEnable { get; set; }

        public byte JavascriptEnable { get; set; }

        public bool IsMobile { get; set; }

        public byte MobilePhone { get; set; }

        public string MobilePhoneModel { get; set; }

        public string Params { get; set; }

        public uint IPNetworkID { get; set; }

        public sbyte TraficSourceID { get; set; }

        public ushort SearchEngineID { get; set; }

        public string SearchPhrase { get; set; }

        public byte AdvEngineID { get; set; }

        public bool IsArtifical { get; set; }

        public ushort WindowClientWidth { get; set; }

        public ushort WindowClientHeight { get; set; }

        public short ClientTimeZone { get; set; }

        public DateTime ClientEventTime { get; set; }
    }
}
