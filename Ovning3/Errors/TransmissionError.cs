using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning3.Errors;

public class TransmissionError : SystemError
{
    public override string ErrorMessage()
    {
        return "Växellådsproblem: Reparation krävs!";
    }
}
