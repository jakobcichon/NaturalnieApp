using System.IO;
using System.Text.RegularExpressions;
using ElzabDriver;
using NaturalnieApp.ElzabDriver;
using static NaturalnieApp.Program;

namespace ElzabCommands
{

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OPSPROZ4: InitStructure, IElzabSaleBufforInterface
    {
        //Local variable
        public ElzabSaleBuffor DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        public ElzabFileObject Report { get; set; }
        public CommandExecutionStatus ReportStatus { get; set; }
        public ElzabFileObject Config { get; set; }
        private string CommandName { get { return "OPSPROZ4"; } }
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
        public ElzabCommand_OPSPROZ4(string path, int cashRegisterID)
        {
            //Call method used to initialize base structure for data from Elzab
            this.DataFromElzab = InitBaseStructuresDataFromElzabBuffor(path, cashRegisterID, CommandName, ElementAttributesPatternOutFile);

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

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataReport = new ElzabFileObject(path, commandName, FileType.ConfigFile, cashRegisterID,
                elementAttributesPattern: elementAttributesPatternOutFile);

            return _dataReport;
        }
        protected ElzabFileObject InitBaseStructuresReport(string path, int cashRegisterID, string commandName,
        string elementAttributesPatternOutFile)
        {

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataReport = new ElzabFileObject(path, commandName, FileType.ReportFile, cashRegisterID,
                elementAttributesPattern: elementAttributesPatternOutFile);

            return _dataReport;
        }

        protected ElzabFileObject InitBaseStructuresDataFromElzab(string path, int cashRegisterID, string commandName,
        string elementAttributesPatternOutFile)
        {

            //Initialize object containing information from ELZAB
            ElzabFileObject _dataFromElzab = new ElzabFileObject(path, commandName, FileType.OutputFile, cashRegisterID,
                elementAttributesPattern: elementAttributesPatternOutFile);

            return _dataFromElzab;
        }

        protected ElzabSaleBuffor InitBaseStructuresDataFromElzabBuffor(string path, int cashRegisterID, string commandName,
        string elementAttributesPatternOutFile)
        {

            //Initialize object containing information from ELZAB
            ElzabSaleBuffor _dataFromElzab = new ElzabSaleBuffor(path, commandName, FileType.SaleBufforFile, cashRegisterID,
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
            //if (result) result = commandInstance.DataToElzab.RunCommand();
            
            if (result)
            {

                //Read report data
                commandInstance.Report.GenerateObjectFromRawData();
                reportStatus = commandInstance.Report.ParseReportFileToObject();

                //Read data from object
                if(reportStatus.ErrorNumber == 0)
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
