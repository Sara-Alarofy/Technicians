using System;
using System.Collections.Generic;
using System.Text;

namespace Technicians.models
{
    //internal class DraftSnapshot
    public record DraftSnapshot(int Version, int StepNumber, string TechnicianName, string ServiceCategory);
   

}
