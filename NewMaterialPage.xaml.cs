using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using MobilSantiye.Models;

namespace MobilSantiye
{
    public partial class NewMaterialPage : ContentPage
    {
        private ObservableCollection<MaterialItem> _materialsList;

        public NewMaterialPage(ObservableCollection<MaterialItem> materials)
        {
            InitializeComponent();
            _materialsList = materials;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            
            if (NamePicker.SelectedItem == null || string.IsNullOrWhiteSpace(QuantityEntry.Text))
            {
                await DisplayAlert("Hata", "Lütfen Malzeme Adı seçin ve Miktar girin.", "Tamam");
                return;
            }

            if (!int.TryParse(QuantityEntry.Text, out int parsedQuantity))
            {
                await DisplayAlert("Hata", "Miktar alanı sadece rakamlardan oluşmalıdır.", "Tamam");
                return;
            }

            var newMaterial = new MaterialItem
            {
                Id = Guid.NewGuid().ToString(),

                // Picker'dan seçilen değeri string'e çevirip alıyoruz
                Name = NamePicker.SelectedItem.ToString(),

                // Eğer Kategori veya Birim seçilmemişse varsayılan değerler atıyoruz
                Category = CategoryPicker.SelectedItem != null ? CategoryPicker.SelectedItem.ToString() : "Genel",
                Quantity = parsedQuantity,
                Unit = UnitPicker.SelectedItem != null ? UnitPicker.SelectedItem.ToString() : "Adet",

                AssignedTo = string.IsNullOrWhiteSpace(AssignedToEntry.Text) ? "Belirtilmedi" : AssignedToEntry.Text
            };

            _materialsList.Add(newMaterial);
            await Navigation.PopModalAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
