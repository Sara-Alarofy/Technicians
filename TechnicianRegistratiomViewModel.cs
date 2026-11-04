using System;

namespace Technicians.ViewModels;            //***************

using System.Windows.Input;
using Technicians.Models;
using Technicians.Services;

public class TechnicianRegistrationViewModel
{
    private readonly IDraftStore _draftStore;

                                     // الخصائص المرتبطة بواجهة المستخدم لشاشة تسجيل الفنيين
    public int StepNumber { get; set; } = 1;
    public string TechnicianName { get; set; } = string.Empty;
    public string ServiceCategory { get; set; } = string.Empty;

    public ICommand SaveDraftCommand { get; }
    public ICommand ClearCommand { get; }

    public TechnicianRegistrationViewModel(IDraftStore draftStore)
    {
        _draftStore = draftStore;
        SaveDraftCommand = new Command(async () => await SaveDraftAsync());
        ClearCommand = new Command(async () => await ClearDraftAsync());

        // استرجاع المسودة تلقائياً فور فتح شاشة تسجيل الفني
        Task.Run(async () => await RestoreDraftAsync());
    }

    public async Task SaveDraftAsync()
    {
        var snapshot = new DraftSnapshot(CurrentVersion: 1, StepNumber, TechnicianName, ServiceCategory);
        await _draftStore.SaveAsync(snapshot);
    }

    public async Task RestoreDraftAsync()
    {
        var snapshot = await _draftStore.LoadAsync();
        if (snapshot != null)
        {
            StepNumber = snapshot.StepNumber;
            TechnicianName = snapshot.TechnicianName;
            ServiceCategory = snapshot.ServiceCategory;
        }
    }

    public async Task ClearDraftAsync()
    {
        await _draftStore.ClearAsync();
        StepNumber = 1;
        TechnicianName = string.Empty;
        ServiceCategory = string.Empty;
    }
}