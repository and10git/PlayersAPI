using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects
{
    public class EmailVO : SimpleStringValueObject<EmailVO>
    {
        public string _value { get; private set; }
        private const string EMAIL_REGEX = @"\w+([-+.’]\w +)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        public EmailVO(string email) : base(email)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (!IsValid(email))
                throw new ArgumentException("Invalid value.", nameof(email));

            this._value = email;
        }

        private bool IsValid(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                string expresion = EMAIL_REGEX;
                var isValid = Regex.IsMatch(email, expresion);
                return isValid;
            }
            catch
            {
                return false;
            }
        }
    }
}
