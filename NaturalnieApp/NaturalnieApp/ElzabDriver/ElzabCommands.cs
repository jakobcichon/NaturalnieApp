using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ElzabDriver;
using NaturalnieApp.Database;
using NaturalnieApp.ElzabDriver;
using static NaturalnieApp.Program;

namespace ElzabCommands
{
    public enum ElzabRaportType
    {
        RegularBillOfSale = 1,
        BillOfSaleWithDiscountFromDiscountCard = 3,
        CashInOutRegisterMachine = 5,
        EndOfDayWorkForCashier_PriceInfo = 6,
        EndOfDayWorkForCashier_StatisticInfo1 = 7,
        EndOfDayWorkForCashier_StatisticInfo2 = 8,
        GiftForBonusCard = 9,
        CorrectionOrReturn = 10,
        RegularSaleOrReturnForCancelBillOfSale = 11,
        CorrectionSaleOrReturnForCancelBillOfSale = 12,
        CashierLogIn = 13,
        CashierLogOut = 14,
        MessageReviewedByCashier = 15,
        MessageSendByCashier = 16,
        EndOfDayWorkForCashier_StatisticInfo3 = 17,
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OPSPROZ4 : InitStructure, IElzabSaleBufforInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "OPSPROZ4"; } }

        private List<string> ElementAttributesPatternOutFile
        {
            get
            {
                List<string> elementAttributesPatternOutFile = new List<string>
                {
                    "$1 nr_rap nr_par nr_poz_par zwrot nr_tow il_sp wart_rabw data czas ST nr_kas wart_rabp wart_pr sprzed bkod rodz_rn",
                    "$3 nr_rap nr_par pr_rab nap_kart",
                    "$5 nr_kas nr_zmiany nr_plat nr_wal wpl wartosc_w_walucie data czas",
                    "$6 nr_kas nr_zmiany nr_plat nr_wal 1 wartosc_w_walucie data czas data czas",
                    "$7 nr_kas nr_zmiany data czas li_par sp li_kor kw_kor il_an_par kw_an_par li_szu",
                    "$8 nr_kas nr_zmiany data czas rab_poz rab_cal narz_poz narz_par zwr_op sp_op",
                    "$9 data czas nr_kas nr_kar nr_prez il_prez wart_prez il_poz_pun",
                    "$10 nr_rap nr_par nr_poz_kor zwrot nr_tow il_sp wart_rabw data czas ST nr_kas wart_rabp wart_pr sprzed bkod rodz_rn",
                    "$11 nr_rap nr_par_anul nr_poz_par zwrot nr_tow il_sp wart_rabw data czas ST nr_kas wart_rabp wart_pr sprzed bkod rodz_rn",
                    "$12 nr_rap nr_par_anul nr_poz_kor zwrot nr_tow il_sp wart_rabw data czas ST nr_kas wart_rabp wart_pr sprzed bkod rodz_rn",
                    "$13 nr_kas1 nr_zm data czas nr_kas2 bity_log czy_wyjdz ha_kas",
                    "$14 nr_kas data czas sp_wylog",
                    "$15 nr_kas data czas identw",
                    "$16 nr_kas data czas nr_frag_wiad frag_wiad",
                    "$17 nr_kas nr_zmiany data czas kw_anul_rab kw_anul_narz li_sp_czyt li_sp_klaw cashback"

                };
                return elementAttributesPatternOutFile;
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "";
            }
        }
        private List<string> ElementAttributesPatternReportFile
        {
            get
            {
                List<string> elementAttributesPatternReportFile = new List<string>
                {
                    "licz_sekw",
                    "licz_dan_wej",
                    "licz_dan_wyj",
                    "licz_lin_wej",
                    "licz_lin_wyj",
                    "nr_ost_tow nr_konf_tow",
                    "nr_lin_plik nr_dan_plik lin_plik",
                    "pusty"

                };
                return elementAttributesPatternReportFile;
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Dictionary were <Key = ElementType, Values = Attributes index starting from 1>
        private Dictionary<int, List<int>> ElementAttributesUniqueIdentifierIndexes
        {
            get
            {
                Dictionary<int, List<int>> elementAttributesUniqueIdentifierIndexes = new Dictionary<int, List<int>>
                {
                    { 1, new List<int> {1,2,3,4,9} },
                    { 3, new List<int> {1,2,3} },
                    { 5, new List<int> {1,2,3,4,5} },
                    { 6, new List<int> {1,2,3,4,5} },
                    { 7, new List<int> {1,2,3,4,5} },
                    { 8, new List<int> {1,2,3,4,5} },
                    { 9, new List<int> {1,2,3,4,5,6} },
                    { 10, new List<int> {1,2,3,4,6} },
                    { 11, new List<int> {1,2,3,4,6} },
                    { 12, new List<int> {1,2,3,4,6} },
                    { 13, new List<int> {1,2,3,4,5,6} },
                    { 14, new List<int> {1,2,3,4} },
                    { 15, new List<int> {1,2,3,4} },
                    { 16, new List<int> {1,2,3,4,5} },
                    { 17, new List<int> {1,2,3,4,5} }
                };
                return elementAttributesUniqueIdentifierIndexes;
            }
        }

        //Dictionary were <Key = ElementType, Values = Type name>
        private Dictionary<int, string> ElementTypeName
        {
            get
            {
                Dictionary<int, string> elementTypeName = new Dictionary<int, string>
                {
                    { 1, "1. Normalna sprzedaż lub zwrotu"},
                    { 3, "3. Dla rabatu na paragonie"},
                    { 5, "4. Wpłata do kasy"},
                    { 6, "6. Koniec zmiany kasjera - informacje kwotowe"},
                    { 7, "7. Koniec zmiany kasjera - informacje statystyczne"},
                    { 8, "8. Koniec zmiany kasjera - informacje statystyczne 2"},
                    { 9, "9. Wydanie prezentu dla karty Bonus"},
                    { 10, "10. Korekcja sprzedaży lub zwrot"},
                    { 11, "11. Anulowane paragony - normalna sprzedaż"},
                    { 12, "12. Anulowane paragony - korekcja"},
                    { 13, "13. Logowanie kasjera"},
                    { 14, "14. Wylogowanie kasjera"},
                    { 15, "15. Potwierdzenie przeczytania wiadomości kasjera"},
                    { 16, "16. Wiadomość wysłana przez kasjera"},
                    { 17, "17. Koniec zmiany kasjera - informacje statystyczne 3"}
                };
                return elementTypeName;
            }
        }

        //Translation dictionary
        private Dictionary<string, string>  AttributesToColumnNames
        {
            get
            {
                Dictionary<string, string> attributesToColumnNames = new Dictionary<string, string>
                {
                    { "nr_rap" , "Numer raportu"},
                    { "nr_par" , "Numer paragonu"},
                    { "nr_poz_par" , "Numer pozycji paragonu"},
                    { "zwrot" , "Zwrot"},
                    { "nr_tow" , "Numer towaru"},
                    { "il_sp" , "Ilość sprzedaży"},
                    { "wart_rabw" , "Wartość po wszystkich rabatach"},
                    { "data" , "Data sprzedaży"},
                    { "czas" , "Czas sprzedaży"},
                    { "ST" , "Stawka VAT"},
                    { "nr_kas" , "Numer kasjera"},
                    { "wart_rabp", "Wartość rabatu" },
                    { "wart_pr", "Wartość przed rabatem" },
                    { "sprzed", "Numer sprzedawcy" },
                    { "bkod", "Kod kreskowy" },
                    { "rodz_rn", "Rodzaj rabatów narzutów" },
                    { "pr_rab", "Rabat w procentach" },
                    { "nap_kart", "Napis z karty rabatowej" },
                    { "nr_zmiany", "Numer zmiany kasjera" },
                    { "nr_plat", "Numer płatności" },
                    { "nr_wal", "Numer waluty" },
                    { "wpl", "Wpłaty wypłaty wpłaty" },
                    { "wartosc_w_walucie", "Wartość w danej płatności i danej walucie" },
                    { "1", "Rezerwa" },
                    { "li_par", "Ilość paragonów sprzedaży (z wyłączeniem paragonów anulowanych)" },
                    { "sp", "Kwota sprzedaży (sprzedaży i skupu opakowań)" },
                    { "li_kor", "Ilość pozycji anulowanych" },
                    { "kw_kor", "Wartość anulowanych pozycji paragonowych" },
                    { "il_an_par", "Ilość anulowanych w całości paragonów" },
                    { "kw_an_par", "Wartość anulowanych paragonów" },
                    { "li_szu", "Ilość otwarć szuflady poza paragonem" },
                    { "rab_poz", "Wartość rabatów (udzielonych na pozycje sprzedaży)" },
                    { "rab_cal", "Wartość rabatu udzielonego na całe paragony" },
                    { "narz_poz", "Wartość narzutu (udzielonego na pozycje sprzedaży)" },
                    { "narz_par", "Wartość narzutu (udzielonego na całe paragony)" },
                    { "zwr_op", "Wartość skupionych (przyjętych) opakowań zwrotnych" },
                    { "sp_op", "Wartość sprzedanych opakowań zwrotnych" },
                    { "nr_kar", "Numer karty" },
                    { "nr_prez", "Numer prezentu" },
                    { "il_prez", "Ilość prezentów" },
                    { "wart_prez", "Wartość prezentów" },
                    { "il_poz_pun", "Ilość pozostałych punktów" },
                    { "nr_poz_kor", "Numer pozycji korekcyjnej" },
                    { "nr_par_anul", "Numer paragonu anulowanego" },
                    { "nr_kas1", "Numer kasjera przed operacją" },
                    { "nr_zm", "Numer zmiany kasjera po operacji" },
                    { "nr_kas2", "Numer kasjera po operacji" },
                    { "bity_log", "Bity opisujące logowanie" },
                    { "czy_wyjdz", "Czy wprowadzanie hasła przerwano klawiszem WYJDŹ" },
                    { "ha_kas", "Hasło kasjera" },
                    { "sp_wylog", "Sposób wylogowania kasjera" },
                    { "identw", "Identyfikator wiadomości" },
                    { "nr_frag_wiad", "Numer fragmentu wiadomości wysłanej przez kasjera" },
                    { "frag_wiad", "Fragment wiadomości wysłanej przez kasjera" },
                    { "kw_anul_rab", "Kwota anulowanych rabatów" },
                    { "kw_anul_narz", "Kwota anulowanych narzutów" },
                    { "li_sp_czyt", "Liczba operacji sprzedaży towarów z czytnika kodów kreskowych" },
                    { "li_sp_klaw", "Liczba operacji sprzedaży towarów z klawiatury" },
                    { "cashback", "Kwota gotówki wypłaconej za pomocą terminala kart płatniczych (cashback)" },
                    { "nr_typ", "Numer typu elementu" },

                };
                return attributesToColumnNames;

            }
        }


        //Class constructor
        public ElzabCommand_OPSPROZ4(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzabBuffor(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile
                , ElementAttributesUniqueIdentifierIndexes);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommandForSaleBuffor(this);
            return status;
        }


        public string GetTranslationForGivenAttributeName(string attributeName)
        {
            //Local variables
            string retVal = "";

            //Try get translation
            this.AttributesToColumnNames.TryGetValue(attributeName, out retVal);

            return retVal;
        }

        public string GetTheNameOfGivenElementType(int type)
        {
            //Local variables
            string retVal = "";

            //Try get translation
            this.ElementTypeName.TryGetValue(type, out retVal);

            return retVal;
        }


    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_ODBARKOD : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "ODBARKOD"; } }
        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "nr_tow bkodd";
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Class constructor
        public ElzabCommand_ODBARKOD(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }



    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_ZDBARKOD : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "ZDBARKOD"; } }
        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "nr_tow bkodd";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Class constructor
        public ElzabCommand_ZDBARKOD(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }



    }
    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OPSPRZED : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "OPSPRZED"; } }
        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "nr_rap nr_par nr_poz_par zwrot nr_tow il_sp wart_rabw";
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }


        //Class constructor
        public ElzabCommand_OPSPRZED(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_KGRUPA : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "KGRUPA"; } }
        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "$nr_gr";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Class constructor
        public ElzabCommand_KGRUPA(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_ZGRUPA : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "ZGRUPA"; } }
        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "$nr_gr naz_gr";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Class constructor
        public ElzabCommand_ZGRUPA(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OGRUPA : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "OGRUPA"; } }
        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "nr_gr naz_gr";
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Class constructor
        public ElzabCommand_OGRUPA(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OBAJTY : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "OBAJTY"; } }
        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "$nr_bit bit";
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Class constructor
        public ElzabCommand_OBAJTY(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_ZTOWAR : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "ZTOWAR"; } }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "$nr_tow naz_tow ST GR MP JM BL bkod cena OP";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Class constructor
        public ElzabCommand_ZTOWAR(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);
        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }
    }


    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OTOWAR : InitStructure, IElzabCommandInterface
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "OTOWAR"; } }
        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "nr_tow naz_tow ST GR MP JM BL bkod cena OP wyl_zrn wpr_ceny lista_podr nr_wag licz_starz";
            }
        }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "< nr_tow >";
            }
        }
        private string ElementAttributesPatternReportFile
        {
            get
            {
                return "";
            }
        }
        private string ElementAttributesPatternConfigFile
        {
            get
            {
                return " device_number, connection_data, time_out";
            }
        }

        //Class constructor
        public ElzabCommand_OTOWAR(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);

            //Call method used to initialize base structure for Report data
            this.Report = InitBaseStructuresReport(path, cashRegisterID, CommandName, ElementAttributesPatternReportFile);

            //Call method used to initialize base structure for Config data
            this.Config = InitBaseStructuresConfig(path, cashRegisterID, CommandName, ElementAttributesPatternConfigFile);

        }

        //Execute command
        public CommandExecutionStatus ExecuteCommand()
        {
            CommandExecutionStatus status = base.ExecuteCommand(this);
            return status;
        }
    }

    public class InitStructure
    {
        protected ElzabFileObject InitBaseStructuresConfig(string path, int cashRegisterID, string commandName,
        string elementAttributesPatternOutFile)
        {
            //Local variables
            List<string> localList = new List<string>();
            localList.Add(elementAttributesPatternOutFile);

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataReport = new ElzabFileObject(path, commandName, FileType.ConfigFile, cashRegisterID,
                elementAttributesPattern: localList);

            return _dataReport;
        }
        protected ElzabFileObject InitBaseStructuresReport(string path, int cashRegisterID, string commandName,
        string elementAttributesPatternOutFile)
        {
            //Local variables
            List<string> localList = new List<string>();
            localList.Add(elementAttributesPatternOutFile);

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataReport = new ElzabFileObject(path, commandName, FileType.ReportFile, cashRegisterID,
                elementAttributesPattern: localList);

            return _dataReport;
        }

        protected ElzabFileObject InitBaseStructuresReport(string path, int cashRegisterID, string commandName,
        List<string> elementAttributesPatternOutFile)
        {

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataReport = new ElzabFileObject(path, commandName, FileType.ReportFile, cashRegisterID,
                elementAttributesPattern: elementAttributesPatternOutFile);

            return _dataReport;
        }

        protected ElzabFileObject InitBaseStructuresDataFromElzab(string path, int cashRegisterID, string commandName,
        string elementAttributesPatternOutFile)
        {
            //Local variables
            List<string> localList = new List<string>();
            localList.Add(elementAttributesPatternOutFile);

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataFromElzab = new ElzabFileObject(path, commandName, FileType.OutputFile, cashRegisterID,
                elementAttributesPattern: localList);

            return _dataFromElzab;
        }

        protected ElzabFileObject InitBaseStructuresDataFromElzabBuffor(string path, int cashRegisterID, string commandName,
        List<string> elementAttributesPatternOutFile, Dictionary<int, List<int>> uniqueElementIdentifierForAttributesPattern = null)
        {

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataFromElzab = new ElzabFileObject(path, commandName, FileType.OutputFile, cashRegisterID,
                elementAttributesPattern: elementAttributesPatternOutFile, 
                uniqueElementIdentifierForAttributesPattern: uniqueElementIdentifierForAttributesPattern, elementUniqueIdMark: '$');

            return _dataFromElzab;
        }

        protected ElzabFileObject InitBaseStructuresDataToElzab(string path, int cashRegisterID, string commandName,
            string elementAttributesPatternInFile)
        {

            //Local variables
            List<string> localList = new List<string>();
            localList.Add(elementAttributesPatternInFile);

            //Initialize object containing information to ELZAB
            ElzabFileObject _dataToElzab = new ElzabFileObject(path, commandName, FileType.InputFile, cashRegisterID,
                headerPatternLine1: "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                localList);

            return _dataToElzab;
        }

        protected CommandExecutionStatus ExecuteCommand(IElzabCommandInterface commandInstance)
        {
            //Local variables
            CommandExecutionStatus reportStatus = new CommandExecutionStatus();

            //Override config file elements
            commandInstance.Config.AddElement();
            string connData = commandInstance.Config.GenerateConnectionData(GlobalVariables.ElzabPortCom, GlobalVariables.ElzabBaudRate);
            commandInstance.Config.ChangeAllElementValues("1", "1", connData, "3");
            commandInstance.Config.GenerateRawDataFromObject();
            commandInstance.Config.WriteDataToFile();

            bool result = true;

            //If data from elzab are used, execute method
            if (commandInstance.DataFromElzab != null)
            {
                //Check if out file exits. If yes, copy it to backup and remove orginal one.
                result = commandInstance.DataFromElzab.BackupFileAndRemove();
            }

            //Check if report file exist.If yes, copy it to backup and remove orginal one.
            if (result) result = commandInstance.Report.BackupFileAndRemove();

            //Generate raw data from object. This data will be used to write to file
            if (result) result = commandInstance.DataToElzab.GenerateRawDataFromObject();

            //Write raw data to the file
            if (result) result = commandInstance.DataToElzab.WriteDataToFile();

            //Execute command
            if (result) result = commandInstance.DataToElzab.RunCommand();

            if (result)
            {

                //Read report data
                commandInstance.Report.GenerateObjectFromRawData();
                reportStatus = commandInstance.Report.ParseReportFileToObject();

                //Report status to DB
                ElzabCommunication elzabCommunicationEnt = new ElzabCommunication();
                elzabCommunicationEnt.DateOfCommunication = DateTime.Now;

                if (reportStatus.ErrorNumber == 0) elzabCommunicationEnt.StatusOfCommunication = ElzabCommunication.CommunicationStatus.FinishSuccess;
                else elzabCommunicationEnt.StatusOfCommunication = ElzabCommunication.CommunicationStatus.FinishFailed;

                elzabCommunicationEnt.ElzabCommandReportStatusCode = reportStatus.ErrorNumber;
                elzabCommunicationEnt.ElzabCommandReportStatusText = reportStatus.ErrorText;

                elzabCommunicationEnt.ElzabCommandName = commandInstance.DataToElzab.CommandName;
                commandInstance.DataToElzab.DatabaseCommands.AddToElzabCommunication(elzabCommunicationEnt);

                //Read data from object
                if (reportStatus.ErrorNumber == 0)
                {
                    //Read data from files
                    if (commandInstance.DataFromElzab != null)
                    {
                        commandInstance.DataFromElzab.GenerateObjectFromRawData();
                    }
                }
            }

            return reportStatus;
        }

        protected CommandExecutionStatus ExecuteCommandForSaleBuffor(IElzabSaleBufforInterface commandInstance)
        {
            //Local variables
            CommandExecutionStatus reportStatus = new CommandExecutionStatus();

            //Override config file elements
            commandInstance.Config.AddElement();
            string connData = commandInstance.Config.GenerateConnectionData(GlobalVariables.ElzabPortCom, GlobalVariables.ElzabBaudRate);
            commandInstance.Config.ChangeAllElementValues("1", "1", connData, "3");
            commandInstance.Config.GenerateRawDataFromObject();
            commandInstance.Config.WriteDataToFile();

            bool result = true;

            //If data from elzab are used, execute method
            if (commandInstance.DataFromElzab != null)
            {
                //Check if out file exits. If yes, copy it to backup and remove orginal one.
                result = commandInstance.DataFromElzab.BackupFileAndRemove();
            }

            //Check if report file exist.If yes, copy it to backup and remove orginal one.
            if (result) result = commandInstance.Report.BackupFileAndRemove();

            //Generate raw data from object. This data will be used to write to file
            if (result) result = commandInstance.DataToElzab.GenerateRawDataFromObject();

            //Write raw data to the file
            if (result) result = commandInstance.DataToElzab.WriteDataToFile();

            //Execute command
            if (result) result = commandInstance.DataToElzab.RunCommand();

            if (result)
            {

                //Read report data
                commandInstance.Report.GenerateObjectFromRawData();
                reportStatus = commandInstance.Report.ParseReportFileToObject();

                //Report status to DB
                ElzabCommunication elzabCommunicationEnt = new ElzabCommunication();
                elzabCommunicationEnt.DateOfCommunication = DateTime.Now;

                if(reportStatus.ErrorNumber == 0) elzabCommunicationEnt.StatusOfCommunication = ElzabCommunication.CommunicationStatus.FinishSuccess;
                else elzabCommunicationEnt.StatusOfCommunication = ElzabCommunication.CommunicationStatus.FinishFailed;

                elzabCommunicationEnt.ElzabCommandReportStatusCode = reportStatus.ErrorNumber;
                elzabCommunicationEnt.ElzabCommandReportStatusText = reportStatus.ErrorText;

                elzabCommunicationEnt.ElzabCommandName = commandInstance.DataToElzab.CommandName;
                commandInstance.DataToElzab.DatabaseCommands.AddToElzabCommunication(elzabCommunicationEnt);

                //Read data from object
                if (reportStatus.ErrorNumber == 0)
                {
                    //Read data from files
                    if (commandInstance.DataFromElzab != null)
                    {
                        commandInstance.DataFromElzab.GenerateObjectFromRawData();
                    }
                }
            }

            return reportStatus;
        }
    }



}
