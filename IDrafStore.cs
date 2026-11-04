

namespace Techicians.services ;                                 
using Techicians.Models;

public interface IDraftStore       // تخزين بيانات  مؤقت 
{
Task SaveAsync(DraftSnapshot snapshot); // حفظ بيانات  مؤقتةً
Task <DraftSnapshot?>loadAsync(); //  استرجاع البيانات المحفوظة مؤقتةًً 
Task ClearAsync();    //مسح البيانات المحفوظة بعد التسجيل  
}