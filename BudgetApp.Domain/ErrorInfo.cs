using System;

namespace BudgetApp.Domain
{
    public class ErrorInfo
    {
        /// <summary>
        /// Code of error
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        public string TranslateKey { get; set; }

        /// <summary>
        /// Default constructor of class
        /// </summary>
        public ErrorInfo()
            : this(String.Empty, String.Empty)
        {
        }

        public ErrorInfo(string errorMessage)
            : this(Guid.NewGuid().ToString(), errorMessage)
        {
        }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="code">Key of error (for example, property name)</param>
        /// <param name="message">Error message</param>
        public ErrorInfo(string code, string message) : this(code, message, string.Empty)
        {

        }

        public ErrorInfo(string code, string message, string translateKey)
        {
            Code = code;
            Message = message;
            if (!string.IsNullOrEmpty(translateKey))
            {
                TranslateKey = translateKey;
            }
            else
            {
                TranslateKey = code;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}. Code: '{1}', Message: '{2}', TRanslationKey: '{3}'", base.ToString(), Code, Message, TranslateKey);
        }
    }
}