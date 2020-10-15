using System.IO;
using System.Text.RegularExpressions;
using ElzabDriver;

namespace ElzabCommands
{
    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OPSPRZED: InitStructure
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
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

        //Class constructor
        public ElzabCommand_OPSPRZED(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzab(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

            //Call method used to initialize base structure for data to Elzab
            this.DataToElzab = InitBaseStructuresDataToElzab(path, cashRegisterID, CommandName, ElementAttributesPatternInFile);
        }



    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_KGRUPA : ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
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

        //Class constructor
        public ElzabCommand_KGRUPA(string path, int cashRegisterID)
        {
            //Initialize object containing information from ELZAB
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile, cashRegisterID,
                ElementAttributesPatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.InputFile, cashRegisterID,
                headerPatternLine1: "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                ElementAttributesPatternInFile);

            //Initialize basic header information
            this.DataToElzab.Header.HeaderLine1.AddElement();
            this.DataToElzab.Header.HeaderLine1.ChangeAttributeValue(0, "device_number", cashRegisterID.ToString());
            this.DataToElzab.Header.HeaderLine2.AddElement();
            this.DataToElzab.Header.HeaderLine2.ChangeAttributeValue(0, "", "");
            this.DataToElzab.Header.HeaderLine3.AddElement();
            this.DataToElzab.Header.HeaderLine3.ChangeAttributeValue(0, "", "");

        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_ZGRUPA : ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
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

        //Class constructor
        public ElzabCommand_ZGRUPA(string path, int cashRegisterID)
        {
            //Initialize object containing information from ELZAB
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile, cashRegisterID,
                ElementAttributesPatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.InputFile, cashRegisterID,
                headerPatternLine1: "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                ElementAttributesPatternInFile);

            //Initialize basic header information
            this.DataToElzab.Header.HeaderLine1.AddElement();
            this.DataToElzab.Header.HeaderLine1.ChangeAttributeValue(0, "device_number", cashRegisterID.ToString());
            this.DataToElzab.Header.HeaderLine2.AddElement();
            this.DataToElzab.Header.HeaderLine2.ChangeAttributeValue(0, "", "");
            this.DataToElzab.Header.HeaderLine3.AddElement();
            this.DataToElzab.Header.HeaderLine3.ChangeAttributeValue(0, "", "");

        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OGRUPA : ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
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

        //Class constructor
        public ElzabCommand_OGRUPA(string path, int cashRegisterID)
        {
            //Initialize object containing information from ELZAB
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile, cashRegisterID,
                ElementAttributesPatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.InputFile, cashRegisterID,
                headerPatternLine1: "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                ElementAttributesPatternInFile);

            //Initialize basic header information
            this.DataToElzab.Header.HeaderLine1.AddElement();
            this.DataToElzab.Header.HeaderLine1.ChangeAttributeValue(0, "device_number", cashRegisterID.ToString());
            this.DataToElzab.Header.HeaderLine2.AddElement();
            this.DataToElzab.Header.HeaderLine2.ChangeAttributeValue(0, "", "");
            this.DataToElzab.Header.HeaderLine3.AddElement();
            this.DataToElzab.Header.HeaderLine3.ChangeAttributeValue(0, "", "");

        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OBAJTY : ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
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

        //Class constructor
        public ElzabCommand_OBAJTY(string path, int cashRegisterID)
        {
            //Initialize object containing information from ELZAB
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile, cashRegisterID,
                ElementAttributesPatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.InputFile, cashRegisterID,
                headerPatternLine1: "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                ElementAttributesPatternInFile);

            //Initialize basic header information
            this.DataToElzab.Header.HeaderLine1.AddElement();
            this.DataToElzab.Header.HeaderLine1.ChangeAttributeValue(0, "device_number", cashRegisterID.ToString());
            this.DataToElzab.Header.HeaderLine2.AddElement();
            this.DataToElzab.Header.HeaderLine2.ChangeAttributeValue(0, "", "");
            this.DataToElzab.Header.HeaderLine3.AddElement();
            this.DataToElzab.Header.HeaderLine3.ChangeAttributeValue(0, "", "");

        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_ZTOWAR : ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataToElzab { get; set; }
        private string CommandName { get { return "ZTOWAR"; } }
        private string ElementAttributesPatternInFile
        {
            get
            {
                return "$nr_tow naz_tow ST GR MP JM BL bkod cena OP";
            }
        }

        //Class constructor
        public ElzabCommand_ZTOWAR(string path, int cashRegisterID)
        {
            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.InputFile, cashRegisterID,
                headerPatternLine1: "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                ElementAttributesPatternInFile);

            //Initialize basic header information
            this.DataToElzab.Header.HeaderLine1.AddElement();
            this.DataToElzab.Header.HeaderLine1.ChangeAttributeValue(0, "device_number", cashRegisterID.ToString());
            this.DataToElzab.Header.HeaderLine2.AddElement();
            this.DataToElzab.Header.HeaderLine2.ChangeAttributeValue(0, "", "");
            this.DataToElzab.Header.HeaderLine3.AddElement();
            this.DataToElzab.Header.HeaderLine3.ChangeAttributeValue(0, "", "");

        }

    }


    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OTOWAR : ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        private string CommandName { get { return "OTOWAR"; } }

        private string ElementAttributesPatternOutFile
        {
            get
            {
                return "< plu_no > < art_name > < tax_rate_no > " +
                        "< dept_no > < quantity_precision > < unit_no > < sale_bloc > < main_barcode > " +
                        "< price > < is_pack > < disc_sur_bloc > < free_price_allow > < on_handy_list > " +
                        "< scale_no > < last_sale_date_time >link_plu_no >";
            }
        }

        private string ElementAttributesPatternInFile
        {
            get
            {
                return "< nr_tow >";
            }
        }



        //Class constructor
        public ElzabCommand_OTOWAR(string path, int cashRegisterID)
        {
            //Initialize object containing information from ELZAB
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile, cashRegisterID,
                ElementAttributesPatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.InputFile, cashRegisterID,
                headerPatternLine1: "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                ElementAttributesPatternInFile);

            //Initialize basic header information
            this.DataToElzab.Header.HeaderLine1.AddElement();
            this.DataToElzab.Header.HeaderLine1.ChangeAttributeValue(0, "device_number", cashRegisterID.ToString());
            this.DataToElzab.Header.HeaderLine2.AddElement();
            this.DataToElzab.Header.HeaderLine2.ChangeAttributeValue(0, "", "");
            this.DataToElzab.Header.HeaderLine3.AddElement();
            this.DataToElzab.Header.HeaderLine3.ChangeAttributeValue(0, "", "");

        }
    }

    public class InitStructure
    {
        protected ElzabFileObject InitBaseStructuresDataFromElzab(string path, int cashRegisterID, string commandName,
        string elementAttributesPatternOutFile)
        {

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataFromElzab = new ElzabFileObject(path, commandName, FileType.OutputFile, cashRegisterID,
                elementAttributesPattern: elementAttributesPatternOutFile);

            return _dataFromElzab;
        }

        protected ElzabFileObject InitBaseStructuresDataToElzab(string path, int cashRegisterID, string commandName,
            string elementAttributesPatternInFile)
        {

            //Initialize object containing information to ELZAB
            ElzabFileObject _dataToElzab = new ElzabFileObject(path, commandName, FileType.InputFile, cashRegisterID,
                headerPatternLine1: "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                elementAttributesPatternInFile);

            return _dataToElzab;
        }
    }



}
