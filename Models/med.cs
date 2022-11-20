using System.ComponentModel.DataAnnotations;
namespace MyMedicine.Models;

public class med
{
    
    public int Id {get; set;}
    
    public string Name { get; set; }
    
    public string Dosage { get; set; }

    public string Address {get; set;}

    // public int userID {get; set;}=0;
    
    public bool Urgency{get; set;}=false;

    [DataType(DataType.Date)]
    public DateTime ArrivalDate {get; set;} = DateTime.Now.Date;

    public string Destination {get; set;}="Not Provided yet";

    public string UserPhoneNumber { get; set; } = "Not Provided yet";

    public string handled { get; set; } = "";

    public int userId { get; set; } = 1999;
    public string UserName{get; set;}="";


//    public List<string> ArrivalDate { get; set; }
//    public List<string> Destination { get; set; }
}
