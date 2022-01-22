using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ServerSide
{
    public class ResidentsLogic
    {
        public ResidentsLogic()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public IEnumerable<ResidentsModel> GetAllResidents()
        {
            List<ResidentsModel> residents = new List<ResidentsModel>();

            XmlNodeList NodeList = LoadXMLData();

            foreach (XmlNode singleNode in NodeList)
            {
                if (singleNode != null)
                {
                    ResidentsModel resident = new ResidentsModel();
                    try { resident.CitySymbol = Int32.Parse(singleNode["סמל_ישוב"].InnerText); }
                    catch { resident.CitySymbol = 0; }
                    try { resident.CityName = singleNode["שם_ישוב"].InnerText; }
                    catch { resident.CityName = ""; }
                    try { resident.RegionSymbol = Int32.Parse(singleNode["סמל_נפה"].InnerText); }
                    catch { resident.RegionSymbol = 0; }
                    try { resident.RegionName = singleNode["נפה"].InnerText; }
                    catch { resident.RegionName = ""; }
                    try { resident.CodeOfManacaMana = Int32.Parse(singleNode["קוד_לשכת_מנא"].InnerText); }
                    catch { resident.CodeOfManacaMana = 0; }
                    try { resident.ChangeMana = singleNode["לשכת_מנא"].InnerText; }
                    catch { resident.ChangeMana = ""; }
                    try { resident.RegionalCode = Int32.Parse(singleNode["קוד_מועצה_אזורית"].InnerText); }
                    catch { resident.RegionalCode = 0; }
                    try { resident.Total = Int32.Parse(singleNode["סהכ"].InnerText); }
                    catch { resident.Total = 0; }
                    try { resident.Age_0_5 = Int32.Parse(singleNode["גיל_0_5"].InnerText); }
                    catch { resident.Age_0_5 = 0; }
                    try { resident.Age_6_18 = Int32.Parse(singleNode["גיל_6_18"].InnerText); }
                    catch { resident.Age_6_18 = 0; }
                    try { resident.Age_19_45 = Int32.Parse(singleNode["גיל_19_45"].InnerText); }
                    catch { resident.Age_19_45 = 0; }
                    try { resident.Age_46_55 = Int32.Parse(singleNode["גיל_46_55"].InnerText); }
                    catch { resident.Age_46_55 = 0; }
                    try { resident.Age_56_64 = Int32.Parse(singleNode["גיל_56_64"].InnerText); }
                    catch { resident.Age_56_64 = 0; }
                    try { resident.Age_65Plus = Int32.Parse(singleNode["גיל_65_פלוס"].InnerText); }
                    catch { resident.Age_65Plus = 0; }
                    residents.Add(resident);
                }
            }

            return residents;
        }

        public IEnumerable<ResidentsModel> GetAllResidentsByName(string cityName)
        {
            List<ResidentsModel> residents = new List<ResidentsModel>();

            XmlNodeList NodeList = LoadXMLData();

            foreach (XmlNode singleNode in NodeList)
            {
                if (singleNode != null && singleNode["שם_ישוב"].InnerText  == (cityName + " "))
                {
                    ResidentsModel resident = new ResidentsModel();
                    try { resident.CitySymbol = Int32.Parse(singleNode["סמל_ישוב"].InnerText); }
                    catch { resident.CitySymbol = 0; }
                    try { resident.CityName = singleNode["שם_ישוב"].InnerText; }
                    catch { resident.CityName = ""; }
                    try { resident.RegionSymbol = Int32.Parse(singleNode["סמל_נפה"].InnerText); }
                    catch { resident.RegionSymbol = 0; }
                    try { resident.RegionName = singleNode["נפה"].InnerText; }
                    catch { resident.RegionName = ""; }
                    try { resident.CodeOfManacaMana = Int32.Parse(singleNode["קוד_לשכת_מנא"].InnerText); }
                    catch { resident.CodeOfManacaMana = 0; }
                    try { resident.ChangeMana = singleNode["לשכת_מנא"].InnerText; }
                    catch { resident.ChangeMana = ""; }
                    try { resident.RegionalCode = Int32.Parse(singleNode["קוד_מועצה_אזורית"].InnerText); }
                    catch { resident.RegionalCode = 0; }
                    try { resident.Total = Int32.Parse(singleNode["סהכ"].InnerText); }
                    catch { resident.Total = 0; }
                    try { resident.Age_0_5 = Int32.Parse(singleNode["גיל_0_5"].InnerText); }
                    catch { resident.Age_0_5 = 0; }
                    try { resident.Age_6_18 = Int32.Parse(singleNode["גיל_6_18"].InnerText); }
                    catch { resident.Age_6_18 = 0; }
                    try { resident.Age_19_45 = Int32.Parse(singleNode["גיל_19_45"].InnerText); }
                    catch { resident.Age_19_45 = 0; }
                    try { resident.Age_46_55 = Int32.Parse(singleNode["גיל_46_55"].InnerText); }
                    catch { resident.Age_46_55 = 0; }
                    try { resident.Age_56_64 = Int32.Parse(singleNode["גיל_56_64"].InnerText); }
                    catch { resident.Age_56_64 = 0; }
                    try { resident.Age_65Plus = Int32.Parse(singleNode["גיל_65_פלוס"].InnerText); }
                    catch { resident.Age_65Plus = 0; }
                    residents.Add(resident);

                }

            }
            return residents;

        }

        private XmlNodeList LoadXMLData()
        {
            // Load XML Document
            XmlDocument MyDoc = new XmlDocument();
            MyDoc.Load(@"Files\file.xml");

            // Select All Nodes
            XmlNodeList NodeList = MyDoc.GetElementsByTagName("ROW");

            return NodeList;
        }
    }
}
