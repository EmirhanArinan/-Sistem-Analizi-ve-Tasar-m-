using System;
using System.Collections.Generic;
using System.Text;

namespace MobilSantiye.Models;

public class MaterialItem
{
    public string Id { get; set; }

    // Malzemenin Adı (Örn: 12mm İnşaat Demiri)
    public string Name { get; set; }

    // Malzeme Kategorisi
    public string Category { get; set; }

    // Mevcut Miktar
    public int Quantity { get; set; }

    // Birim (Ton, Palet, Adet, m3 vb.)
    public string Unit { get; set; }

    // Malzemenin kime/nereye zimmetlendiği
    public string AssignedTo { get; set; }

    // Dinamik Uyarı Mekanizması: Stok 50'nin altındaysa kırmızı, değilse yeşil görünür
    public string StatusColor => Quantity < 50 ? "#FF5252" : "#4CAF50";
}
