using System.IO;
using System.Text.RegularExpressions;
using ElzabDriver;

namespace ElzabCommands
{
    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OPSPRZED : ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        private string CommandName { get { return "OPSPRZED"; } }
        private string ElementAttributePatternOutFile
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
            //Initialize object containing information from ELZAB
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile,
                ElementAttributePatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.Inputfile,
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
    public class ElzabCommand_KGRUPA : ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        private string CommandName { get { return "KGRUPA"; } }
        private string ElementAttributePatternOutFile
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
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile,
                ElementAttributePatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.Inputfile,
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
        private string ElementAttributePatternOutFile
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
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile,
                ElementAttributePatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.Inputfile,
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
        private string ElementAttributePatternOutFile
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
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile,
                ElementAttributePatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.Inputfile,
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
        private string ElementAttributePatternOutFile
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
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile,
                ElementAttributePatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.Inputfile,
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
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.Inputfile,
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

        private string ElementAttributePatternOutFile
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
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile,
                ElementAttributePatternOutFile);

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.Inputfile,
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


}
