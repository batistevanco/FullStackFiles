using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using MusicStore.ViewModels;
namespace MusicStore.ViewModels
{
    public class StoreBrowseVM
    {
        public Genre? Genre { get; set; }
        public List<Album>? Albums { get; set; }
    }
}
