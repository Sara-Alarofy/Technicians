using System;
using System.Collections.Generic;
using System.Text;

namespace Technicians.models
{
                                                    // حفظ بيانات الفني مؤقتةً 
    public record DraftSnapshot(
        int Version, 
        int StepNumber, 
        string TechnicianName,
        string ServiceCategory);
   

}
