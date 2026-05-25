using System.Collections.ObjectModel;
using MobilSantiye.Models;

namespace MobilSantiye;

public partial class MainPage : ContentPage
{
    public ObservableCollection<MaterialItem> Materials { get; set; }

    public MainPage()
    {
        InitializeComponent();

        Materials = new ObservableCollection<MaterialItem>
        {
            new MaterialItem { Id = "1", Name = "12mm İnşaat Demiri", Category = "Demir", Quantity = 450, Unit = "Ton", AssignedTo = "A Blok Temel Ekibi" },
            new MaterialItem { Id = "2", Name = "Portland Çimento", Category = "Çimento", Quantity = 25, Unit = "Palet", AssignedTo = "Genel Depo" },
            new MaterialItem { Id = "3", Name = "C35 Hazır Beton", Category = "Beton", Quantity = 120, Unit = "m3", AssignedTo = "B Blok Kolon Dökümü" },
            new MaterialItem { Id = "4", Name = "Tuğla (19x19)", Category = "Duvar", Quantity = 5000, Unit = "Adet", AssignedTo = "A Blok 1. Kat Taşeronu" },
            new MaterialItem { Id = "5", Name = "İzolasyon Membranı", Category = "Yalıtım", Quantity = 15, Unit = "Rulo", AssignedTo = "Çatı Ekibi" }
        };

        MaterialsListView.ItemsSource = Materials;
    }

    private async void OnScanBarcodeClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Kamera Başlatılıyor", "Cihazın kamerası açılarak karekod tarama işlemi gerçekleştirilecek.", "Tamam");
    }

    // YENİ EKLENEN KISIM: Butona basıldığında yeni sayfayı açar ve listeyi o sayfaya gönderir
    private async void OnAddMaterialClicked(object sender, EventArgs e)
    {
        // NewMaterialPage sayfasını açarken, kendi Materials listemizi de parametre olarak veriyoruz
        await Navigation.PushModalAsync(new NewMaterialPage(Materials));
    }
}
