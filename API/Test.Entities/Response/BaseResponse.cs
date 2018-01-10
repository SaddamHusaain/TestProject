using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities.Response
{
    /// <summary>
    /// <CreatedBy>Harmesh</CreatedBy>
    /// <Purpose>This class act as a base class for all response classes used in the application.</Purpose>
    /// </summary>
    public class BaseResponse
    {
        private bool p_success = true;

        public Boolean Success
        {
            get
            {
                return p_success;
            }
            set
            {
                p_success = value;
            }
        }
        public string Message { get; set; }
    }
}
