using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning3.Errors;

public class BrakeFailureError : SystemError
{
    public override string ErrorMessage()
    {
        return "Bromsfel: Fordonet är osäkert att köra!";
    }
}
