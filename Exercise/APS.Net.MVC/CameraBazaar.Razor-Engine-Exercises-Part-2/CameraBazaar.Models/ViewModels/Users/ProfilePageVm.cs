using System.Collections.Generic;
using CameraBazaar.Models.ViewModels.Cameras;

namespace CameraBazaar.Models.ViewModels.Users
{
    public class ProfilePageVm
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int InStockCameras { get; set; }

        public int OutOfStockCameras { get; set; }

        public IEnumerable<ShortCameraVm> Cameras { get; set; }
    }
}