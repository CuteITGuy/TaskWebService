using System;
using System.Linq;
using System.Web.Http;


namespace NumberController
{
    public class IntegerController: ApiController
    {
        #region Fields
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        #endregion


        #region Methods
        [HttpGet]
        public int[] GetIntegers()
            => ParallelEnumerable.Range(0, _random.Next(200)).Select(i => _random.Next(100, 1000)).ToArray();
        #endregion
    }
}