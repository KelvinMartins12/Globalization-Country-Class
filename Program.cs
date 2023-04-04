using System.Globalization;
using System.Reflection;
using System.Runtime;

public class Teste
{
    public static void Main()
    {
        // Instantiate three Belgian RegionInfo objects.
        RegionInfo BR = new RegionInfo("BR");
        RegionInfo ptBR = new RegionInfo("pt-BR");
        RegionInfo enUS = new RegionInfo("pt-NL");
        RegionInfo esAR = new RegionInfo("pt-AR");
        RegionInfo esBOL = new RegionInfo("pt-BO");
        RegionInfo esPER = new RegionInfo("pt-PE");
        RegionInfo esCL = new RegionInfo("pt-CL");

        RegionInfo[] regions = { BR, ptBR, enUS, esAR, esBOL, esPER, esCL };

        Regioes(regions);
        Console.WriteLine(
            "-----------------------------------------------------------------------------------------------------------");

        Pais("BR");
        Pais("US");
        Pais("AR");
        Pais("NL");
        Pais("PE");
        Pais("CL");
        Console.WriteLine(
            "-----------------------------------------------------------------------------------------------------------");
        CulturaAtual();
        Console.WriteLine(
            "-----------------------------------------------------------------------------------------------------------Paises");

        PegarPaises();


    }

    public static void Regioes(RegionInfo[] regioes)
    {
        PropertyInfo[] props = typeof(RegionInfo).GetProperties(BindingFlags.Instance | BindingFlags.Public);

        Console.WriteLine("{0,-30}{1,18}{2,18}{3,18}{4,18}{5,18}{6,18}{7,18}\n",
            "RegionInfo Property", "BR", "pt-BR", "en-US", "es-AR", "es-BOL", "es-PER", "es-CL");
        foreach (var prop in props)
        {
            Console.Write("{0,-30}", prop.Name);
            foreach (var region in regioes)
                Console.Write("{0,18}", prop.GetValue(region, null));

            Console.WriteLine();
        }
    }

    public static void Pais(string codigoISO)
    {
        RegionInfo Pais = new RegionInfo(codigoISO);

        Console.WriteLine("   EnglishName:                  {0}", Pais.EnglishName);
        Console.WriteLine("   NativeName:                  {0}", Pais.NativeName);

    }

    public static void CulturaAtual()
    {
        Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
    }

    public static void PegarTodasCulturas2()
    {
        // Get and enumerate all cultures.
        var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
        foreach (var ci in allCultures)
        {
            // Display the name of each culture.
            Console.WriteLine($"{ci.EnglishName} ({ci.Name}): ");
            // Indicate the culture type.
        }
    }

    public static void PegarTodasCulturas()
    {
        RegionInfo country = new RegionInfo(new CultureInfo("pt-BR", false).Name);

        List<string> countryNames = new List<string>();
        //To get the Country Names from the CultureInfo installed in windows



        foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {

            country = new RegionInfo(new CultureInfo(cul.Name, false).Name);

            countryNames.Add(country.ISOCurrencySymbol.ToString());

        }
        //Assigning all Country names to IEnumerable

        IEnumerable<string> nameAdded = countryNames.OrderBy(names => names).Distinct();

        nameAdded.GetEnumerator();

    }

    public static IEnumerable<string> PegarPaises()
    {
        List<string> countryNames = new List<string>();
        //To get the Country Names from the CultureInfo installed in windows

        CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);


        foreach (CultureInfo getCulture in getCultureInfo)
        {
            if (!getCulture.IsNeutralCulture && getCulture.Name.Length <= 5)
            {
                var aux = getCulture.Name;
                string[] aux2 = aux.Split("-");
                string aux3 = "pt-" + aux2[1];

                RegionInfo getRegionInfo = new RegionInfo(aux3);
                if (!countryNames.Contains(getRegionInfo.DisplayName))
                {

                    countryNames.Add(getRegionInfo.DisplayName);
                }
            }
        }
        countryNames.Sort();

        IEnumerable<string> nameAdded = countryNames.OrderBy(names => names).Distinct();

        //Set  A breakpoint right here to see all countries in the variable!
        return nameAdded;
    }
}
