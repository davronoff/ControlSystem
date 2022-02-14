using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDavomat.Domain
 {
     public class Oqituvchi
     {
         [Required, Key]
         public Guid Id { get; set; }
         [Required]
         public string Familiya { get; set; }
         [Required]
         public string Ism { get; set; }
         [Required]
         public string Adres { get; set; }
         [Required]
         public int TelefonRaqam { get; set; }
         public EnumOfGander Jinsi { get; set; }
         [Required]
         public byte Yoshi { get; set; }
         [Required]
         public EnumOfExperience Soxasi { get; set; }
     }
 }