using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Repository.IRepository;
using Test.Service.IService;

namespace Test.Service.Service
{
    public class TestService: ITestService
    {
        #region Private

        private ITestRepository _ITestRepository;

        #endregion

        public TestService(ITestRepository ITestRepository)
        {
            _ITestRepository = ITestRepository;
        }


        #region public

        public void  Test()
        {
            _ITestRepository.Test();
        }

        #endregion
    }
}
