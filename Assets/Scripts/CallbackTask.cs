using System;
using System.Collections.Generic;

namespace Simple.Threading.Tasks
{
    public class CallbackTask : AwaitableTask
    {
        public Action GetWrapper()
        {
            return () =>
            {
                IsCompleted = true;
                Complete();
            };
        }
    }

    public class CallbackTask<TResult> : AwaitableTask<TResult>
    {
        private TResult _result;
        public Action<TResult> GetWrapper()
        {
            return (result) =>
            {
                IsCompleted = true;
                _result = result;
                Complete();
            };
        }
        
        public override TResult GetResult()
        {
            return _result;
        }
    }
    
    public class CallbackTask<TResult1, TResult2> : AwaitableTask<List<object>>
    {
        private List<object> _result = new List<object>{};
        public Action<TResult1, TResult2> GetWrapper()
        {
            return (result1, result2) =>
            {
                IsCompleted = true;
                _result.Add(result1);
                _result.Add(result2);
                Complete();
            };
        }
        
        public override List<object> GetResult()
        {
            return _result;
        }
    }
    
    public class CallbackTask<TResult1, TResult2, TResult3> : AwaitableTask<List<object>>
    {
        private List<object> _result = new List<object>{};
        public Action<TResult1, TResult2, TResult3> GetWrapper()
        {
            return (result1, result2, result3) =>
            {
                IsCompleted = true;
                _result.Add(result1);
                _result.Add(result2);
                _result.Add(result3);
                Complete();
            };
        }
        
        public override List<object> GetResult()
        {
            return _result;
        }
    }
    
    public class CallbackTask<TResult1, TResult2, TResult3, TResult4> : AwaitableTask<List<object>>
    {
        private List<object> _result = new List<object>{};
        public Action<TResult1, TResult2, TResult3, TResult4> GetWrapper()
        {
            return (result1, result2, result3, result4) =>
            {
                IsCompleted = true;
                _result.Add(result1);
                _result.Add(result2);
                _result.Add(result3);
                _result.Add(result4);
                Complete();
            };
        }
        
        public override List<object> GetResult()
        {
            return _result;
        }
    }
    
    public class CallbackTask<TResult1, TResult2, TResult3, TResult4, TResult5> : AwaitableTask<List<object>>
    {
        private List<object> _result = new List<object>{};
        public Action<TResult1, TResult2, TResult3, TResult4, TResult5> GetWrapper()
        {
            return (result1, result2, result3, result4, result5) =>
            {
                IsCompleted = true;
                _result.Add(result1);
                _result.Add(result2);
                _result.Add(result3);
                _result.Add(result4);
                _result.Add(result5);
                Complete();
            };
        }
        
        public override List<object> GetResult()
        {
            return _result;
        }
    }
}