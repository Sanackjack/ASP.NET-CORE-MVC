using System;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace RestFulASPNET.Constants
{
	public class ExceptionCode
	{
        public static readonly string AUTHENTICATION_FAIL = "AUTHENTICATION_FAIL";
        public static readonly string INCORRECT_USERNAME_PASSWORD = "INCORRECT_USERNAME_PASSWORD";
        public static readonly string USER_LOCK = "USER_LOCK";
        public static readonly string USER_NOT_ACTIVE = "USER_NOT_ACTIVE";
        public static readonly string SIGNATURE_NOT_MATCH = "SIGNATURE_NOT_MATCH";
        


        //.. add your design


        public static readonly Dictionary<string, ErrorViewModel> ErrorCodes = new Dictionary<string, ErrorViewModel>
        {
            //Authentication 1XXX
            { AUTHENTICATION_FAIL, new ErrorViewModel("1001","Authentication fail.",401) },
            { INCORRECT_USERNAME_PASSWORD, new ErrorViewModel("1002","Username or Password is incorrect.",401) },
            { USER_LOCK, new ErrorViewModel("1003","Username is lock.",401) },
            { USER_NOT_ACTIVE, new ErrorViewModel("1004","Username is not active.",401) },
            { SIGNATURE_NOT_MATCH, new ErrorViewModel("1005","Signature does not match or invalid..",401) }

        };

        public class ErrorViewModel
        {
            public string code { get; set; }
            public string message { get; set; }
            public int statusHttps { get; set; }
            public ErrorViewModel(string code, string message, int statusHttps)
            {
                this.code = code;
                this.message = message;
                this.statusHttps = statusHttps;
            }
        }

    }

}


//public class Person
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//}

//List<Person> test = new List<Person>
//{
//    new Person { Name = "Bob", Age = 22 },
//    new Person { Name = "Bob", Age = 28 },
//    new Person { Name = "Sally", Age = 22 },
//    new Person { Name = "Sally", Age = 22 },
//    new Person { Name = "Jill", Age = 22 },
//}

//// Aggregate each person
//Dictionary<string, List<int>> results = test.ToDictionaryValueList((p) => p.Name, (p) => p.Age);

//// Use the AddToList extension method to add more values as neeeded
//results.AddToList("Jill", 23);






//public const IDictionary<string, string> ErrorCodeDic;
//public static ErrorCode()
//{
//    ErrorCodeDic = new Dictionary<string, string>()
//            { {"1", "User name or password problem"} };
//}


//public static readonly RegionMap = new Dictionary<int, string>
//{
//    { 1, "US" },
//    { 2, "US" },
//    { 3, "Canada" },
//    { 4, "Canada" }
//}

//    public static string GetRegion(int code)
//{
//    string name;
//    if (!RegionMap.TryGetValue(code, out name)
//        {
//        // Error handling here
//    }
//    return name;
//}


