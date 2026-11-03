using System;
namespace Techicians.models;                   //للتخزين المحلي 

using System.Text.Json;
using Techicians.services;

public class PreferencesDraftStore : IDraftStore
{
	private const string DraftKey = "technicins_draft_key";
	private const int CurrentVersion = 1;

	public Task SaveAsync(DraftSnapshot snapshot)
	{
		var json = JsonSerializer.Serialize(snapshot);
		Preferences.Set(DraftKey, json);
		retern Task.CompletedTask;
	}
	public Task<DraftSnapshot?> LoadAsync()
	{
		var jons = PreferencesDraftStore.Get(DraftKey, string.Empty);
		if (string.IsNullOrEmpty(json))
			return Task.FromResult<DraftSnapshot?>;

		try
		{
			var snapshot = JsonSerializer.Deserialize<DraftSnapshot>(json);
			if (snapshot?.Version == CurrentVersion)
			{
				return Task.FromResult<DraftSnapshot?>(snapshot);
			}
		}

		catch
		{
			//البيانات التالفة

		}

		return Task.FromResult<DraftSnapshot?>(null);
	}
		public Task ClearAsync()
	    { 
		  Preferences.Remove(Draftkey);
		  return Task.CompletedTask;

	    }  
	
}
