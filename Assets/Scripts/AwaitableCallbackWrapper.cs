using System;
using System.Collections.Generic;
using Simple.Threading.Tasks;

namespace DefaultNamespace
{
    public class AwaitableCallbackWrapper : BaseAwaitableTask
    {
        public Action GetWrapper()
        {
            return () =>
            {
                Complete();
            };
        }
    }

    public class AwaitableCallbackWrapper<TResult> : BaseAwaitableTask<TResult>
    {
        private TResult _result;
        public Action<TResult> GetWrapper()
        {
            return (result) =>
            {
                _result = result;
                Complete();
            };
        }
        
        public override TResult GetResult()
        {
            return _result;
        }
    }
    
    public class AwaitableCallbackWrapper<TResult1, TResult2> : BaseAwaitableTask<List<object>>
    {
        private List<object> _result = new List<object>{};
        public Action<TResult1, TResult2> GetWrapper()
        {
            return (result1, result2) =>
            {
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
    
    public class AwaitableCallbackWrapper<TResult1, TResult2, TResult3> : BaseAwaitableTask<List<object>>
    {
        private List<object> _result = new List<object>{};
        public Action<TResult1, TResult2, TResult3> GetWrapper()
        {
            return (result1, result2, result3) =>
            {
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
    
    public class AwaitableCallbackWrapper<TResult1, TResult2, TResult3, TResult4> : BaseAwaitableTask<List<object>>
    {
        private List<object> _result = new List<object>{};
        public Action<TResult1, TResult2, TResult3, TResult4> GetWrapper()
        {
            return (result1, result2, result3, result4) =>
            {
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
    
    public class AwaitableCallbackWrapper<TResult1, TResult2, TResult3, TResult4, TResult5> : BaseAwaitableTask<List<object>>
    {
        private List<object> _result = new List<object>{};
        public Action<TResult1, TResult2, TResult3, TResult4, TResult5> GetWrapper()
        {
            return (result1, result2, result3, result4, result5) =>
            {
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