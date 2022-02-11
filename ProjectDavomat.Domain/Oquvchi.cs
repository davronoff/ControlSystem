using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.Domain
{
    public class Oquvchi
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
        public int Telefonraqam { get; set; }
        [Required]
        public EnumOfGander Jinsi { get; set; }
        [Required]
        public byte Yosh { get; set; }
        [Required]
        public EnumOfKurs OquvchiKerakKurs { get; set; }
    }
}
