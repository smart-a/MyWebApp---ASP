using MyAppData.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAppData.ViewModels;

namespace MyAppData.Interfaces
{
    public interface IGeneral
    {
        string GetPic(string UserId);
     
        IEnumerable<DisplayDetails> GetLkMaritalStatus();
        IEnumerable<DisplayDetails> GetLkGenders();

        bool checkTelExists(string Tel1);
     
     
      
      
        string GetGender(string Id);
        string GetMS(string Id);
        
        int GetTrailActionId(string ActionName);
       
        string GetFullNameFromTel(string tel);
        bool CheckPicExists(string refkey);
       
        string GetUsersId(string Id);
       
        IEnumerable<DisplayDetails> GetLkStates();
        IEnumerable<DisplayDetails> GetLkLga();

        bool checkFullNameExists(string fn);


    }
}
