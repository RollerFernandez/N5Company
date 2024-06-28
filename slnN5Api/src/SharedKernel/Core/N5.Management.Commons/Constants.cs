namespace N5.Management.Commons
{
    public static class Constants
    {
        public struct Core
        {
            
            public struct AccessLevel
            {
                public const string INTERNO = "Interno";
                public const string EXTERNO = "Externo";
            }


            public struct Topic
            {
                public const string PERMISSIONS = "Permissions-topic";
            }

            public struct IndexElastic
            {
                public const string PERMISSIONS = "permissions";
                public const string PERMISSION_TYPE = "permissiontypes";
                public const string EMPLOYEE = "employees";
            }

            public struct Audit
            {
                public const string CREATION_USER = "CreationUser";
                public const string CREATION_DATE = "CreationDate";
                public const string MODIFICATION_USER = "ModificationUser";
                public const string MODIFICATION_DATE = "ModificationDate";
                public const string ROW_STATUS = "RowStatus";
                public const string SYSTEM = "System";
            }


            public struct UserClaims
            {
                public const string UserId = "UserId";
                public const string UserName = "UserName";
                public const string Role = "Role";
                public const string FullName = "FullName";
                public const string Society = "Society";
                public const string ServiceOrganization = "ServiceOrganization";
            }

            public struct UserStatus
            {
                public const string ACTIVE = "A";
                public const string INACTIVE = "I";
                public const string TEXT_ACTIVE = "Active";
                public const string TEXT_INACTIVE = "Inactive";
            }

            public struct ContractService
            {
                public const string TypeContractService = "C";
                public const string TypeAddendumService = "A";
                public const string TypeClient = "C";
                public const string InitialValueCorrelative = "001";
                public const string TypeUnitOfMeasurementForContractService = "H";
                public const int Top10Registers = 10;
                public const string NameFileReport = "ServiceContractReport.xlsx";
            }

            public struct TextLabel
            {
                public const string CreationDate = "Creation Date";
                public const string ContractCode = "Contract Code";
                public const string Company = "Company";
                public const string Warehouse = "Warehouse";
                public const string Client = "Client";
                public const string OperationType = "Operation Type";
                public const string Ticket = "Ticket";
                public const string Waybill = "Waybill";
                public const string ReceptionDate = "Reception Date & Time";
                public const string LeavingDate = "Leaving Date & Time";
                public const string Supplier = "Supplier";
                public const string GrossWeight = "Gross Weight";
                public const string TareWeight = "Tare Weight";
                public const string NetWeight = "Net Weight";
                public const string WaybillNetWeight = "Waybill Net Weight";
                public const string WeightDifference = "Weight Difference";
                public const string LicensePlate = "License Plate";
                public const string TruckPlate = "Truck Plate";
                public const string Driver = "Driver";
                public const string Carrier = "Carrier";
                public const string Package = "Package";
                public const string BigBagQuantity = "BigBag Quantity";
                public const string Operator1 = "Operator 1";
                public const string Operator2 = "Operator 2";
                public const string Product = "Product";
                public const string Tonnage = "Tonnage";
                public const string Franchise = "Franchise %";
                public const string InitialDate = "Initial Date";
                public const string FinalDate = "Final Date";
                public const string CloseDate = "Close Date";
                public const string State = "State";
                public const string CancellationReason = "Cancellation Reason";
                public const string RegistrationUser = "Registration User";
                public const string RegistrationDate = "Registration Date";
                public const string UpdateUser = "Update User";
                public const string UpdateDate = "Update Date";

                public const string Id = "Id";
                public const string NameRole = "Name Role";
                public const string Description = "Description";


            }

            public struct DateTimeFormats
            {
                public const string DD_MM_YYYY_HH_MM_SS_FFF = "yyyyMMddHHmmssFFF";
                public const string YY = "yy";
                public const string OnlyDate = "dd/MM/yy";
                public const string OnlyDateAndTime = "dd/MM/yy HH:mm:ss";
                public const string OnlyDateAndTimeShort = "dd/MM/yy HH:mm";
                public const string OnlyDateAndTimeHM = "dd/MM/yy HH:mm";
                public const string DateFormatReportName = "yyMMddHHmm";
            }

            public static class Token
            {
                public const string TOKEN_STATUS = "TETK";

                public const string CURRENT_USER = "CurrentUser";
                public const string ACCESS_LEVEL = "AccessLevel";
                public const string ROLES_INTERNO = "RolesInterno";

                public struct Estados
                {
                    public const string ACTIVE = "ETKA";
                    public const string CANCEL = "ETKC";
                    public const string COMPLETE = "ETKS";
                    public const string EXPIRE = "ETKX";
                }

                public struct Motive
                {
                    public const string AUTENTICATION = "MTKA";
                    public const string RECOVERY_PASSWORD = "MTKX";
                    public const string INVITATION_CONTACT = "MTKC";
                }

                public struct Vigency
                {
                    public const string VIGENCIA_AUTENTICACION = "VTKA";
                    public const string VIGENCIA_RECUPERAR_CONTRASENA = "VTKX";
                    public const string VIGENCIA_INVITACION_CONTACTO = "VTKC";
                }
            }

        }

        public static class Seguridad
        {
            public struct TypeUser
            {
                public const string CLIENT = "C";
                public const string ASESOR = "A";
            }

            public struct RolInternal
            {

            }
        }


        public static class MonthDescription
        {
            public static string GetMonthDescription(string numberMonth)
            {
                switch (numberMonth)
                {
                    case "01":
                        return "Enero";

                    case "02":
                        return "Febrero";

                    case "03":
                        return "Marzo";

                    case "04":
                        return "Abril";

                    case "05":
                        return "Mayo";

                    case "06":
                        return "Junio";

                    case "07":
                        return "Julio";

                    case "08":
                        return "Agosto";

                    case "09":
                        return "Septiembre";

                    case "10":
                        return "Octubre";

                    case "11":
                        return "Noviembre";

                    case "12":
                        return "Diciembre";

                    default:
                        return "NO RELEVANTE";
                }
            }
        }

        public struct Common
        {
            public struct Domain
            {
                public const string LIST_CLIENTS = "LIST_CLIENTS";
                public const string LIST_CURRENCIES = "LIST_CURRENCIES";
                public const string LIST_DELIVERIES = "LIST_DELIVERIES";
                public const string LIST_ELEMENTS = "LIST_ELEMENTS";
                public const string LIST_LABORATORIES = "LIST_LABORATORIES";
                public const string LIST_LOCATIONS = "LIST_LOCATIONS";
                public const string LIST_PRODUCTS = "LIST_PRODUCTS";
                public const string LIST_QUALITIES = "LIST_QUALITIES";
                public const string LIST_SERVICES = "LIST_SERVICES";
                public const string LIST_STOCK_GROUPS = "LIST_STOCK_GROUPS";
                public const string LIST_SUPPLIERS = "LIST_SUPPLIERS";
                public const string LIST_UNITS_OF_MEASUREMENT = "LIST_UNITS_OF_MEASUREMENT";
                public const string LIST_USERS = "LIST_USERS";
            }
            public struct Numbers
            {
                public const int Ten = 10;
            }
            public struct GenericName
            {
                public const string Clients = "ClientReport";
                public const string Contract = "ContractReport";
                public const string PurchaseSale = "PurchaseSale";
                public const string ContractService = "ContractService";
                public const string ModelContractService = "ModelContractService";
                public const string NameSheetExcelReportContractService = "Contract of Service";
                public const char CHAR_ZERO = '0';
                public const string DateFormat = "dd/MM/yy";
                public const string DateHourFormat = "dd/MM/yy HH:mm:ss";
                public const string ReportAssignTruckLot = "ReceptionUnitReport";


            }
            public struct FormatNumber
            {
                public const string TwoDecimalPlaces = "0.00";
                public const string ThreeDecimalPlaces = "0.000";

            }
            public struct FileExtension
            {
                public const string Excel = "xlsx";
                public const string Pdf = "pdf";
            }
            public struct ContentType
            {
                public const string Excel = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                public const string Pdf = "application/octet-stream";
            }
            public struct Messages
            {
                public const string RegistrationDoesNotExist = "Registration does not exist.";
                public const string ThereAreNoRecords = "There are no records";
                public const string DocumentAlreadyEntered = "Document already entered";
                public const string ValidationByName = "Name or company name already entered";
                public const string RequestPurchaseSaleContractNotValid = "Request for invalid purchase and sale contract";
                public const string NoAttachment = "There is no attachment for this record";
                public const string ErrorDownloadingFile = "An error occurred while trying to download the file";
                public const string RegistrationAlreadyExists = "A record with the value \"{0}\" already exists.";

                public const string ErrorFileNotFound = "There is no attachment for this record";
                public const string ErrorRecordNotFound = "Record Not Found";
                public const string ErrorUploadFile = "An error occurred while uploading the file";
                public const string ErrorDeleteFile = "Could not delete file";
                public struct Security
                {
                    public const string UserInactive = "No se encontró entrada";
                    public const string ContrasenTamanioMinimo = "HPDAA0284E";
                    public const string ContrasenCaracteresEspeciales = "HPDAA0285E";

                    public const string ErrorValidatingMail = "Unregistered user";
                    public const string IncorrectPassword = "Not exists permissions";
                    public const string NoOptionsAssigned = "No options assigned";
                    public const string NoWarehouseAssigned = "No Warehouse assigned";
                }
            }

            public struct StatusResponse
            {
                public const int FUNCTIONAL_ERROR = 1;
                public const int OK = 200;
                public const int TECNICAL_ERROR = -1;

                public struct MenuExterno
                {
                    public const int ESTADO_ACCESOS = 2;
                }
            }

            public struct RegexValidation
            {
                public const string PasswordForte = "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[.,?!@+*\\-_\\$])[A-Za-z0-9.,?!@+*\\-_\\$]+$";
                public const string AnyNumber = @"^[0-9]*$";
                public const string AnyLetter = @"^[a-zA-Z\u00C0-\u00FF ]*$";
                public const string SoloLetrasRazonSocial = @"^[a-zA-Z\u00C0-\u00FF.\\-_ ]*$";
            }

            public struct Currency
            {
                public const string USD = "$";
                public const string PEN = "S/";
            }

            public struct Parameters
            {
                public const string Name = "Parameters";
                public const string NameTypeClient = "TypeClient";
                public const string NameTypeDocument = "TypeDocument";
                public const string NameStatus = "Status";
                public const string ContractType = "ContractType";
                public const string NameContractualTonnageUnit = "ContractualTonnageUnit";
                public const string NameFinalAssayCriteria = "FinalAssayCriteria";
                public const string NameLaboratory = "Laboratory";
                public const string NameQuality = "Quality";
            }
        }

        public static class EstadoRespuesta
        {
            public const int ERROR_FUNCIONAL = 1;
            public const int ERROR_TECNICO = 2;
            public const int OK = 0;
        }
    }

}
