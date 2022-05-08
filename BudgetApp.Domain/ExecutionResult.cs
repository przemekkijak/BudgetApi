using System.Collections.Generic;
using System.Diagnostics;

namespace BudgetApp.Domain
{
    [DebuggerDisplay("IsSuccess: {Success}")]
    public class ExecutionResult
    {
        private bool? _success;
        
        public bool Success
        {
            get => _success == true || Errors.Count == 0;
            set => _success = value;
        }
        
        public IList<ErrorInfo> Errors { get; set; }

        public ExecutionResult()
            : this((ExecutionResult)null)
        {
        }

        public ExecutionResult(string errorCode, string errorDescription) : this(new ErrorInfo(errorCode, errorDescription))
        {}
        
        public ExecutionResult(ErrorInfo error)
            : this((ExecutionResult)null)
        {
            Errors.Add(error);
        }

        public ExecutionResult(IEnumerable<ErrorInfo> errors)
            : this((ExecutionResult)null)
        {
            foreach (var errorInfo in errors)
            {
                Errors.Add(errorInfo);
            }
        }
        
        public ExecutionResult(ExecutionResult result)
        {
            Errors = new List<ErrorInfo>();
            if (result == null)
            {
                return;
            }
            foreach (ErrorInfo errorInfo in result.Errors)
            {
                Errors.Add(errorInfo);
            }
            Success = result.Success;
        }
    }
    
    /// <summary>
    /// Represents result of an action that returns any value
    /// </summary>
    /// <typeparam name="T">Type of value to be returned with action</typeparam>
    [DebuggerDisplay("IsSuccess: {Success}")]
    public class ExecutionResult<T> : ExecutionResult
    {
        public ExecutionResult()
            : this((ExecutionResult)null)
        {
        }

        public ExecutionResult(T result)
            : this((ExecutionResult)null)
        {
            Value = result;
        }

        public ExecutionResult(ErrorInfo error)
            : this((ExecutionResult)null)
        {
            Errors.Add(error);
        }

        public ExecutionResult(IEnumerable<ErrorInfo> errors)
            : this((ExecutionResult)null)
        {
            foreach (ErrorInfo errorInfo in errors)
            {
                Errors.Add(errorInfo);
            }
        }

        public ExecutionResult(ExecutionResult result)
            : base(result)
        {
            if (result is ExecutionResult<T> r)
            {
                Value = r.Value;
            }
        }

        public T Value { get; set; }
    }
}