using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAssetAppASP.Models;


public class User
{
    [Required][Key]
    public string UserName { get; set; }
    public string Password { get; set; }
}