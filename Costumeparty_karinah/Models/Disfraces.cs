using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Costumeparty_karinah.Models
{
    public class Disfraces  
    {
        [HiddenInput(DisplayValue = false)]
        public int DisfracesId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Theme")]
        public string Theme { get; set; }
        [Display(Name = "IsAccompanied?")]
        public bool IsAccompanied { get; set; }
        [UIHint("Enum")]
        public Disfraz Disfraz { get; set; }
    }   

    public enum Disfraz
    { 
     Vampiros,
     Zombies,
     Bruja,
     Otro
    }
 }