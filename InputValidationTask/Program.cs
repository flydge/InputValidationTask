using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace InputValidationTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Validation validation = new Validation();
            string[] emailAddresses = { "david.jones@proseware.com", "d.j@server1.proseware.com",
                "jones@ms1.proseware.com", "j.@server1.proseware.com",
                "j@proseware.com9", "js#internal@proseware.com",
                "j_9@[129.126.118.1]", "j..s@proseware.com",
                "js*@proseware.com", "js@proseware..com",
                "js@proseware.com9", "j.s@server1.proseware.com",
                "\"j\\\"s\\\"\"@proseware.com", "js@contoso.中国" };
            Console.WriteLine("\nemailAddresses:");
            foreach (var emailAddress in emailAddresses)
            {
                Console.WriteLine(validation.IsValidEmail(emailAddress) ? "Valid: {0}" : "Invalid: {0}", emailAddress);
            }

            Console.WriteLine("\nurlAddresses:");
            string[] urlAddresses =
            {
                "https://www.google.by/search?q=urls+array+c%23&oq=urls+array+c%23&aqs=chrome..69i57j0.6383j0j7&sourceid=chrome&ie=UTF-8",
                "https://msdn.microsoft.com/en-us/library/system.uri.iswellformeduristring%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396",
                "https://www.youtube.com/watch?v=9cJf1FKNTMI",
                "://music.yandex.by/artist/44252",
                @"C:\Program Files\JetBrains",
                @"C:\test\test2\test.exe"
                
            };

            foreach (var urlAddress in urlAddresses)
            {
                Console.WriteLine(Uri.IsWellFormedUriString(urlAddress,UriKind.RelativeOrAbsolute)?"Valid: {0}" : "Invalid: {0}",urlAddress);
            }

            Console.WriteLine("file paths:");
            foreach (var urlAddress in urlAddresses)
            {
                Console.WriteLine(validation.PathIsValid(urlAddress)?"Valid: {0}" : "Invalid: {0}",urlAddress);
            }

        }
    }
}