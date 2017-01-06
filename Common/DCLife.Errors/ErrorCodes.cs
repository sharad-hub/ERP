using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCLife.Errors
{
    public static class ErrorCodes
    {
        public readonly static long CASE_ACCESS_NOT_ALLOWED = 100; // Case is not accessible

        public readonly static long NO_PERSON_TITLE_FOUND = 101; // No person title Exists
        //public readonly static int DOC_ACCESS_NOT_ALLOWED = -2; // Case is not accessible
        //public readonly static int Note_ACCESS_NOT_ALLOWED = -3; // Case is not accessible
        //public readonly static int ORDER_ACCESS_NOT_ALLOWED = -4; // Case is not accessible

        //case creation static field
        public readonly static long XML_XSD_VALIDATION_FAILED = -5000;
        public readonly static long XML_DATA_VALIDATION_FAILED = -5001;
        public readonly static long XML_BLANK = -5002;
        public readonly static long CASE_CREATION_SUCCESS = 5004;
        public readonly static long CASE_CREATION_FAILED = -5003;
        public readonly static long CASE_CREATION_OBJECT_FAILED = -5005;
        public readonly static long USER_NOT_DELETED_DISABLED = -5006;
        public readonly static long USER_NOT_ACCESS_TO_BRAND = -5007;


        public static string GetDetails(long code)
        {
            switch (code)
            {
                case 100:
                    return "Case access not allowed.";
                case 101:
                    return "No person title Exists.";
                //Case Creation Part
                case -5000:
                    return "XML Validation Request Failed.";
                case -5001:
                    return "XML Data Validation Failed.";
                case -5002:
                    return "XML data is Blank.";
                case 5004:
                    return "Case Created Successfully";
                case -5003:
                    return "Case Creation Failed";
                case -5005:
                    return "Case Creation Object Failed";
                case -5006:
                    return "User Does not exists or disabled or deleted.";
                case -5007:
                    return "User is not authorised to create case in current brand";
                default:
                    return "Error detail not known ";
            }

        }

        public static class CqStage
        {
            public readonly static long FIRST_STEP = 6001;
            public readonly static long CASE_HANDLER = 6002;
            public readonly static long CL_ADDRESS = 6003;
            public readonly static long CL_COMM = 6004;
            public readonly static long CL_CASEPERSON = 6005;
            public readonly static long CL_ADDRESS_MAPPING = 6006;
            public readonly static long CASE_ORDER = 6007;
            public readonly static long ORDER_PRICE = 6008;
            public readonly static long OPTIONAL_DATA = 6009;
            public readonly static long SPECIFIC_NOTE = 6010;
            public readonly static long CASE_STATUS = 6011;
            public readonly static long MILESTONE_LOG = 6012;
            public readonly static long SCHEDULE_TASK = 6013;
            public readonly static long CASE_HANDELER_COMM = 6015;
            public readonly static long CL_ADD_PERSON = 6020;
            public readonly static long SUP_ADDRESS_MAPPING = 6021;
            public readonly static long SUP_ADD_PERSON = 6022;
            public readonly static long SUP_COMM = 6023;
            public readonly static long SUP_CASEPERSON = 6024;
            public readonly static long CASE_ORDERREQ = 6025;

        }
    }
}
