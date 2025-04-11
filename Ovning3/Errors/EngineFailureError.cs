using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning3.Errors;

public class EngineFailureError : SystemError
{
    public override string ErrorMessage()
    {
        return "Motorfel: Kontrollera motorstatus!";
    }
}
